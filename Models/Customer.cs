using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace App_Dev_1670.Models
{
    public class Customer: IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HoangTran { get; set; }
    }
}
