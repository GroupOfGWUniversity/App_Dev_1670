using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Areas.User.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = SD.Role_Seller)]

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RequestCategory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Request.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category request successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<RequestCategory> objProductList = _unitOfWork.Request.GetAll().ToList();
            return Json(new { data = objProductList });
        }
        #endregion
    }
}
