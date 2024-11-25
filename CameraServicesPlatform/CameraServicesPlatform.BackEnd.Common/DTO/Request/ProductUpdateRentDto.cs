using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ProductUpdateRentDto
    {
        public string ProductID { get; set; }

        public string SerialNumber { get; set; }

        public string? CategoryID { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }
        public double? DepositProduct { get; set; }


        public double? PricePerHour { get; set; }


        public double? PricePerDay { get; set; }

        public double? PricePerWeek { get; set; }

        public double? PricePerMonth { get; set; }

        public BrandEnum? Brand { get; set; }

        public string Quality { get; set; }

        public ProductStatusEnum Status { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public double? OriginalPrice { get; set; }

        public IFormFile? File { get; set; }
        public List<string> listProductSpecification { get; set; } = new List<string>();
    }
}
