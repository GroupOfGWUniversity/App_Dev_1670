using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace App_Dev_1670.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? AvatarUrl { get; set; }
        public List<Book> Books { get; } = new();

        public List<Order> Orders { get; } = new();
    }
}
