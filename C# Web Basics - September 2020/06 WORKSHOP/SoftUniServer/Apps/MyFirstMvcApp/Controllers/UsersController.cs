using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return View("Views/Users/Login.html");
        }

        public HttpResponse Register(HttpRequest request)
        {
            return View("Views/Users/Register.html");
        }
    }
}
