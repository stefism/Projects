using Microsoft.AspNetCore.Mvc;
using PetStore.Web.Models.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class PetsController : Controller
    {
        public IEnumerable<PetListingResponseModel> All2()
        {
            return new List<PetListingResponseModel> 
            {
                new PetListingResponseModel
                {
                    Id = 5,
                    Name = "Ivan",
                    Breed = "Kokoska",
                    Price = 10
                },

                new PetListingResponseModel
                {
                    Id = 5,
                    Name = "Pesho",
                    Breed = "Kokoska",
                    Price = 15
                },
            };
        }
    }
}
