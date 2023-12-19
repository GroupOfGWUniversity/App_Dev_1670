using System.ComponentModel.DataAnnotations;

namespace App_Dev_1670.Models
{
    public class RequestCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Status { get; set; }
    }
}
