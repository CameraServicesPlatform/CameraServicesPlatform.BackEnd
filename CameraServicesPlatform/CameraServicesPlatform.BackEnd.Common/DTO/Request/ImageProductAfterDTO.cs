using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ImageProductAfterDTO
    {
        public IFormFile? Img { get; set; }
        public string OrderID {  get; set; }
    }
}
