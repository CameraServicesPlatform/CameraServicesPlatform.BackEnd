using CameraServicesPlatform.BackEnd.Application.IService;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public ResponseCacheService(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer)
        {
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var cacheResponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cacheResponse) ? null : cacheResponse;
        }

        public async Task RemoveCacheResponseAsync(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentException("Value cannot be null or white space");
            await foreach (var key in GetKeyAsyncByPattern(pattern + "*"))
            {
                await _distributedCache.RemoveAsync(key);
            }
        }

        private async IAsyncEnumerable<string> GetKeyAsyncByPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentException("Value cannot be null or white space");
            foreach (var endpoint in _connectionMultiplexer.GetEndPoints())
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                foreach (var key in server.Keys(pattern: pattern))
                {
                    yield return key.ToString();
                }
            }
        }

        public async Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut)
        {
            if (response == null)
            {
                return;
            }
            var serializerResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            await _distributedCache.SetStringAsync(cacheKey, serializerResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeOut
            });
        }

        public async Task EnqueueResponseAsync<T>(string queueName, T response) where T : class
        {
            var database = _connectionMultiplexer.GetDatabase();
            var serializedResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            // Check if the response is not already in the queue
            if (!await IsResponseInQueueAsync(database, queueName, serializedResponse))
            {
                await database.ListRightPushAsync(queueName, serializedResponse);
            }
        }

        private async Task<bool> IsResponseInQueueAsync(IDatabase database, string queueName, string serializedResponse)
        {
            var values = await database.ListRangeAsync(queueName);
            return values.Any(value => value == serializedResponse);
        }

        public async Task<T> DequeueResponseAsync<T>(string queueName) where T : class
        {
            var database = _connectionMultiplexer.GetDatabase();
            var serializedResponse = await database.ListLeftPopAsync(queueName);
            if (serializedResponse.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(serializedResponse, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
            return null;
        }
    }
}
