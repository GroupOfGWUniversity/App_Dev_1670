using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App_Dev_1670.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.Book.GetAll().ToList();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryID.ToString(),
            });

            IEnumerable<SelectListItem> SellerList = _unitOfWork.Seller.GetAll().Select(s => new SelectListItem
            {
                Text = s.ShopName,
                Value = s.SellerID.ToString(),
            });
            return View(books);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryID.ToString(),
            });
            //ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;

            IEnumerable<SelectListItem> SellerList = _unitOfWork.Seller.GetAll().Select(s => new SelectListItem
            {
                Text = s.ShopName,
                Value = s.SellerID.ToString(),
            });
            ViewBag.SellerList = SellerList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Book created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? bookFromDb = _unitOfWork.Book.Get(u => u.BookID == id);
            //Book? bookFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Book? bookFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Book obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Book updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? bookFromDb = _unitOfWork.Book.Get(u => u.BookID == id);

            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Book? obj = _unitOfWork.Book.Get(u => u.BookID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Book deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
