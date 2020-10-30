using Funeral.App.ViewModels;
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
        public Task<UploadFilesViewModel> UploadFile(IFormFile imgFile);

        public void SaveFramePathToDb(string path);
    }
}
