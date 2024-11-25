using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using Microsoft.AspNetCore.Http;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductResponseDto
    {
        public string SerialNumber { get; set; }

         public string SupplierID { get; set; }

        public string CategoryID { get; set; }
 

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }
        public string Quality { get; set; }

        public double? PriceRent { get; set; }
        public double? PriceBuy { get; set; }

        public BrandEnum? Brand { get; set; }

        public ProductStatusEnum Status { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public double? OriginalPrice { get; set; }


        public IFormFile? File { get; set; }
        
        public List<string> listProductSpecification { get; set; }  = new List<string>();
    }

    
}
