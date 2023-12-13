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
        public Category Category { get; set; }
        public int CategoryID { get; set; }


        [ValidateNever]
        public List<Order> ListOfOrders { get; } = new List<Order>();
        [ValidateNever]
        public User? Seller {  get; set; }
        public String? SellerID { get; set; }


        public List<User> ListOfCustomers{ get; }=new List<User>();
    }
}
