using SUS.HTTP;
using System.IO;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
        //Абстрактните класове не могат да се инстанцират но могат да се наследяват.
    {
        public HttpResponse View(string viewPath)
        {
            string responseHtml = File.ReadAllText(viewPath);

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
