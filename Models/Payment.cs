using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App_Dev_1670.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string? Method { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Status { get; set; }
        public Order Order { get; set; }


    }
}
