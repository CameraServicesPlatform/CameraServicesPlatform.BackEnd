using CameraServicesPlatform.BackEnd.DAO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CameraServicesPlatform.BackEnd.Domain.Data
{
    public class CameraServicesPlatformDbContextFactory : IDesignTimeDbContextFactory<CameraServicesPlatformDbContext>
    {
        public CameraServicesPlatformDbContext CreateDbContext(string[] args)
        {
            // Build configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CameraServicesPlatformDbContext>();

            // Use the connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new CameraServicesPlatformDbContext(optionsBuilder.Options);
        }
    }
}
