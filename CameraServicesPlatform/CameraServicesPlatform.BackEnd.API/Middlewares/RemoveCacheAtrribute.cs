using CameraServicesPlatform.BackEnd.Application.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace CameraServicesPlatform.BackEnd.API.Middlewares
{
    public class RemoveCacheAtrribute : Attribute, IAsyncActionFilter
    {
        private readonly string pathEndPoint;
        private readonly IConfiguration _configuration;

        public RemoveCacheAtrribute(string pathEndPoint, IConfiguration configuration)
        {
            this.pathEndPoint = $"/{pathEndPoint}/";
            _configuration = configuration;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Fetch cache setting from appsettings.json
            bool isCacheEnabled = _configuration.GetValue<bool>("RedisCacheSettings:Enabled");

            if (!isCacheEnabled)
            {
                await next();
                return;
            }

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var result = await next();

            if (result.Result is ObjectResult okObjectResult)
            {
                await cacheService.RemoveCacheResponseAsync(pathEndPoint);
            }
        }
    }
}
