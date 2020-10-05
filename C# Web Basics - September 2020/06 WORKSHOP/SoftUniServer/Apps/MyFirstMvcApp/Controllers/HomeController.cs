using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            string responseHtml = "<h1>Welcome</h1>"
                + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse About(HttpRequest request)
        {
            string responseHtml = "<h1>About ...</h1>";

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
