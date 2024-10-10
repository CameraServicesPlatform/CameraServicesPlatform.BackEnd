using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class OrderDetailResponse
    {
        public string OrderDetailsID { get; set; } 
        public string OrderID { get; set; } 
        public string ProductID { get; set; } 
        public string ProductName { get; set; } 
        public decimal ProductPrice { get; set; } 
        public string ProductQuality { get; set; } 
        public decimal Discount { get; set; }
        public decimal ProductPriceTotal { get; set; } 
        public int? RentalPeriod { get; set; } 

        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
