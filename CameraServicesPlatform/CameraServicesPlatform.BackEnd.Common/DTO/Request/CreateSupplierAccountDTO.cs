using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateSupplierAccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SupplierName { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierAddress { get; set; }
        public string? ContactNumber { get; set; }
         public string PhoneNumber { get; set; } // Add this line
        public IFormFile? BackOfCitizenIdentificationCard { get; set; }
        public IFormFile? FrontOfCitizenIdentificationCard { get; set; }
        public required string? BankName { get; set; }
        public required string? AccountNumber { get; set; }
        public required string? AccountHolder { get; set; }

    }


}
