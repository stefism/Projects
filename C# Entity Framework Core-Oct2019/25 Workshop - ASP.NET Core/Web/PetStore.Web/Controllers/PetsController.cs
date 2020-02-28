using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Pet;
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

        public IActionResult All()
        {
            var allPets = pets.All();

            return View(allPets);
        }
    }
}
