using App_Dev_1670.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;

namespace App_Dev_1670.Data
{
    public class ApplicationDatabase : IdentityDbContext<IdentityUser> //dùng xuyên suốt hệ thống
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options) //đưa tất cả options vào base
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //\\Customer <-> Book (Many -> Many) 
            modelBuilder.Entity<Customer>()
              .HasMany(e => e.Books)
              .WithMany(e => e.Customers);
            //Customer <-> Book


            //\\Category -> Book (One -> Many)
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Books)
                .HasForeignKey(e => e.CategoryID);
            //Category -> Book


            //\\Order -> Payment (One -> One)
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Payment)
                .WithOne(e => e.Order)
                .HasForeignKey<Payment>(e => e.OrderID);
            //Order -> Payment

            //\\Customer -> Order (One-> Many)
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerID);

            //Customer -> Order (One-> Many)

            //\\Seller -> Order (One-> Many)
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.SellerID);

            //Seller -> Order (One-> Many)




            //\\Seller -> Book (One-> Many)
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.Books)
                .HasForeignKey(e => e.SellerID);

            //Seller -> Order (One-> Many)


            //\\Book <-> Order (Many -> Many) 
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Orders);

            //\\Book <-> Order


        }
    }
}
