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


        public DbSet<Book> Books { get; set; }
        public DbSet<Order> OrderDetails { get; set; }
        public DbSet<Order> OrderHeader { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options) //đưa tất cả options vào base
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

<<<<<<< HEAD
            ////\\Customer <-> Book (Many -> Many) 
            //modelBuilder.Entity<Customer>()
            //  .HasMany(e => e.Books)
            //  .WithMany(e => e.Customers);
            ////Customer <-> Book
=======
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621

            //\\Users(Customer) <-> Books (Many -> Cart <- Many)
            modelBuilder.Entity<User>()
              .HasMany(e => e.BooksInCart)
              .WithMany(e => e.ListOfCustomers)
              .UsingEntity("Cart");

<<<<<<< HEAD
            ////\\Category -> Book (One -> Many)
            //modelBuilder.Entity<Book>()
            //    .HasOne(e => e.Category)
            //    .WithMany(e => e.Books)
            //    .HasForeignKey(e => e.CategoryID);
            ////Category -> Book


            ////\\Order -> Payment (One -> One)
            //modelBuilder.Entity<Order>()
            //    .HasOne(e => e.Payment)
            //    .WithOne(e => e.Order)
            //    .HasForeignKey<Payment>(e => e.OrderID);
            ////Order -> Payment

            ////\\Customer -> Order (One-> Many)
            //modelBuilder.Entity<Order>()
            //    .HasOne(e => e.Customer)
            //    .WithMany(e => e.Orders)
            //    .HasForeignKey(e => e.CustomerID);

            ////Customer -> Order (One-> Many)

            ////\\Seller -> Order (One-> Many)
            //modelBuilder.Entity<Order>()
            //    .HasOne(e => e.Seller)
            //    .WithMany(e => e.Orders)
            //    .HasForeignKey(e => e.SellerID);

            ////Seller -> Order (One-> Many)




            ////\\Seller -> Book (One-> Many)
            //modelBuilder.Entity<Book>()
            //    .HasOne(e => e.Seller)
            //    .WithMany(e => e.Books)
            //    .HasForeignKey(e => e.SellerID);

            ////Seller -> Order (One-> Many)


            ////\\Book <-> Order (Many -> Many) 
            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.Books)
            //    .WithMany(e => e.Orders);

            ////\\Book <-> Order
=======
            //\\User(Seller) -> Books (One -> Many)
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.SellBooks)
                .HasForeignKey(e => e.SellerID)
                .OnDelete(DeleteBehavior.SetNull);// khi xoá 1 Seller -> Trong Book -> SellerID= Null

            //\\Users <-> Orders (Many -> UserOrder <- Many)
            modelBuilder.Entity<User>()
                 .HasMany(e => e.ListOrders)
              .WithMany(e => e.ListOfUsers);


            //\\Orders <-> Books (Many -> OrderBook <- Many)
            modelBuilder.Entity<Order>()
                .HasMany(e => e.BooksInOrder)
             .WithMany(e => e.ListOfOrders);




            //\\Category -> Books (One -> Many)
            modelBuilder.Entity<Book>()
             .HasOne(e => e.Category)
             .WithMany(e => e.Books)
             .HasForeignKey(e => e.CategoryID);



            //\\Order -> Payment (One -> One)
            modelBuilder.Entity<Payment>()
                .HasOne(e => e.Order)
                .WithOne(e => e.Payment)
                .HasForeignKey<Order>(e => e.PaymentID);
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621


        }
    }
}
