using Bigon.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Services.Concretes
{
    public class FileService(IHostEnvironment hostEnvironment):IFileService
    {
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

        public async Task<string> UploadFileAsync(IFormFile  filePath)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(filePath.FileName)}";
            var phsycialPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "uploads", "images", fileName);
            using FileStream stream = new(phsycialPath, FileMode.CreateNew, FileAccess.Write);
            await filePath.CopyToAsync(stream);
            return fileName;
        }
        public async Task<string> ChangeFileAsync(IFormFile filePath, string oldFileName, bool isArchive = false)
        {
            if (filePath == null) return oldFileName;

            var folder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "uploads", "images");

            FileInfo fi = new(Path.Combine(folder, oldFileName));

            if (fi.Exists && isArchive)
            {
                var newfileName = $"archive-{oldFileName}";

                fi.MoveTo(Path.Combine(folder, newfileName));

            }
            else if (fi.Exists && !isArchive)
            {
                fi.Delete();
            }

            return await UploadFileAsync(filePath);

        }
    }
}
