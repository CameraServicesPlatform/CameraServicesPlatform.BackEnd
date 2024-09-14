using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TravelCapstone.BackEnd.Application.IServices;
using TravelCapstone.BackEnd.Common.ConfigurationModel;
using TravelCapstone.BackEnd.Common.DTO.Response;

namespace CameraServicesPlatform.BackEnd.API.Middlewares;

public class RemoveCacheAtrribute : Attribute, IAsyncActionFilter
{

    private readonly string pathEndPoint;

    public RemoveCacheAtrribute(string pathEndPoint)
    {
        this.pathEndPoint = $"/{pathEndPoint}/";
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cacheConfiguration = context.HttpContext.RequestServices.GetRequiredService<RedisConfiguration>();
        if (!cacheConfiguration.Enabled)
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