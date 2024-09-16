using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentID { get; set; }

        public Guid? OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; } 

        public Guid SupplierID { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Supplier Supplier { get; set; } 

        public Guid? AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; } 

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public decimal PaymentAmount { get; set; }

        public PaymentType PaymentType { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string PaymentDetails { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(255)]
        public string Image { get; set; }
    }
}
