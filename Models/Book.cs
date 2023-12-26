﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace App_Dev_1670.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [ValidateNever]
        public string Title { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

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
        public List<OrderDetails> ListOfOrders { get; } = new();
        [ValidateNever]
        public ApplicationUser? Seller {  get; set; }
        public String? SellerID { get; set; }

        public List<ApplicationUser> ListOfCustomers { get; } = new();

        public bool IsVisible { get; set; }
    }
}
