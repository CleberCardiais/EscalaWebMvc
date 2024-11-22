using EscalaWebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EscalaWebMvc.Models.ViewModels;

namespace EscalaWebMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Func()
        {
            return View();
        }

        public IActionResult Area()
        {
            return View();
        }

        public IActionResult Calendario()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
