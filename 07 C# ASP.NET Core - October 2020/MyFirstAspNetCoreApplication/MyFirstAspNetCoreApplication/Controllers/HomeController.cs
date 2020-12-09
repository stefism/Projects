using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApplication.Data;
using MyFirstAspNetCoreApplication.Models;
using MyFirstAspNetCoreApplication.ViewModels.Home;
using System;
using System.Diagnostics;
using System.Linq;

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
                ReadPrivacy = HttpContext.Session.Keys.Contains("ReadPrivacy"),
                ProcessorCount = Environment.ProcessorCount,
                UsersCount = dbContext.Users.Count(),
                Descripton = "Това е дескрипшън."
            };

            return View(viewModel);
            return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
        }

        public IActionResult Privacy()
        {
            //Ползване на сесия:
            HttpContext.Session.SetString("ReadPrivacy", "true"); //SetString е екстеншън метод и трябва да се добави юзинг към Microsoft.AspNetCore.Http;
            return View();
        }

        // [ValidateAntiForgeryToken] //Ако не го регистрираме глобално, го пишем за всеки екшън, който приема форма с пост заявка.
        // Глобално -> StartUp -> ConfigureServices -> configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); //Задължително във всяко приложение за да се предпазим от крос сайт рекуест форджъри атака!
        public IActionResult AjaxDemo()
        {
            return View();
        }

        public IActionResult AjaxDemoData()
        {
            return Json(new[] {
            new { Name = "Niki2", Date = DateTime.UtcNow.ToString("O")},
            new { Name = "Stoyan2", Date = DateTime.UtcNow.AddDays(1).ToString("O")},
            new { Name = "Stefan", Date = DateTime.UtcNow.AddDays(2).ToString("O")},
            });
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
