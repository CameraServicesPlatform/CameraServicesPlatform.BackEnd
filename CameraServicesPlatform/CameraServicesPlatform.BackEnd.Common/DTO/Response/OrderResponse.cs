using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Models;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class OrderResponse
    {
        public string SupplierID { get; set; }
        public string OrderID { get; set; }
        public string AccountID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
    }
}
