using CameraServicesPlatform.BackEnd.Application;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Infrastructure.Repositories;
using CameraServicesPlatform.BackEnd.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Migrations;


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
        services.AddScoped<IProductVoucherService, ProductVoucherService>();
        services.AddScoped<IProductSpecificationService, ProductSpecificationService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IRatingService, RatingService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IReturnDetailService, ReturnDetailService>();
        services.AddScoped<IWishlistService, WishlistService>();
        services.AddScoped<IPolicyService, PolicyService>();
        services.AddScoped<IContractTemplateService, ContractTemplateService>();
        services.AddScoped<ISmsService, SmsService>();
        services.AddScoped<IProductReportService, ProductReportService>();
        services.AddScoped<IFirebaseService, FirebaseService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IDeliveriesMethodService, DeliveriesMethodService>();
        services.AddScoped<IDashbroardService, DashbroardService>();
        services.AddScoped<IPaymentGatewayService, PaymentGatewayService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IHistoryTransactionService, HistoryTransactionService>();



    }

}
