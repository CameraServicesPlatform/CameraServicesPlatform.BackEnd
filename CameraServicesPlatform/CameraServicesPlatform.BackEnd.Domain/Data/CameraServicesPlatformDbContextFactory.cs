﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CameraServicesPlatform.BackEnd.Domain.Data
{
    public class CameraServicesPlatformDbContextFactory : IDesignTimeDbContextFactory<CameraServicesPlatformDbContext>
    {
        public CameraServicesPlatformDbContext CreateDbContext(string[] args)
        {
            // Đảm bảo đúng đường dẫn tới thư mục chứa appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CameraServicesPlatform.BackEnd.API")) // Đường dẫn đến API project
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CameraServicesPlatformDbContext>();
            var connectionString = configuration.GetConnectionString("DBVPS");
            optionsBuilder.UseSqlServer(connectionString);

            return new CameraServicesPlatformDbContext(optionsBuilder.Options);
        }
    }
}
