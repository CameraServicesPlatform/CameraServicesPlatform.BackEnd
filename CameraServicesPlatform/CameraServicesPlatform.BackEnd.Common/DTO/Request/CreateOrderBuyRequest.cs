﻿using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateOrderBuyRequest
    {
        public Guid SupplierID { get; set; }
        public Guid MemberID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        public List<OrderDetailRequest> OrderDetailRequests { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
