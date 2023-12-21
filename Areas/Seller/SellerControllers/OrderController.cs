using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Models.ViewModels;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
namespace App_Dev_1670.Areas.Seller.SellerControllers
{
    [Area("Seller")]
    [Authorize(Roles = SD.Role_Seller)]
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
            List<Order> books = _unitOfWork.Order.GetAll().ToList();
            return View(books);
        }
    }
}
