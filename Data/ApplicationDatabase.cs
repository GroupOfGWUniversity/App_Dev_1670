﻿using App_Dev_1670.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace App_Dev_1670.Data
{
    public class ApplicationDatabase : IdentityDbContext<Customer> //dùng xuyên suốt hệ thống
    {

       d public DbSet<Book> Books { get; set; }
        public DbSet<Order> OrderDetails { get; set; }
        public DbSet<Order> OrderHeader { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options) //đưa tất cả options vào base
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);


        }
    }
}
