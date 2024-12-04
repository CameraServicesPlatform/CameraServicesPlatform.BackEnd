using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class UpdateSupplierRequestDTO
    {
        public Guid SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string SupplierDescription { get; set; }


        public string SupplierAddress { get; set; }

        [MaxLength(20)]
        public string? ContactNumber { get; set; }


        public IFormFile? SupplierLogo { get; set; }

    }
}
