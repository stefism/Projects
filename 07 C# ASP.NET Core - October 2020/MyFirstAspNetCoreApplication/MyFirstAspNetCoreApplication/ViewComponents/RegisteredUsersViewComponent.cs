using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApplication.Data;
using MyFirstAspNetCoreApplication.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.ViewComponents
{
    public class RegisteredUsersViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public RegisteredUsersViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke(string title)
        {
            var viewModel = new RegisteredUsersViewModel
            {
                Title = title,
                Users = dbContext.Users.Count()
            };

            return View(viewModel);
        }
    }
}
