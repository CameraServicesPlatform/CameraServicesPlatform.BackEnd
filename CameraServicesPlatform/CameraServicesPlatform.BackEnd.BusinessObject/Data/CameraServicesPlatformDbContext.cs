using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.DAO.Data
{
    public class CameraServicesPlatformDbContext : IdentityDbContext<User>
    {
        public CameraServicesPlatformDbContext(DbContextOptions<CameraServicesPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecifications> ProductSpecifications { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<ReturnDetails> ReturnDetails { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Policies> Policies { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ShopStatus> ShopStatuses { get; set; }
        
        public DbSet<ShopRequests> ShopRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "a12b3c4d-56ef-78gh-90ij-klmnopqrstuv",
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b21c4d5e-67fg-89hi-01jk-lmnopqrstuv",
                    Name = "CUSTOMER",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Id = "c32d5e6f-78gh-90ij-12kl-mnopqrstuv",
                    Name = "STAFF",
                    NormalizedName = "STAFF"
                },
                new IdentityRole
                {
                    Id = "d43e6f7g-89hi-01jk-23lm-nopqrstuv",
                    Name = "SHOP",
                    NormalizedName = "SHOP"
                }
            );
        }
    }
}
