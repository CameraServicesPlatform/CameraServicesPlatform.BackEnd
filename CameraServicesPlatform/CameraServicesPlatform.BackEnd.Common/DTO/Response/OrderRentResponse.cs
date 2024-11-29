using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class OrderRentResponse
    {
        public string SupplierID { get; set; }
        public string OrderID { get; set; }
        public string AccountID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        public DeliveryStatus DeliveriesMethod { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
        public double? Deposit { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public RentalDurationUnit DurationUnit { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool? IsExtend { get; set; }
        public bool? IsPayment { get; set; }
        // Tiền giữ chỗ
        public double? ReservationMoney { get; set; }
    }
}
