using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_MVC.Controllers
{
    public class StefanController : Controller
    {
        public IActionResult Hello()
        {
            ViewBag.Rand = new Random().Next(1, 101);
            return View();
        }
    }
}