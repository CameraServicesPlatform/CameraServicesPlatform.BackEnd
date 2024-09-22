using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ProductRequestDto
    {
        public string SerialNumber { get; set; }

        public string SupplierName { get; set; }
        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double Price { get; set; }


        public string? Brand { get; set; }

        public string Quality { get; set; }

        public ProductStatusEnum Status { get; set; }
        
    }
}
