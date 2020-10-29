using Microsoft.AspNetCore.Mvc;
using MyFirstAspApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspApp.Controllers
{
    public class DataViewModel
    {
        public int UserCount { get; set; }

        public string ParameterValue { get; set; }
    }

    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ArticlesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult ById(string name)
        {
            var viewModel = new DataViewModel();
            viewModel.UserCount = dbContext.Users.Count();
            viewModel.ParameterValue = name;

            return View(viewModel);
        }
    }
}
