using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductGetAllResponse
    {
        public string ProductID { get; set; }

        public string SerialNumber { get; set; }

        public string? SupplierID { get; set; }

        public string? CategoryID { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double? PriceBuy { get; set; }
        public double? DepositProduct { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public double? PricePerHour { get; set; }
        public int? CountRent { get; set; }
        public double? OriginalPrice { get; set; }
        public double? PricePerDay { get; set; }

        public double? PricePerWeek { get; set; }

        public double? PricePerMonth { get; set; }

        public BrandEnum? Brand { get; set; }

        public string Quality { get; set; }

        public ProductStatusEnum Status { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public List<ProductImage> listImage { get; set; } = null!;

    }
}
