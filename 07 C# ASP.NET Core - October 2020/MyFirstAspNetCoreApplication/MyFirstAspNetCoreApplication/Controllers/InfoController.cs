using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApplication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    [AddHeaderActionFilter] //Слагаме филтъра тук като атрибут на класа и така го инстанцираме локално.
    public class InfoController : Controller
    {
        public IActionResult Time()
        {
            return Content(DateTime.Now.ToLongTimeString());
        }

        //Филтъра може да се прилага и само върху конкретен екшън.
        public IActionResult Date()
        {
            return Content(DateTime.Now.ToLongDateString());
        }
    }
}
