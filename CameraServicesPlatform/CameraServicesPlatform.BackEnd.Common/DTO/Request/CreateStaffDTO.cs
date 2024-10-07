using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateStaffDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string JobTitle { get; set; }

         public string Department { get; set; }

         public string StaffStatus { get; set; }

         public DateTime HireDate { get; set; }

         public bool IsAdmin { get; set; }

         public IFormFile Img { get; set; }
    }
}
