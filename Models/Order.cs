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

        public Payment Payment { get; set; }

        ////Relationship with Customer Table
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }
        ////Relationship with Customer Table




        ////Relationship with Seller Table
        public int? SellerID { get; set; }
        public Seller Seller { get; set; }
        ////Relationship with Seller Table

        //Relationship with Book Table
        public List<Book> Books { get; } = new();


    }
}
