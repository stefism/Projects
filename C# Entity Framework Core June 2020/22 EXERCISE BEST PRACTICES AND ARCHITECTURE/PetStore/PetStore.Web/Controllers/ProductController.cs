using Microsoft.AspNetCore.Mvc;
using PetStore.Services.Contracts;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var allProducts = productService.GetAllProducts();

            return View(allProducts);
        }
    }
}
