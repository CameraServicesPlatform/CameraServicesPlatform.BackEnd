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
        public Guid AccountID { get; set; }  // Add AccountID property

        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderType OrderType { get; set; }

        //rental
        public DateTime? RentalStartDate { get; set; }

        public DateTime? RentalEndDate { get; set; }

        // Thời gian tính theo  
        public RentalDurationUnit DurationUnit { get; set; } // Thời gian tính theo (giờ, ngày, tuần, tháng)
        // Số lượng của thời gian
        public int DurationValue { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? ShippingAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey(nameof(SupplierID))]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey(nameof(AccountID))]  // Fix the ForeignKey attribute
        public virtual Account Account { get; set; }

        // Foreign keys for related entities
        public Guid? OrderDetailID { get; set; }
        public Guid? ReturnDetailID { get; set; }
        public Guid? ContractID { get; set; }
        public Guid? TransactionID { get; set; }
        public Guid? DeliveriesMethodID { get; set; }

        // Navigation properties for single related entities
        [ForeignKey(nameof(OrderDetailID))]
        public virtual OrderDetail OrderDetail { get; set; }

        [ForeignKey(nameof(ReturnDetailID))]
        public virtual ReturnDetail ReturnDetail { get; set; }

        [ForeignKey(nameof(ContractID))]
        public virtual Contract Contract { get; set; }

        [ForeignKey(nameof(TransactionID))]
        public virtual Transaction Transaction { get; set; }

        [ForeignKey(nameof(DeliveriesMethodID))]
        public virtual DeliveriesMethod DeliveriesMethod { get; set; }
    }
}
