using CameraServicesPlatform.BackEnd.DAO.Data;
 using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CameraServicesPlatform.BackEnd.API.Installers;

public class DbInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CameraServicesPlatformDbContext>(option =>
        {
            option.UseSqlServer(configuration["ConnectionStrings:DBVPS"]);
        });

        services.AddIdentity<Account, IdentityRole>().AddEntityFrameworkStores<CameraServicesPlatformDbContext>()
            .AddDefaultTokenProviders();
    }
}
