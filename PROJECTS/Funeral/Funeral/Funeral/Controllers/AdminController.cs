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
        private readonly IWebHostEnvironment webHost;

        public AdminController(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }

        public IActionResult UploadFrame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFrame(IFormFile imgFile)
        {
            string imagePath = Path.Combine(webHost.WebRootPath, "Pictures/Frames", imgFile.FileName);

            string imageExt = Path.GetExtension(imgFile.FileName);

            if (imageExt != ".jpg" || imageExt != ".png" || imageExt != ".gif")
            {
                ViewData["Message"] = "Невалиден файлов формат. Можете да качвате само .jpg, .png и .gif файлове!";
            }

            using (var uploadImage = new FileStream(imagePath, FileMode.Create))
            {
                await imgFile.CopyToAsync(uploadImage);
                
                ViewData["Message"] = "Рамката " + imgFile.FileName + " е качена успешно.";
            }

            return View();
        }
    }
}
