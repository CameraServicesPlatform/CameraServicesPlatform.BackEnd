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
                    Id = "a12b3c4d-56ef-78gh-90ij-klmnopqrstuv",
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b21c4d5e-67fg-89hi-01jk-lmnopqrstuv",
                    Name = "MEMBER",
                    NormalizedName = "Member"
                },
                new IdentityRole
                {
                    Id = "c32d5e6f-78gh-90ij-12kl-mnopqrstuv",
                    Name = "STAFF",
                    NormalizedName = "Staff"
                },
                new IdentityRole
                {
                    Id = "d43e6f7g-89hi-01jk-23lm-nopqrstuv",
                    Name = "Supplier",
                    NormalizedName = "Supplier"
                }
            );

            //builder.Entity<Staff>()
            //.HasOne(s => s.Account)
            //.WithMany()
            //.HasForeignKey(s => s.AccountID)
            //.OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Transaction>()
            //.HasOne(t => t.Order)
            //.WithMany()  
            //.HasForeignKey(t => t.OrderID)
            //.OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<Transaction>()
            //    .HasOne(t => t.BankInformation)
            //    .WithMany()   
            //    .HasForeignKey(t => t.BankId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<Transaction>()
            //    .HasOne(t => t.Member)
            //    .WithMany()   
            //    .HasForeignKey(t => t.MemberId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
