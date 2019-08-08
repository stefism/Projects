using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutOne(int start = 5, int end = 10)
        {
            List<int> nums = new List<int>();

            for (int i = start; i <= end; i++)
            {
                nums.Add(i);
            }

            ViewBag.Nums = nums;

            ViewBag.Start = start;
            ViewBag.End = end;

            return View();
        }

        public IActionResult Numbers()
        {
            ViewBag.Nums = "1 2 3 4 5";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
