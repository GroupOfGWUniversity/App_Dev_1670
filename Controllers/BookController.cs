using App_Dev_1670.Data;
using App_Dev_1670.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Controllers
{
	public class BookController : Controller
	{
		private ApplicationDatabase _db;
		public BookController(ApplicationDatabase db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Book> objProductList = _db.Books.ToList();
			return View(objProductList);
		}

	}
}
