using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App_Dev_1670.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View(books);
        }
        public IActionResult Create()
        {
            BookVM bookVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryID.ToString()
                }),
                SellerList = _unitOfWork.Seller.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ShopName,
                    Value = u.SellerID.ToString()
                }),
                Book = new Book()
            };
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookVM obj)
        {

            if (!ModelState.IsValid)
            {
                _unitOfWork.Book.Add(obj.Book);
                _unitOfWork.Save();
                TempData["success"] = "Book created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                BookVM bookVMNew = new BookVM()
                {
                    CategoryList = _unitOfWork.Category.GetAll().
                               Select(u => new SelectListItem
                               {
                                   Text = u.Name,
                                   Value = u.CategoryID.ToString()
                               }),
                    SellerList = _unitOfWork.Seller.GetAll().
                               Select(u => new SelectListItem
                               {
                                   Text = u.ShopName,
                                   Value = u.SellerID.ToString()
                               }),
                    Book = new Book()
                };
                return View(bookVMNew);
            }
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