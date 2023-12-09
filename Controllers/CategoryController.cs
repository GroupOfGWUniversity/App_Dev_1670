using App_Dev_1670.Data;
using App_Dev_1670.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDatabase _db;
        public CategoryController (ApplicationDatabase db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //List<Category> categories = _db.Categories.ToList();
            return View();
        }
    }
}
