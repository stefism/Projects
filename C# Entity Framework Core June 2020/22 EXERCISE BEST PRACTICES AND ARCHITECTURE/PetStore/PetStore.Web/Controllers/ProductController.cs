using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services.Contracts;
using PetStore.Services.ViewModels;
using PetStore.Web.Models;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult All()
        {
            var allProducts = productService.GetAllProducts();

            return View(allProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }
            
            productService.AddProduct(model);

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ListAllProductsViewModel serviceModel = 
                productService.GetById(id);

            return View(serviceModel);
        }
    }
}
