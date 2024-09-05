using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Supplier
{
    [Key]
    public Guid SupplierID { get; set; }

    public Guid AccountID { get; set; }

    [ForeignKey(nameof(AccountID))]
    public Account User { get; set; }

    [MaxLength(255)]
    public string ShopName { get; set; }

    public string? ShopDescription { get; set; }

    [MaxLength(255)]
    public string? ShopAddress { get; set; }

    [MaxLength(20)]
    public string? ContactNumber { get; set; }

    [MaxLength(255)]
    public string? ShopLogo { get; set; }

    public ShopStatus ShopStatus { get; set; }

    public string? BlockReason { get; set; }
    public DateTime? BlockedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public decimal AccountBalance { get; set; }

    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<HistoryTransaction> HistoryTransactions { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}

