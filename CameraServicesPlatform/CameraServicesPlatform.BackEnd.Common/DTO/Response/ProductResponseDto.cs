using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductResponseDto
    {
        public string SerialNumber { get; set; }

         public Guid SupplierID { get; set; }

        public Guid CategoryID { get; set; }
 

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double? PriceRent { get; set; }
        public double? PriceBuy { get; set; }

        public BrandEnum? Brand { get; set; }

        public ProductStatusEnum Status { get; set; }

    }
}
