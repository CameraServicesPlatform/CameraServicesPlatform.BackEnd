using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class UploadImgResponseDto
    {
        public string url { get; set; }
        public IFormFile file { get; set; }
    }
}
