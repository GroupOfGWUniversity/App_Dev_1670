using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App_Dev_1670.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int Count { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        [ValidateNever]
        public Book Book { get; set; }
        [Range(1, 100, ErrorMessage = "Please enter a value between 1 and 1000")]
        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
