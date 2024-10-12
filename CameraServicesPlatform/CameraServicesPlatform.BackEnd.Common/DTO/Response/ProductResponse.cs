using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductResponse
    {
        public string ProductID { get; set; }
        public string SerialNumber { get; set; }

        public string? SupplierID { get; set; }

        public string? CategoryID { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double? PriceRent { get; set; }
        public double? PriceBuy { get; set; }



        public BrandEnum? Brand { get; set; }

        public string Quality { get; set; }

        public ProductStatusEnum Status { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

 
        public List<string>? Image { get; set; } = new List<string>();
 
    }
}
