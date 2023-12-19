using App_Dev_1670.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace App_Dev_1670.Data
{
    public class ApplicationDatabase : IdentityDbContext<IdentityUser> //dùng xuyên suốt hệ thống
    {

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> OrderHeader { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
        

        public DbSet<Cart> Carts { get; set; } 

        public DbSet<RequestCategory> RequestCategories { get; set; }
        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options) //đưa tất cả options vào base
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //\\User(Seller) -> Books (One -> Many)
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.SellBooks)
                .HasForeignKey(e => e.SellerID)
                .OnDelete(DeleteBehavior.SetNull);// khi xoá 1 Seller -> Trong Book -> SellerID= Null

            //\\Users <-> Orders (Many -> UserOrder <- Many)
            modelBuilder.Entity<ApplicationUser>()
                 .HasMany(e => e.ListOrders)
              .WithMany(e => e.ListOfUsers);


            //\\Category -> Books (One -> Many)
            modelBuilder.Entity<Book>()
             .HasOne(e => e.Category)
             .WithMany(e => e.Books)
             .HasForeignKey(e => e.CategoryID);

            //update OrderDetails


            //\\Order -> OrderBook (One -> Many)
            modelBuilder.Entity<OrderDetails>()
             .HasOne(e => e.Order)
             .WithMany(e => e.BooksInOrder)
             .HasForeignKey(e => e.OrderID);
            //\\Book -> OrderBook (One -> Many)
            modelBuilder.Entity<OrderDetails>()
             .HasOne(e => e.Book)
             .WithMany(e => e.ListOfOrders)
             .HasForeignKey(e => e.BookID);


            //update OrderDetails


            //\\Order -> Payment (One -> One)
            modelBuilder.Entity<Payment>()
                .HasOne(e => e.Order)
                .WithOne(e => e.Payment)
                .HasForeignKey<Order>(e => e.PaymentID);

           
        }
    }
}
