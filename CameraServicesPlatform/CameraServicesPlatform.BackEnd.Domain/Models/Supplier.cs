using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Guid AccountID { get; set; }

        [Required]
        [MaxLength(255)]
        public string SupplierName { get; set; }

        public string SupplierDescription { get; set; }

        [MaxLength(255)]
        public string SupplierAddress { get; set; }

        [MaxLength(20)]
        public string? ContactNumber { get; set; }

        [MaxLength(255)]
        public string SupplierLogo { get; set; }

        public string? BlockReason { get; set; }

        public DateTime? BlockedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public decimal AccountBalance { get; set; }

        public Account Account { get; set; }

        public Guid? ProductID { get; set; }
        public Guid? HistoryTransactionID { get; set; }
        public Guid? PaymentID { get; set; }
        public Guid? VourcherID { get; set; }
        public Guid? SupplierRequestID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [ForeignKey(nameof(HistoryTransactionID))]
        public HistoryTransaction HistoryTransaction { get; set; }

        [ForeignKey(nameof(PaymentID))]
        public Payment Payment { get; set; }

        [ForeignKey(nameof(VourcherID))]
        public Vourcher Vourcher { get; set; }


        [ForeignKey(nameof(SupplierRequestID))]
        public SupplierRequest SupplierRequest { get; set; }

        // New relationship with SupplierDeliveriesMethod
        public Guid? SupplierDeliveriesMethodID { get; set; }

        [ForeignKey(nameof(SupplierDeliveriesMethodID))]
        public SupplierDeliveriesMethod SupplierDeliveriesMethod { get; set; }
    }
}
