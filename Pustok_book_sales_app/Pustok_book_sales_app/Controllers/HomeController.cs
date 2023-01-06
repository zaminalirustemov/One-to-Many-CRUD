using Microsoft.AspNetCore.Mvc;
using Pustok_book_sales_app.Models;
using Pustok_book_sales_app.ViewModel;
using System.Diagnostics;

namespace Pustok_book_sales_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _pustokDbContext;

        public HomeController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Heroes = _pustokDbContext.Heroes.ToList()
            };
            return View(homeViewModel);
        }

    }
}