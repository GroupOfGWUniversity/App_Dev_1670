using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace App_Dev_1670.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> productList = _unitOfWork.Book.GetAll(includeProperty: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Cart cart = new()
            {
                Book = _unitOfWork.Book.Get(u => u.BookID == productId, includeProperty: "Category"),
                Count = 1,
                BookID = productId

            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.ApplicationUserID = userId;
            Cart cartFromDb = _unitOfWork.Cart.Get(c => c.ApplicationUserID == userId && c.BookID == cart.BookID);
            var bookToUpdate = _unitOfWork.Book.Get(u => u.BookID == cart.BookID);

            if (cartFromDb != null)
            {
                // Kiểm tra xem số lượng sách trong kho có đủ để giảm đi không
                if (bookToUpdate.InStock >= cart.Count)
                {
                    bookToUpdate.InStock = Math.Max(0, bookToUpdate.InStock - cart.Count);

                    // Cập nhật thay đổi vào cơ sở dữ liệu
                    _unitOfWork.Book.Update(bookToUpdate);
                    _unitOfWork.Save();

                    // Cập nhật số lượng trong giỏ hàng
                    cartFromDb.Count += cart.Count;
                    _unitOfWork.Cart.Update(cartFromDb);
                }
                else
                {
                    TempData["Error"] = "Not enough stock available.";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                // Kiểm tra xem số lượng sách trong kho có đủ để thêm vào giỏ hàng không
                if (bookToUpdate.InStock >= cart.Count)
                {
                    // Giảm số lượng sách trong kho
                    bookToUpdate.InStock = Math.Max(0, bookToUpdate.InStock - cart.Count);

                    // Cập nhật thay đổi vào cơ sở dữ liệu
                    _unitOfWork.Book.Update(bookToUpdate);
                    _unitOfWork.Save();

                    // Thêm mới vào giỏ hàng
                    _unitOfWork.Cart.Add(cart);
                }
                else
                {
                    TempData["Error"] = "Not enough stock available.";
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Success"] = "Cart updated successfully";
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}