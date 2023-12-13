//﻿using App_Dev_1670.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace App_Dev_1670.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//﻿using App_Dev_1670.Models;
//using App_Dev_1670.Repository.IRepository;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace App_Dev_1670.Areas.Customer.Controllers
//{
//    [Area("User")]
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly IUnitOfWork _unitOfWork;

//        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
//        {
//            _logger = logger;
//            _unitOfWork = unitOfWork;
//        }

//        public IActionResult Index()
//        {
//            IEnumerable<Book> productList = _unitOfWork.Book.GetAll(includeProperty: "Category");
//            return View(productList);
//        }

//        public IActionResult Details(int productId)
//        {
//            Book product = _unitOfWork.Book.Get(u => u.CategoryID == productId, includeProperty: "Category");
//            return View(product);
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
//}