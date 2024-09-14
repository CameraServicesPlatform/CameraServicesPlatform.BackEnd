namespace CameraServicesPlatform.BackEnd.API.Installers;

public interface IInstaller
{
    void InstallService(IServiceCollection services, IConfiguration configuration);
}