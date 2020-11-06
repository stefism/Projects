using Funeral.App.Data;
using Funeral.App.Services;
using Funeral.App.TempData;
using Funeral.App.ViewModels;
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
        private static Dictionary<string, TempData> tempData = new Dictionary<string, TempData>();

        private readonly IFramesService framesService;

        public MakeItController(IFramesService framesService)
        {
            this.framesService = framesService;            
        }

        public IActionResult MakeIt(string element)
        {
            var userName = User.Identity.Name;

            if (!tempData.ContainsKey(userName))
            {
                tempData[userName] = new TempData
                {
                    CurrentFrame = "/Pictures/Frames/frame1.gif"
                };
            }            

            var viewModel = new MakeItViewModel
            {
                CurrentFrame = tempData[userName].CurrentFrame,
                AllFrames = framesService.ShowAllFrames()
            };

            
            return View(viewModel);
        }
       
        public IActionResult ChangeFrame(string frameId)
        {
            var userName = User.Identity.Name;

            var framePath = framesService.GetFramePathById(frameId);

            tempData[userName].CurrentFrame = framePath;
            
            //var viewModel = new MakeItViewModel
            //{
            //    CurrentFrame = framePath,
            //    AllFrames = framesService.ShowAllFrames()
            //};

            return RedirectToAction("MakeIt");
        }
    }
}
