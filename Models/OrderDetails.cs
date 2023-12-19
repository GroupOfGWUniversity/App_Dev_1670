using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Dev_1670.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        public int OrderID {  get; set; }
        public Order Order { get; set; }

        public int BookID {  get; set; }
        [ForeignKey("BookID")]
        [ValidateNever]
        public Book Book { get; set; }
        public int Count {  get; set; }
        public double Price {  get; set; }


    }
}
