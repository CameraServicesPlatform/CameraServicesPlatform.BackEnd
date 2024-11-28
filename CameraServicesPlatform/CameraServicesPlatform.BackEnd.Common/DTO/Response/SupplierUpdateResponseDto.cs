using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class SupplierUpdateResponseDto
    {
        public Guid SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string SupplierDescription { get; set; }


        public string SupplierAddress { get; set; }

        [MaxLength(20)]
        public string? ContactNumber { get; set; }


        public IFormFile ? SupplierLogo { get; set; }

        public string? BlockReason { get; set; }
        public Boolean IsDisable { get; set; }

        public DateTime? BlockedAt { get; set; }

    }
}
