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
<<<<<<< HEAD
        [ValidateNever]
=======
>>>>>>> 719265979e123ae5c5263cd0965ff5ab1ba07e5b
        public bool Condition { get; set; }
        public int InStock { get; set; }
        public string FrontBookUrl { get; set; }
        public string BackBookUrl { get; set; }

        [ValidateNever]
        public List<Customer> Customers { get; } = new List<Customer>();

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
    }
}
