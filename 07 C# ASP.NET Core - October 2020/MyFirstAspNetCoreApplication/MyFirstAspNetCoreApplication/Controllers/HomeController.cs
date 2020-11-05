using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApplication.Data;
using MyFirstAspNetCoreApplication.Models;
using MyFirstAspNetCoreApplication.ViewModels.Home;

namespace MyFirstAspNetCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, IConfiguration configuration)
        {
            //IConfiguration configuration - използва се за четене на настройките от appsettings.json
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var viewModel = new IndexViewModel
            {
                Year = DateTime.UtcNow.Year,
                Id = id,
                Name = "Stefan",
                ProcessorCount = Environment.ProcessorCount,
                UsersCount = dbContext.Users.Count(),
                Descripton = "Това е дескрипшън."
            };

            return View(viewModel);
            return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StatusCodeError(int errorCode)
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
