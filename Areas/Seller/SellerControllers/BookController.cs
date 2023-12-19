﻿using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Models.ViewModels;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
namespace App_Dev_1670.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles =SD.Role_Seller)]

    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Book> books = _unitOfWork.Book.GetAll(u => u.SellerID == userId).ToList();
            return View(books);
        }
        public IActionResult CreateUpdate(int? id)
        {
            BookVM bookVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Book = new Book()
            };
            if (id == null || id == 0)
            {
                //create
                return View(bookVM);
            }
            else
            {
                //update
                bookVM.Book = _unitOfWork.Book.Get(u => u.BookID == id);
                return View(bookVM);
            }
        }
        [HttpPost]
        public IActionResult CreateUpdate(BookVM obj, IFormFile? frontBookImage, IFormFile? BackBookImage)
        {

            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                /*var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);*/
=======
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
                Console.WriteLine(user);
>>>>>>> 87e1d6fce1de7097e072e9e7cb0d97761aba3466
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (frontBookImage != null)
                {
                    // Xử lý frontimage
                    string frontImageFileName = Guid.NewGuid().ToString() + Path.GetExtension(frontBookImage.FileName);
                    string frontImagePath = Path.Combine(wwwRootPath, @"images\book");

                    if (!string.IsNullOrEmpty(obj.Book.FrontBookUrl))
                    {
                        // Xóa ảnh cũ
                        var oldFrontImagePath = Path.Combine(wwwRootPath, obj.Book.FrontBookUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFrontImagePath))
                        {
                            System.IO.File.Delete(oldFrontImagePath);
                        }
                    }

                    using (var frontImageStream = new FileStream(Path.Combine(frontImagePath, frontImageFileName), FileMode.Create))
                    {
                        frontBookImage.CopyTo(frontImageStream);
                    }

                    obj.Book.FrontBookUrl = @"\images\book\" + frontImageFileName;
                }

                if (BackBookImage != null)
                {
                    // Xử lý backimage
                    string backImageFileName = Guid.NewGuid().ToString() + Path.GetExtension(BackBookImage.FileName);
                    string backImagePath = Path.Combine(wwwRootPath, @"images\book");

                    if (!string.IsNullOrEmpty(obj.Book.BackBookUrl))
                    {
                        // Xóa ảnh cũ
                        var oldBackImagePath = Path.Combine(wwwRootPath, obj.Book.BackBookUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldBackImagePath))
                        {
                            System.IO.File.Delete(oldBackImagePath);
                        }
                    }

                    using (var backImageStream = new FileStream(Path.Combine(backImagePath, backImageFileName), FileMode.Create))
                    {
                        BackBookImage.CopyTo(backImageStream);
                    }

                    obj.Book.BackBookUrl = @"\images\book\" + backImageFileName;
                }
                if (obj.Book.BookID == 0)
                {
                    _unitOfWork.Book.Add(obj.Book); //thêm Product
<<<<<<< HEAD
                   /* obj.Book.Seller = user;*/
=======
>>>>>>> 87e1d6fce1de7097e072e9e7cb0d97761aba3466
                    TempData["Success"] = "Product Create Successfully";
                }
                else
                {
                   
                    _unitOfWork.Book.Update(obj.Book); //update Product
                    TempData["Success"] = "Product Update Successfully";
                }
                obj.Book.Seller = user;
                _unitOfWork.Save(); // lưu lại product vào danh sách và lưu vào database
                return RedirectToAction("Index"); //trả lại trang category
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().
                           Select(u => new SelectListItem
                           {
                               Text = u.Name,
                               Value = u.Id.ToString()
                           });
                return View(obj);
            }
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Book? bookFromDb = _unitOfWork.Book.Get(u => u.BookID == id);
        //    //Book? bookFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //    //Book? bookFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

        //    if (bookFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(bookFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Book obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Book.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Book updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

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
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> books = _unitOfWork.Book.GetAll(includeProperty: "Category").ToList();
            return Json(new { data = books });
        }
        #endregion
    }
}