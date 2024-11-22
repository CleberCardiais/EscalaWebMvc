using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EscalaWebMvc.Models;

namespace EscalaWebMvc.Controllers
{
    public class FuncController : Controller
    {
        public IActionResult Index()
        {
            List<Func> list = new List<Func>();
            list.Add(new Func { Id = 1, Name = "Cleber Cardiais" });
            list.Add(new Func { Id = 2, Name = "Bruna de Sá" });
            list.Add(new Func { Id = 3, Name = "Francisco Gago" }); ;

            return View(list);
        }
    }
}
