using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Supplier
{
    [Key]
    public Guid SupplierID { get; set; }
    public Guid AccountID { get; set; }


    [ForeignKey(nameof(AccountID))]
    public Account Account { get; set; }

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
    public SupplierStatus SupplierStatus { get; set; }

    public string? BlockReason { get; set; }
    public DateTime? BlockedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public decimal AccountBalance { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<HistoryTransaction> HistoryTransactions { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Coupon> Coupons { get; set; }
    public ICollection<Delivery> Deliveries { get; set; }
    public ICollection<SupplierStatus> SupplierStatuses { get; set; }
    public ICollection<SupplierRequest> SupplierRequests { get; set; }
}

