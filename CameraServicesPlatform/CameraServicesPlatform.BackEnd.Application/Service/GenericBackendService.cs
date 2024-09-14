using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using RestSharp;
 
namespace CameraServicesPlatform.BackEnd.Application.Service;

public class GenericBackendService
{
    private readonly IServiceProvider _serviceProvider;

    public GenericBackendService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T? Resolve<T>()
    {
        return (T)_serviceProvider.GetService(typeof(T))!;
    }

    public AppActionResult BuildAppActionResultError(AppActionResult result, string messageError)
    {
        List<string?> errors;
        errors = new List<string?> { messageError };

        return new AppActionResult
        {
            IsSuccess = false,
            Messages = errors,
            Result = null
        };
    }

    public bool BuildAppActionResultIsError(AppActionResult result)
    {
        return !result.IsSuccess ? true : false;
    }

    public enum APIMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public async Task<RestResponse> CallAPIAsync(string endpoint, object data, APIMethod method)
    {
        var client = new RestClient();
        var request = new RestRequest(endpoint);

        switch (method)
        {
            case APIMethod.GET:
                request.Method = Method.Get;
                break;

            case APIMethod.POST:
                request.Method = Method.Post;
                request.AddJsonBody(data); // Assuming data is already in JSON format
                break;

            case APIMethod.PUT:
                request.Method = Method.Put;
                request.AddJsonBody(data); // Assuming data is already in JSON format
                break;

            case APIMethod.DELETE:
                request.Method = Method.Delete;
                break;
        }

        RestResponse response = await client.ExecuteAsync(request);
        return response;
    }

}