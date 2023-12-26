using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]


    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();

            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    if(_unitOfWork.OrderDetails.GetAll().Any(od => od.Book.CategoryID == id)){
        //        TempData["warning"] = "Cannot delete category because it is associated with existing orders.";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
        //        if (obj == null)
        //        {
        //            return NotFound();
        //        }
        //        _unitOfWork.Category.Remove(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category deleted successfully";
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _unitOfWork.Category.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            // Lấy tất cả sách thuộc category và ẩn chúng
            IEnumerable<Book> booksInCategory = _unitOfWork.Book.GetAll(b => b.CategoryID == id);
            foreach (var book in booksInCategory)
            {
                book.Condition = false; 

                _unitOfWork.Book.Update(book);
            }
            obj.isVisible = false;
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}