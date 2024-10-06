using CameraServicesPlatform.BackEnd.Application;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.DAO.Data;
using CameraServicesPlatform.BackEnd.Infrastructure.Repositories;
using CameraServicesPlatform.BackEnd.Infrastructure.UnitOfWork;


namespace CameraServicesPlatform.BackEnd.API.Installers;

public class ServiceInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        //========//
        services.AddScoped<IDbContext, CameraServicesPlatformDbContext>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IExcelService, ExcelService>();
        services.AddScoped<IConfigurationService, ConfigurationService>();

        //========18/9/2024//
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IVoucherService, VoucherService>();
        services.AddScoped<IProductImageService, ProductImageService>();

    }
}
