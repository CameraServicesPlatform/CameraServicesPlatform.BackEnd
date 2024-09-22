using CameraServicesPlatform.BackEnd.Common.Validator;



namespace CameraServicesPlatform.BackEnd.API.Installers;

public class ValidatorInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<HandleErrorValidator>();
    }
}