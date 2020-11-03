﻿using Funeral.App.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.App.Services
{
    public interface IFileService
    {
        public Task<UploadFrameFilesViewModel> UploadFile(IFormFile imgFile, string targetDirectory);

        public void SaveFramePathToDb(string path);

        void SaveCrossPathToDb(string path);
    }
}
