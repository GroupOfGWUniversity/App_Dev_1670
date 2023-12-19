using App_Dev_1670.Models;
using App_Dev_1670.Repository;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace App_Dev_1670.Areas.Seller.SellerControllers
{
    [Area("Seller")]
    //[Authorize(Roles = SD.Role_Seller)]

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {

            }
            else
            {
                List<Book> books = _unitOfWork.Book.GetAll().ToList();

                //                List<Book> books = _unitOfWork.Book.Get(u => u.SellerID == userId);
                return View(books);

            }
            return View();

        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

    }
}
