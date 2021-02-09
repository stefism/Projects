using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApiAndAjaxDemo.Models;

namespace WebApiAndAjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjaxDemo()
        {
            return View();
        }

        public IActionResult AjaxDemoData()
        {
            return Json(new[] {
              new  { Name = "Niki2", Date = DateTime.UtcNow.ToString("O")},
              new  { Name = "Stoyan2", Date = DateTime.UtcNow.AddDays(1).ToString("O")},
              new  { Name = "Pesho2", Date = DateTime.UtcNow.AddDays(2).ToString("O")},
            });
        }

        public IActionResult Privacy()
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
