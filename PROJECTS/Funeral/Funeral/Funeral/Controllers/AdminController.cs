using Funeral.App.Services;
using Funeral.App.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Funeral.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFileService fileService;

        public AdminController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public IActionResult UploadFrame()
        {
            var model = new UploadFilesViewModel();
            model.UploadMessage = "Изберете файл за качване.";
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFrame(IFormFile imgFile)
        {
            var filePath = "/Pictures/Frames/" + imgFile.FileName;

            var model = await fileService.UploadFile(imgFile);

            fileService.SaveFramePathToDb(filePath);

            return RedirectToAction("MakeIt", "MakeIt");           
        }
    }
}
