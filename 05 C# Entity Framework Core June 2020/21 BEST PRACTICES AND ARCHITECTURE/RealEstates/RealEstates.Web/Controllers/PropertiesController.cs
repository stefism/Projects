using Microsoft.AspNetCore.Mvc;
using RealEstates.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);
            
            return View(properties);
        }
    }
}
