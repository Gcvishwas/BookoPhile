using BookoPhile.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookoPhile.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
