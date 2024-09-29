using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class OrderResponse
    {
        public Guid SupplierID { get; set; }
        public Guid MemberID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
    }
}
