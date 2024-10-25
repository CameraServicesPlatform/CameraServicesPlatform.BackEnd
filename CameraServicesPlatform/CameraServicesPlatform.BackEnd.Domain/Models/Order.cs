using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }


        public Guid SupplierID { get; set; }


        public string Id { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double? TotalAmount { get; set; }
        public OrderType OrderType { get; set; }

        // Rental properties
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public RentalDurationUnit DurationUnit { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ReturnDate { get; set; }

        public string? ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Supplier? Supplier { get; set; }
        public Account? Account { get; set; }

        public Guid? OrderDetailID { get; set; }
        public Guid? DeliveriesMethodID { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetail { get; set; }
        public DeliveriesMethod? DeliveriesMethod { get; set; }

        public Transaction? Transaction { get; set; }
    }
}
