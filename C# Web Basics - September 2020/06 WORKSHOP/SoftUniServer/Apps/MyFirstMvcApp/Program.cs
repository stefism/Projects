using SUS.HTTP;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);
            await server.StartAsync(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            string responseHtml = "<h1>Welcome</h1>"
                + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            byte[] fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");

            var responce = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return responce;
        }

        static HttpResponse About(HttpRequest request)
        {
            string responseHtml = "<h1>About ...</h1>";

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse Login(HttpRequest request)
        {
            string responseHtml = "<h1>Login ...</h1>";

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
