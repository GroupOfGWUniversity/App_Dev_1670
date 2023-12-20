using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App_Dev_1670.Models
{
    public class Order
    {
        [Required]
        public int OrderID { get; set; }
        public string? Status { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderReceived { get; set; }
        public double? ShippingFee { get; set; }
        public double? SubTotal { get; set; }
        public double Total { get; set; }

        public Payment? Payment { get; set; }
        public int PaymentID {  get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
       
        [Required]
        public string Name { get; set; }

        //Relationship with Book Table
        public List<OrderDetails> BooksInOrder { get; } = new();
        //contain 2,more users (seller, customer)
        public List<ApplicationUser> ListOfUsers { get; } = new();

       /* public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserID")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; } */



    }
}
