using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using App_Dev_1670.Models;

namespace App_Dev_1670.Areas.User.Controllers
{
    [Area("User")]
        [Authorize(Roles = SD.Role_Customer)]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Order> books = _unitOfWork.Order.GetAll(u => u.ApplicationUserID == userId).ToList();
            return View(books);
        }
        public IActionResult View(int? id)
        {
            var books = (from book in _unitOfWork.Book.GetAll()
                         join orderDetails in _unitOfWork.OrderDetails.GetAll() on book.BookID equals orderDetails.BookID
                         join ApplicationUser in _unitOfWork.ApplicationUser.GetAll() on book.SellerID equals ApplicationUser.Id
                         where orderDetails.OrderID == id
                         select book).ToList();
            return View(books);
        }
    }
}
