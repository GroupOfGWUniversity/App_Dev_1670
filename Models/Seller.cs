using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace App_Dev_1670.Models
{
    public class Seller
    {
        public int SellerID { get; set; }
        public string? ShopName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public bool? IsValid { get; set; }


        public List<Order> Orders { get; } = new();
        public List<Book> Books { get; } = new();


    }
}
