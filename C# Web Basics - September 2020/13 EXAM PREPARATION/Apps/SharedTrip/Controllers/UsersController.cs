using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            return View();
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password,  string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 20)
            {
                return Error("Invalid username. Username should be between 5 and 20 characters.");
            }

            if (!userService.IsUsernameAvailable(username))
            {
                return Error("This username already exist.");
            }

            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return Error("This email already exist.");
            }

            userService.CreateUser(username, password, email);

            return Redirect("Users/Login");
        }
    }
}
