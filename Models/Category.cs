using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App_Dev_1670.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public List<Book> Books { get; } = new();


    }
}
