using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }

        [Required]
        public Guid SupplierID { get; set; }

        [Required]
        public Guid MemberID { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
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

        public virtual Supplier Supplier { get; set; }
        public virtual Member Member { get; set; }

        public Guid? OrderDetailID { get; set; }
        public Guid? DeliveriesMethodID { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual DeliveriesMethod DeliveriesMethod { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
