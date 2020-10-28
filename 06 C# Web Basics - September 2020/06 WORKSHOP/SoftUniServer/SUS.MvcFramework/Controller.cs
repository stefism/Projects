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
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            string viewContent = System.IO.File
                .ReadAllText("Views/" + 
                GetType().Name.Replace("Controller", string.Empty) 
                + "/" + viewPath + ".cshtml");

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

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            //HttpStatusCode.Found = 302. 
            //При 302: POST -> 302 -> GET
            //HttpStatusCode.TemporaryRedirect = 307
            //При 307: POST -> 307 -> POST

            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}
