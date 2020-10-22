using SUS.HTTP;
using SUS.MvcFramework;

namespace Musaka.Controllers
{
    public class ProductsController : Controller
    {
        public HttpResponse OrderProducts()
        {
            return View();
        }
    }
}
