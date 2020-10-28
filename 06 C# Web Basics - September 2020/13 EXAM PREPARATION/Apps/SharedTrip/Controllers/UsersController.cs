using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

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
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            var userId = userService.GetUserId(username, password);

            if (userId == null)
            {
                return Error("Invalid username or password.");
            }

            SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

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
                return Error("Invalid email.");
            }

            if (!userService.IsEmailAvailable(email))
            {
                return Error("This email already exist.");
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            {
                return Error("Invalid password. Password should be between 6 and 20 characters.");
            }

            if (password != confirmPassword)
            {
                return Error("Passwords is not match.");
            }

            userService.CreateUser(username, password, email);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            SignOut();
            return Redirect("/");
        }
    }
}
