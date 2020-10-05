using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            byte[] fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");

            var responce = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return responce;
        }
    }
}
