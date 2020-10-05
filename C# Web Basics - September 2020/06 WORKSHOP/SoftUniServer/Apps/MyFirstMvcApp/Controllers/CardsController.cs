using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest request)
        {
            return View("Views/Cards/Add.html");
        }

        public HttpResponse All(HttpRequest request)
        {
            return View("Views/Cards/All.html");
        }

        public HttpResponse Collection(HttpRequest request)
        {
            return View("Views/Cards/Collection.html");
        }
    }
}
