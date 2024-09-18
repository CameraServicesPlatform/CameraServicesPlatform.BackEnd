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

        // Rental
        public DateTime? RentalStartDate { get; set; }

        public DateTime? RentalEndDate { get; set; }

        // Time duration
        public RentalDurationUnit DurationUnit { get; set; } // Time unit (hour, day, week, month)
        public int DurationValue { get; set; } // Quantity of time

        public DateTime? ReturnDate { get; set; }

        public string? ShippingAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey(nameof(Supplier))]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey(nameof(Member))]
        public virtual Member Member { get; set; }

        // Foreign keys for related entities
        public Guid? OrderDetailID { get; set; }
        public Guid? ReturnDetailID { get; set; }
        public Guid? ContractID { get; set; }
        public Guid? TransactionID { get; set; }
        public Guid? DeliveriesMethodID { get; set; }

        // Navigation properties for related entities
        [ForeignKey(nameof(OrderDetail))]
        public virtual OrderDetail OrderDetail { get; set; }

        [ForeignKey(nameof(ReturnDetail))]
        public virtual ReturnDetail ReturnDetail { get; set; }

        [ForeignKey(nameof(Contract))]
        public virtual Contract Contract { get; set; }

        [ForeignKey(nameof(TransactionID))]
        public virtual Transaction Transaction { get; set; }

        [ForeignKey(nameof(DeliveriesMethod))]
        public virtual DeliveriesMethod DeliveriesMethod { get; set; }
    }
}
