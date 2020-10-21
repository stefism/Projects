using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.App.Controllers
{  
    public class HomeController : Controller
    { 
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/Trips/All");
            }

            return this.View();
        }
    }
}