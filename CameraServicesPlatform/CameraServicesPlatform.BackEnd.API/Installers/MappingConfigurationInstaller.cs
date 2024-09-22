using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;

namespace CameraServicesPlatform.BackEnd.API.Installers;

public class MappingConfigurationInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfiguration = new JWTConfiguration();
        configuration.GetSection("JWT").Bind(jwtConfiguration);
        services.AddSingleton(jwtConfiguration);

        var emailConfiguration = new EmailConfiguration();
        configuration.GetSection("Email").Bind(emailConfiguration);
        services.AddSingleton(emailConfiguration);

        var firebaseConfiguration = new FirebaseConfiguration();
        configuration.GetSection("Firebase").Bind(firebaseConfiguration);
        services.AddSingleton(firebaseConfiguration);

        var firebaseAdminSdkConfiguration = new FirebaseAdminSDK();
        configuration.GetSection("FirebaseAdminSDK").Bind(firebaseAdminSdkConfiguration);
        services.AddSingleton(firebaseAdminSdkConfiguration);

        var vnPayConfiguration = new VnPayConfiguration();
        configuration.GetSection("Vnpay").Bind(vnPayConfiguration);
        services.AddSingleton(vnPayConfiguration);
    }
}