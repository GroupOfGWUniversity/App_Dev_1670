using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace App_Dev_1670.Models
{
	public class Book
    {
        [Required]
        public int BookID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        [ValidateNever]
        public bool? Condition { get; set; }
        public int InStock { get; set; }
        [ValidateNever]
        public string? FrontBookUrl { get; set; }
        [ValidateNever]
        public string? BackBookUrl { get; set; }
        [ValidateNever]
        public List<Customer> Customers { get; } = new();


        ////Relationship with Category Table
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        [ValidateNever]
        public Category Category { get; set; }
        ////\\Relationship with Category Table

        ////Relationship with Seller Table
        public int SellerID { get; set; }
        [ForeignKey("SellerID")]
        [ValidateNever]
        public Seller Seller { get; set; }
        ////Relationship with Seller Table



        //Relationship with Order Table
        [ValidateNever]
        public List<Order> Orders { get; } = new();




    }
}
