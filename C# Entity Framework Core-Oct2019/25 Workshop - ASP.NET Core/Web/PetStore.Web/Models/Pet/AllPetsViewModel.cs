using PetStore.Services.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Models.Pet
{
    public class AllPetsViewModel
    {
        public IEnumerable<PetListingServiceModel> Pets { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => CurrentPage - 1;

        public int NaxtPage => CurrentPage + 1;
    }
}
