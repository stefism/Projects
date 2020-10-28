using Musaka.Services;
using Musaka.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Musaka.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public HttpResponse OrderProducts()
        {
            var viewModel = productService.ShowOrders(GetUserId());
            
            return View(viewModel);
        }

        [HttpPost]
        public HttpResponse OrderProducts(long barcode, int quantity)
        {
            var userId = GetUserId();

            productService.AddOrder(barcode, quantity, userId);

            return Redirect("/Products/OrderProducts");
        }

        public HttpResponse Create()
        {           
            return View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProductInputModel inputModel)
        {
            productService.CreateProduct(inputModel);
            
            return Redirect("/Products/All");
        }

        public HttpResponse All()
        {
            var viewModel = productService.ShowAllProducts();
            
            return View(viewModel);
        }
    }
}
