using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateOrderRentRequest
    {
        public Guid SupplierID { get; set; }
        public Guid MemberID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderType OrderType { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ReturnDate { get; set; }
        public List<OrderDetailRequest> OrderDetailRequests { get; set; } 
        public CreateContractRequestDTO ContractRequest {  get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
