namespace CameraServicesPlatform.BackEnd.Application.IHubService;
public interface IHubServices
{
    Task SendAsync(string method);
}
