using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Repository
{
    public class Repository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
