using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IFirebaseService
    {
        Task<AppActionResult> UploadFileToFirebase(IFormFile file, string pathFileName);

        public Task<string> GetUrlImageFromFirebase(string pathFileName);

        public Task<AppActionResult> DeleteFileFromFirebase(string pathFileName);
        //public Task<List<IFormFile>> GetFilesAsFormFilesAsync(List<string> fileUrls);
    }
}
