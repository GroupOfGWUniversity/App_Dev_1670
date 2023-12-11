using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Controllers
{
    public class SellerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Seller> sellers = _unitOfWork.Seller.GetAll().ToList();

            return View(sellers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Seller obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Seller.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Seller created successfully";
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
            Seller? sellerFromDb = _unitOfWork.Seller.Get(u => u.SellerID == id);
            //Seller? sellerFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Seller? sellerFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (sellerFromDb == null)
            {
                return NotFound();
            }
            return View(sellerFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Seller obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Seller.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Seller updated successfully";
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
            Seller? sellerFromDb = _unitOfWork.Seller.Get(u => u.SellerID == id);

            if (sellerFromDb == null)
            {
                return NotFound();
            }
            return View(sellerFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Seller? obj = _unitOfWork.Seller.Get(u => u.SellerID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Seller.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Seller deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
