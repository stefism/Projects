using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");     
        }

        public HttpResponse BootstrapCss(HttpRequest request)
        {
            return File("wwwroot/css/bootstrap.min.css", "text/css");
        }

        public HttpResponse CustomCss(HttpRequest request)
        {
            return File("wwwroot/css/custom.css", "text/css");
        }

        public HttpResponse CustomJs(HttpRequest request)
        {
            return File("wwwroot/js/custom.js", "text/javascript");
        }

        public HttpResponse BootstrapJs(HttpRequest request)
        {
            return File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }
    }
}
