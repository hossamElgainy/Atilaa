using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices.SystemIServices
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
        Task<List<string>> UploadListOfFilesAsync(List<IFormFile>? files, string folderName);
        Task DeleteFileAsync(string fileName, string folderName);
    }
}
