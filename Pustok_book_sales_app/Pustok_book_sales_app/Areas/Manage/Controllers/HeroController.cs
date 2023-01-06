using Microsoft.AspNetCore.Mvc;
using Pustok_book_sales_app.Models;

namespace Pustok_book_sales_app.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HeroController : Controller
    {
        private readonly PustokDbContext _pustokDbContext;

        public HeroController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;
        }

        //Read-----------------------------------
        public IActionResult Index()
        {
            List<Hero> heroList = _pustokDbContext.Heroes.ToList();
            return View(heroList);
        }


        //Create---------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hero hero)
        {
            if (!ModelState.IsValid) return View();

            _pustokDbContext.Heroes.Add(hero);
            _pustokDbContext.SaveChanges();

            return RedirectToAction("index");
        }



        //Edit-------------------------------------

        public IActionResult Edit(int id)
        {
            Hero hero = _pustokDbContext.Heroes.Find(id);

            if (hero is null) return View("Error");

            return View(hero);
        }

        [HttpPost]
        public IActionResult Edit(Hero newHero)
        {
            Hero existHero = _pustokDbContext.Heroes.Find(newHero.Id);

            if (existHero is null) return View("Error");

            existHero.ImageUrl = newHero.ImageUrl;
            existHero.TitleUp = newHero.TitleUp;
            existHero.TitleDown = newHero.TitleDown;
            existHero.Description = newHero.Description;
            existHero.Price = newHero.Price;

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
