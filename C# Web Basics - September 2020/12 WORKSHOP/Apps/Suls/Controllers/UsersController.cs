using Suls.Services;
using Suls.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace Suls.Controllers
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
                return Error("Invalid username or passwors");
            }

            SignIn(userId); // Write in the current session of the current user that this userId has logged in. Записваме в текущата сесия на текущия потребител, че този юзър ай ди се е логнал. Така следващата заявка ще знае кой е юзър ай ди то. Сесията пренася информацията между заявките.

            return Redirect("/");
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (string.IsNullOrEmpty(inputModel.Username) || inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return Error("Invalid username. Username should be between 5 and 20 characters.");
            }

            if (!userService.IsUsernameAvailable(inputModel.Username))
            {
                return Error("This username already exist.");
            }

            if (string.IsNullOrEmpty(inputModel.Email)
                || !new EmailAddressAttribute().IsValid(inputModel.Email))
            {
                return Error("Invalid email.");
            }

            if (!userService.IsEmailAvailable(inputModel.Email))
            {
                return Error("This email already exist.");
            }

            if (string.IsNullOrEmpty(inputModel.Password) || inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return Error("Invalid password. Password should be between 6 and 20 characters.");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return Error("Passwords do not match.");
            }

            userService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            SignOut();
            return Redirect("/");
        }
    }
}
