//using App_Dev_1670.Models;
//using App_Dev_1670.Models.ViewModels;
//using App_Dev_1670.Repository.IRepository;
//using Microsoft.AspNetCore.Mvc;

//namespace App_Dev_1670.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class SellerController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public SellerController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
//        {
//            _unitOfWork = unitOfWork;
//            _webHostEnvironment = webHostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            List<Seller> sellers = _unitOfWork.Seller.GetAll().ToList();

//            return View(sellers);
//        }

//        public IActionResult CreateUpdate(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                // Tạo mới
//                return View(new Seller()); 
//            }
//            else
//            {
//                // Chỉnh sửa
//                Seller sellerToUpdate = _unitOfWork.Seller.Get(u => u.SellerID == id);

//                return View(sellerToUpdate);
//            }
//        }

//        [HttpPost]
//        public IActionResult CreateUpdate(Seller obj, IFormFile? file)
//        {

//            //if (ModelState.IsValid)
//            //{
//            //    _unitOfWork.Seller.Add(obj);
//            //    _unitOfWork.Save();
//            //    TempData["success"] = "Seller created successfully";
//            //    return RedirectToAction("Index");
//            //}
//            if (ModelState.IsValid)
//            {
//                string wwwRootPath = _webHostEnvironment.WebRootPath;

//                if (file != null)
//                {
//                    // Xử lý frontimage
//                    string avatarFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//                    string avatarImagePath = Path.Combine(wwwRootPath, @"images\avatar");

//                    if (!string.IsNullOrEmpty(obj.Avatar))
//                    {
//                        // Xóa ảnh cũ
//                        var oldFrontImagePath = Path.Combine(wwwRootPath, obj.Avatar.TrimStart('\\'));
//                        if (System.IO.File.Exists(oldFrontImagePath))
//                        {
//                            System.IO.File.Delete(oldFrontImagePath);
//                        }
//                    }

//                    using (var frontImageStream = new FileStream(Path.Combine(avatarImagePath, avatarFileName), FileMode.Create))
//                    {
//                        file.CopyTo(frontImageStream);
//                    }

//                    obj.Avatar = @"\images\avatar\" + avatarFileName;
//                }

//                if (obj.SellerID == 0)
//                {
//                    _unitOfWork.Seller.Add(obj); //thêm Product
//                    TempData["Success"] = "Product Create Successfully";

//                }
//                else
//                {
//                    _unitOfWork.Seller.Update(obj); //update Product
//                    TempData["Success"] = "Product Update Successfully";

//                }
//                _unitOfWork.Save(); // lưu lại product vào danh sách và lưu vào database
//                return RedirectToAction("Index"); //trả lại trang category
//            }
//            return View(obj);
//        }
//        //public IActionResult Edit(int? id)
//        //{
//        //    if (id == null || id == 0)
//        //    {
//        //        return NotFound();
//        //    }
//        //    Seller? sellerFromDb = _unitOfWork.Seller.Get(u => u.SellerID == id);
//        //    //Seller? sellerFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
//        //    //Seller? sellerFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

//        //    if (sellerFromDb == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    return View(sellerFromDb);
//        //}
//        //[HttpPost]
//        //public IActionResult Edit(Seller obj)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _unitOfWork.Seller.Update(obj);
//        //        _unitOfWork.Save();
//        //        TempData["success"] = "Seller updated successfully";
//        //        return RedirectToAction("Index");
//        //    }
//        //    return View();

//        //}

//        public IActionResult Delete(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }
//            Seller? sellerFromDb = _unitOfWork.Seller.Get(u => u.SellerID == id);

//            if (sellerFromDb == null)
//            {
//                return NotFound();
//            }
//            return View(sellerFromDb);
//        }
//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeletePOST(int? id)
//        {
//            Seller? obj = _unitOfWork.Seller.Get(u => u.SellerID == id);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            _unitOfWork.Seller.Remove(obj);
//            _unitOfWork.Save();
//            TempData["success"] = "Seller deleted successfully";
//            return RedirectToAction("Index");
//        }
//    }
//}
