using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/Cards/All");
            }

            return View();
        }

        //public HttpResponse About()
        //{
        //    SignIn("Stefan");
        //    return View();
        //}
    }
}
