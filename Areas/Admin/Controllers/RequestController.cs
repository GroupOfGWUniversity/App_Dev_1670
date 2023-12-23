using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class RequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<RequestCategory> categories = _unitOfWork.Request.GetAll().ToList();

            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            RequestCategory? categoryFromDb = _unitOfWork.Request.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //[HttpPost]
        //public IActionResult Edit(RequestCategory obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Request.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Request updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        [HttpPost]
        public IActionResult Edit(RequestCategory obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Status == StaticDetails.Accept)
                {
                    var newCategory = new Category { Name = obj.CategoryName };
                    _unitOfWork.Category.Add(newCategory);
                    obj.Status = StaticDetails.Accept; // Thay đổi giá trị ở đây
                }
                else
                {
                    obj.Status = StaticDetails.Denied; // Hoặc giá trị tương ứng cho trạng thái từ chối
                }
                _unitOfWork.Request.Update(obj);
                _unitOfWork.Save();

                TempData["success"] = "Request updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
