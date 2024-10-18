using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class OrderDetailRequest
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public double ProductPrice { get; set; }

        [MaxLength(255)]
        public string ProductQuality { get; set; }
        public double Discount { get; set; }
        public double ProductPriceTotal { get; set; }
    }
}
