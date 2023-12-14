using System.ComponentModel.DataAnnotations;


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
        public double? Total { get; set; }

        public Payment? Payment { get; set; }
        public int PaymentID {  get; set; }

      
        //Relationship with Book Table
        public List<Book> BooksInOrder { get; } = new();
        //contain 2,more users (seller, customer)
        public List<ApplicationUser> ListOfUsers { get; } = new();


    }
}
