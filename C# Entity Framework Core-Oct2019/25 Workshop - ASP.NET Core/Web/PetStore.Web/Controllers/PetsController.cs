using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Pet;
using PetStore.Web.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
        {
            this.pets = pets;
        }

        public IActionResult All(int page = 1)
        {
            var allPets = pets.All(page);

            var model = new AllPetsViewModel
            {
                Pets = allPets,
                CurrentPage = page
            };

            return View(model);
        }
    }
}
