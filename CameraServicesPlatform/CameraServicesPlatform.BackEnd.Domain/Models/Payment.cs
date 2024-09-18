using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentID { get; set; }

        // Foreign key for Order
        [ForeignKey(nameof(Order))]
        public Guid? OrderID { get; set; }
        public Order Order { get; set; }

        // Foreign key for Supplier
        [ForeignKey(nameof(Supplier))]
        public Guid SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        // Adjust foreign key to match the type of Account's primary key
        [ForeignKey(nameof(Account))]
        public string AccountID { get; set; } // Changed to string
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
