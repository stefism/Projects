﻿using Funeral.App.Data;
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

        public void SaveCrossPathToDb(string path)
        {
            var cross = new Cross
            {
                FilePath = path
            };

            db.Crosses.Add(cross);
            db.SaveChanges();
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

        public async Task<UploadFrameFilesViewModel>  UploadFile(IFormFile imgFile, string targetDirectory)
        {
            var message = new UploadFrameFilesViewModel();

            string imagePath = Path.Combine(webHost.WebRootPath, targetDirectory, imgFile.FileName);
            // -> "Pictures/Frames"

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
