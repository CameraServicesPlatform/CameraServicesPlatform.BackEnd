using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Guid? OrderID { get; set; }

        public Order Order { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Guid SupplierID { get; set; }

        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Guid? AccountID { get; set; }

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
