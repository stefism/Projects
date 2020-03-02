using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Web.Models.Categories;

namespace PetStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult All()
        {
            var categories = categoryService.All()
                .Select(csm => new CategoryListingViewModel()
                {
                    Id = csm.Id,
                    Name = csm.Name
                }).ToArray();

            return View(categories);
        }
    }
}