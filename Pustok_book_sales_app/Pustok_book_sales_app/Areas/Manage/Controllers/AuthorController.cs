using Microsoft.AspNetCore.Mvc;
using Pustok_book_sales_app.Models;

namespace Pustok_book_sales_app.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AuthorController : Controller
    {
        private readonly PustokDbContext _pustokDbContext;

        public AuthorController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;
        }

        //Read-----------------------------------
        public IActionResult Index()
        {
            List<Author> authors = _pustokDbContext.Authors.ToList();
            return View(authors);
        }


        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid) return View();

            _pustokDbContext.Authors.Add(author);
            _pustokDbContext.SaveChanges();

            return RedirectToAction("index");
        }



        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Author author = _pustokDbContext.Authors.Find(id);

            if (author is null) return View("Error");

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author newAuthor)
        {
            Author existAuthor = _pustokDbContext.Authors.Find(newAuthor.Id);

            if (existAuthor is null) return View("Error");

            existAuthor.FullName = newAuthor.FullName;

            _pustokDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete-------------------------------------

        public IActionResult Delete(int id)
        {
            Hero hero = _pustokDbContext.Heroes.Find(id);
            if (hero is null) return View("Error");
            return View(hero);
        }

        [HttpPost]
        public IActionResult Delete(Hero hero)
        {
            if (!ModelState.IsValid) return View("Error");

            _pustokDbContext.Heroes.Remove(hero);
            _pustokDbContext.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
