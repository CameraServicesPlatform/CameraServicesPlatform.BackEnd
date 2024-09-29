using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CameraServicesPlatform.BackEnd.DAO.Data
{
    public class CameraServicesPlatformDbContext : IdentityDbContext<Account>, IDbContext
    {
        public CameraServicesPlatformDbContext(DbContextOptions<CameraServicesPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        //public DbSet<AccountRole> AccountRoles { get; set; }

        //public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ReturnDetail> ReturnDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ProductReport> ProductReports { get; set; }
        public DbSet<SupplierReport> SupplierReports { get; set; }
        public DbSet<SupplierRequest> SupplierRequests { get; set; }
        public DbSet<DeliveriesMethod> DeliveriesMethod { get; set; }
        public DbSet<Vourcher> Vourchers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1cf2de31-b0d8-4447-8f2f-c41df905a3a5",
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9",
                    Name = "MEMBER",
                    NormalizedName = "Member"
                },
                new IdentityRole
                {
                    Id = "086b7a13-79af-4610-851d-204d9d84b865",
                    Name = "STAFF",
                    NormalizedName = "Staff"
                },
                new IdentityRole
                {
                    Id = "74bd6d3a-1119-449b-9743-3956d74e7575",
                    Name = "Supplier",
                    NormalizedName = "Supplier"
                }
            );


        }
    }
}
