using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App_Dev_1670.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SellerList { get; set; }

    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
