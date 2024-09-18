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
        [ForeignKey(nameof(SupplierID))]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey(nameof(MemberID))]
        public virtual Member Member { get; set; }

        // Foreign keys for related entities
        public Guid? OrderDetailID { get; set; }
        public Guid? ReturnDetailID { get; set; }
        public Guid? ContractID { get; set; }  // Foreign key for Contract
        public Guid? TransactionID { get; set; }
        public Guid? DeliveriesMethodID { get; set; }

        // Navigation properties for related entities
        [ForeignKey(nameof(OrderDetailID))]
        public   OrderDetail OrderDetail { get; set; }

        [ForeignKey(nameof(ReturnDetailID))]
        public   ReturnDetail ReturnDetail { get; set; }

        [ForeignKey(nameof(ContractID))]  // Use the correct foreign key property here
        public   Contract Contract { get; set; }

        [ForeignKey(nameof(TransactionID))]
        public   Transaction Transaction { get; set; }

        [ForeignKey(nameof(DeliveriesMethodID))]
        public   DeliveriesMethod DeliveriesMethod { get; set; }
    }
}
