using Funeral.App.Data;
using Funeral.App.Services;
using Funeral.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funeral.Web.Controllers
{
    public class MakeItController : Controller
    {
        private readonly IFramesService framesService;

        public MakeItController(IFramesService framesService)
        {
            this.framesService = framesService;
        }

        public IActionResult MakeIt(string element)
        {

            var model = framesService.ShowAllFrames();
                       
            return View(model);
        }
    }
}
