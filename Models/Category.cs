<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using App_Dev_1670.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App_Dev_1670.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
<<<<<<< HEAD
        //public List<Book> Books { get; } = new();
=======
        public List<Book> Books { get; } = new();
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621


    }
}
