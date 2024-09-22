namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IResponseCacheService
    {
        Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut);
        Task<string> GetCacheResponseAsync(string cacheKey);
        Task RemoveCacheResponseAsync(string pattern);
        Task EnqueueResponseAsync<T>(string queueName, T obj) where T : class;
        Task<T> DequeueResponseAsync<T>(string queueName) where T : class;
    }
}
