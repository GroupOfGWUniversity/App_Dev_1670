using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Dev_1670.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }

        [ValidateNever]

        public bool Condition { get; set; }
        public int InStock { get; set; }
        [ValidateNever]
        public string FrontBookUrl { get; set; }
        [ValidateNever]
        public string BackBookUrl { get; set; }

        [ValidateNever]
        public List<Customer> Customers { get; } = new List<Customer>();

<<<<<<< HEAD
        // Relationship with Category Table
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        [ValidateNever]
        public Category Category { get; set; }

        // Relationship with Seller Table
        public int SellerID { get; set; }

        [ForeignKey("SellerID")]
        [ValidateNever]
        public Seller Seller { get; set; }

        // Relationship with Order Table
        [ValidateNever]
        public List<Order> Orders { get; } = new List<Order>();
=======


        [ValidateNever]
        public Category Category { get; set; }
        public int CategoryID { get; set; }


        [ValidateNever]
        public List<Order> ListOfOrders { get; } = new List<Order>();
        [ValidateNever]
        public User? Seller { get; set; }
        public String? SellerID { get; set; }


        public List<User> ListOfCustomers { get; } = new List<User>();
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
    }
}
