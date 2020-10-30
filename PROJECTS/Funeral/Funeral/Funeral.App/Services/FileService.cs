using Funeral.App.Data;
using Funeral.App.ViewModels;
using Funeral.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.App.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment webHost;
        private readonly ApplicationDbContext db;

        public FileService(IWebHostEnvironment webHost, ApplicationDbContext db)
        {
            this.webHost = webHost;
            this.db = db;
        }

        public void SaveFramePathToDb(string path)
        {
            var frame = new Frame
            {
                FilePath = path
            };

            db.Frames.Add(frame);
            db.SaveChanges();
        }

        public async Task<UploadFilesViewModel>  UploadFile(IFormFile imgFile)
        {
            var message = new UploadFilesViewModel();

            string imagePath = Path.Combine(webHost.WebRootPath, "Pictures/Frames", imgFile.FileName);

            string imageExt = Path.GetExtension(imgFile.FileName);

            if (imageExt != ".jpg" || imageExt != ".png" || imageExt != ".gif")
            {
                message.UploadMessage = "Невалиден файлов формат. Можете да качвате само .jpg, .png и .gif файлове!";               
            }

            using (var uploadImage = new FileStream(imagePath, FileMode.Create))
            {
                await imgFile.CopyToAsync(uploadImage);

                message.UploadMessage = $"Рамката {imgFile.FileName} е качена успешно.";
            }

            return message;
        }
    }
}
