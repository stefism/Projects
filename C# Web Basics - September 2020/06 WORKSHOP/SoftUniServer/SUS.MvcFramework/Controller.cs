using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    //Абстрактните класове не могат да се инстанцират но могат да се наследяват.
    {
        public HttpResponse View
            ([CallerMemberName]string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.html");

            string viewContent = System.IO.File
                .ReadAllText("Views/" + 
                GetType().Name.Replace("Controller", string.Empty) 
                + "/" + viewPath + ".html");

            var responseHtml = layout
                .Replace("@RenderBody()", viewContent);

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            var responce = new HttpResponse(contentType, fileBytes);

            return responce;
        }
    }
}
