using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections;
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
            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = (from orderHeader in _unitOfWork.Order.GetAll()
                          join orderDetails in _unitOfWork.OrderDetails.GetAll() on orderHeader.OrderID equals orderDetails.OrderID
                          join books in _unitOfWork.Book.GetAll() on orderDetails.BookID equals books.BookID
                          where books.SellerID == sellerId
                          select orderHeader).ToList();


            return View(orders);
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ////string categoryFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            //List<OrderDetails> categories = _unitOfWork.OrderDetails.GetAll().Where(b => b.Book.SellerID == userId).ToList();
            //return View(categories);
        }
    }
}
