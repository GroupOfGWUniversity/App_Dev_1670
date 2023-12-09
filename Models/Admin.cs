using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace App_Dev_1670.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string? Role { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
