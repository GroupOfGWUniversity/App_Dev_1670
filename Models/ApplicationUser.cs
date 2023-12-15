using Microsoft.AspNetCore.Identity;

namespace App_Dev_1670.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }
        //used by Seller Role (One Seller could pass many books)
        public List<Book> SellBooks { get; } = new();

        //used by User Role
        public List<Book> BooksInCart { get; } = new();

        public List<Order> ListOrders { get; } = new();
    }
}
