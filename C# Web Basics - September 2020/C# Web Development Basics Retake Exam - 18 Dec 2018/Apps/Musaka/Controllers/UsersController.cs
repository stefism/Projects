using Musaka.Services;
using Musaka.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace Musaka.Controllers
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

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = userService.GetUserId(username, password);

            if (userId == null)
            {
                return Error("Invalid username or/and password.");
            }

            SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(CreateUserInputModel model)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 6 || model.Username.Length > 20)
            {
                return Error("Invalid Username. Username should be between 6 and 20 characters long.");
            }

            if (!userService.IsUsernameAvailable(model.Username))
            {
                return Error("Username already exist.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                return Error("Invalid Email.");
            }

            if (!userService.IsEmailAvailable(model.Email))
            {
                return Error("Email already exist.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Error("Passwords is not match.");
            }

            userService.CreateUser(model);

            return Redirect("/Users/Login");
        }
    }
}
