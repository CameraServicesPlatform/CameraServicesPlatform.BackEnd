using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class StaffRequestDTO
    {
        public string Name { get; set; } = null!;
        public string AccountID { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string StaffStatus { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsAdmin { get; set; }
        public IFormFile? Img { get; set; } = null!;
    }
}
