using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateOrderRentRequest
    {
        public string SupplierID { get; set; }
        public string AccountID { get; set; }
        public string ProductID { get; set; }
        public double ProductPriceRent { get; set; }
        public string? VoucherID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double TotalAmount { get; set; }
        //public List<OrderProductRequest> Products { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        public double? Deposit { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public RentalDurationUnit DurationUnit { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ReturnDate { get; set; }
        //public List<OrderDetailRequest> OrderDetailRequests { get; set; } 
        public DeliveryStatus? DeliveryMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool? IsExtend { get; set; }
        public bool? IsPayment { get; set; }
        public double? ReservationMoney { get; set; }

    }
}
