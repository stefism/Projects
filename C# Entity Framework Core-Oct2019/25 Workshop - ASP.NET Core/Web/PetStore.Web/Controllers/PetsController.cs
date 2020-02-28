using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class PetsController : Controller
    {
        public string[] All()
        {
            return new[] { "Pesho", "Gosho" };
        }
    }
}
