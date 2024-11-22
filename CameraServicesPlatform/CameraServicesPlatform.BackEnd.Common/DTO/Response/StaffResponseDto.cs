using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class StaffResponseDto
    {
        public string StaffID { get; set; }
        public string Name { get; set; } = null!;
        public string AccountID { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string StaffStatus { get; set; }
        public AccountResponse Account { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsAdmin { get; set; }
        public string? Img { get; set; } = null!;
    }
}
