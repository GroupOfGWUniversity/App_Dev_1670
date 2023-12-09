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
        public bool? Condition { get; set; }
        public int InStock { get; set; }
        public string? FrontBookUrl { get; set; }
        public string? BackBookUrl { get; set; }
        public List<Customer> Customers { get; } = new();


        ////Relationship with Category Table
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        ////\\Relationship with Category Table

        ////Relationship with Seller Table
        public int? SellerID { get; set; }
        public Seller Seller { get; set; }
        ////Relationship with Seller Table



        //Relationship with Order Table
        public List<Order> Orders { get; } = new();




    }
}
