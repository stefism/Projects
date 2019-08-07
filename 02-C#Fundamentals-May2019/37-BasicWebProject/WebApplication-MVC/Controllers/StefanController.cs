using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_MVC.Controllers
{
    public class StefanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}