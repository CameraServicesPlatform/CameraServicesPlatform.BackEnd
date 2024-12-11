using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateOrderBuyRequest
    {
        public string SupplierID { get; set; }
        public string AccountID { get; set; }
        public string? VourcherID { get; set; }

        public string ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        //public List<OrderDetailRequest> OrderDetailRequests { get; set; }
        public DeliveryStatus? DeliveryMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
