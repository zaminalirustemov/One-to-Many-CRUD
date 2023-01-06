using Microsoft.AspNetCore.Mvc;
using Pustok_book_sales_app.Models;

namespace Pustok_book_sales_app.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly PustokDbContext _pustokDbContext;

        public BookController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;
        }

        //Read-----------------------------------
        public IActionResult Index()
        {
            List<Book> books = _pustokDbContext.Books.ToList();
            return View(books);
        }


        //Create---------------------------------
        public IActionResult Create()
        {
            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            ViewBag.Category = _pustokDbContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {

            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            ViewBag.Category = _pustokDbContext.Categories.ToList();

            if (!ModelState.IsValid) return View();

            _pustokDbContext.Books.Add(book);
            _pustokDbContext.SaveChanges();

            return RedirectToAction("index");
        }



        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {

            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            ViewBag.Category = _pustokDbContext.Categories.ToList();
            Book book = _pustokDbContext.Books.Find(id);

            if (book is null) return View("Error");

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book newBook)
        {

            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            ViewBag.Category = _pustokDbContext.Categories.ToList();
            Book existBook = _pustokDbContext.Books.Find(newBook.Id);

            if (existBook is null) return View("Error");

            existBook.AuthorId = newBook.AuthorId;
            existBook.CategoryId = newBook.CategoryId;
            existBook.Name = newBook.Name;
            existBook.Description = newBook.Description;
            existBook.CostPrice = newBook.CostPrice;
            existBook.DiscountPrice = newBook.DiscountPrice;
            existBook.SalePrice = newBook.SalePrice;
            existBook.IsAvailable = newBook.IsAvailable;
            existBook.Code = newBook.Code;

            _pustokDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            ViewBag.Category = _pustokDbContext.Categories.ToList();
            Book book = _pustokDbContext.Books.Find(id);
            if (book is null) return View("Error");
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            ViewBag.Category = _pustokDbContext.Categories.ToList();
            if (!ModelState.IsValid) return View("Error");

            _pustokDbContext.Books.Remove(book);
            _pustokDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
