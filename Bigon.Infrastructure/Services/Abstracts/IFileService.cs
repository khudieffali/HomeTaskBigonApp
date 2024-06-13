using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Services.Abstracts
{
    public interface IFileService
    {
         Task<string> UploadFileAsync(IFormFile filePath);
        Task<string> ChangeFileAsync(IFormFile filePath,string oldFileName,bool isArchive=false);

    }
}
