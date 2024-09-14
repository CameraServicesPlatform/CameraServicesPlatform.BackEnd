/*using CameraServicesPlatform.BackEnd.DAO.Data;
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
            // Build configuration to read from appsettings.json or another source
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CameraServicesPlatformDbContext>();

            // Get the connection string from the configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure the DbContext with the connection string
            optionsBuilder.UseSqlServer(connectionString);

            return new CameraServicesPlatformDbContext(optionsBuilder.Options);
        }
    }
}
*/