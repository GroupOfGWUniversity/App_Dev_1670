using App_Dev_1670.Models;
using App_Dev_1670.Models.ViewModels;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;

namespace App_Dev_1670.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.Role_Customer)]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       // private readonly IEmailSender _emailSender;
        [BindProperty]
        public CartVM CartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           // _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            CartVM = new()
            {
                ListCart = _unitOfWork.Cart.GetAll(u => u.ApplicationUserID == userId,
                includeProperty: "Book"),
                Order = new()
            };

            foreach (var cart in CartVM.ListCart)
            {
                

                cart.Price = GetPriceBasedOnQuantity(cart);
                CartVM.Order.Total += (cart.Price * cart.Count);
            }

            return View(CartVM);
        }
        public IActionResult Summary()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            CartVM = new()
            {
                ListCart = _unitOfWork.Cart.GetAll(u => u.ApplicationUserID == userId,
                includeProperty: "Book"),
                Order = new()
            };

            CartVM.Order.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            CartVM.Order.Name = CartVM.Order.ApplicationUser.Name;
            CartVM.Order.PhoneNumber = CartVM.Order.ApplicationUser.PhoneNumber;
            CartVM.Order.StreetAddress = CartVM.Order.ApplicationUser.StressAddress;
     
            CartVM.Order.City = CartVM.Order.ApplicationUser.City;
            CartVM.Order.DateOfBirth = CartVM.Order.ApplicationUser.DateOfBirth;
            CartVM.Order.Gender = CartVM.Order.ApplicationUser.Gender;



            foreach (var cart in CartVM.ListCart)
            {
                //cart.Book.FrontBookUrl = productImages.Where(u => u.ProductId == cart.Product.Id).ToList();

                cart.Price = GetPriceBasedOnQuantity(cart);
                CartVM.Order.Total += (cart.Price * cart.Count);
            }
            if (CartVM.Order.Total == 0)
            {
                TempData["ErrorMessage"] = "Đơn hàng của bạn không có. Hãy thêm sản phẩm vào giỏ hàng.";

                return Redirect("/User");
            }
            return View(CartVM);
        }
        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CartVM.ListCart = _unitOfWork.Cart.GetAll(u => u.ApplicationUserID == userId,
             includeProperty: "Book");
            CartVM.Order.OrderDate = System.DateTime.Now;
            CartVM.Order.ApplicationUserID = userId;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            

            foreach (var cart in CartVM.ListCart)
            {
                //cart.Book.FrontBookUrl = productImages.Where(u => u.ProductId == cart.Product.Id).ToList();

                cart.Price = GetPriceBasedOnQuantity(cart);
                CartVM.Order.Total += (cart.Price * cart.Count);
            }
           


            if (applicationUser == null || applicationUser.Id == "0")
            {

                CartVM.Order.Status = SD.StatusPending;
            }
            else
            {

                CartVM.Order.Status = SD.StatusApproved;
            }

            _unitOfWork.Order.Add(CartVM.Order);
            _unitOfWork.Save();
            foreach (var cart in CartVM.ListCart)
            {
                OrderDetails orderDetail = new()
                {
                    BookID = cart.BookID,
                    OrderID = CartVM.Order.OrderID,
                    Price = cart.Price,
                    Count = cart.Count
                };
                _unitOfWork.OrderDetails.Add(orderDetail);
                _unitOfWork.Save();
                _unitOfWork.Cart.Remove(cart);

            }
            _unitOfWork.Save();

            return RedirectToAction(nameof(OrderConfirmation), new {id = CartVM.Order.OrderID});
        }
        public IActionResult OrderConfirmation(int id)
        {

            return View(id);
        }


            public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.ID == cartId);
            cartFromDb.Count += 1;
            _unitOfWork.Cart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.ID == cartId);
            if(cartFromDb.Count <= 1)
            {
                //remove thar from cart
                _unitOfWork.Cart.Remove(cartFromDb);

            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.Cart.Update(cartFromDb);
            }
           
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.ID == cartId);
            
                //remove thar from cart
            _unitOfWork.Cart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private double GetPriceBasedOnQuantity(Cart cart)
        {
            if (cart.Count <= 50)
            {
                return cart.Book.Price;
            }
            else
            {
                if (cart.Count <= 100)
                {
                    return cart.Book.Price * 0.2;
                }
                else
                {
                    return cart.Book.Price* 0.3;
                }
            }
        }
  public int TotalCount()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carts = _unitOfWork.Cart.GetAll(u=>u.ApplicationUserID== userid).ToList();
            int count = 0;

            if (carts != null)
            {
                 count = carts.Count();

            }
            
            return count;

        }
    }
}
