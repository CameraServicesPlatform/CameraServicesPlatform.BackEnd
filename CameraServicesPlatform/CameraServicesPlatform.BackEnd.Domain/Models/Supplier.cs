using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Supplier
{
    [Key]
    public Guid SupplierID { get; set; }

    [ForeignKey(nameof(Account))]
    public string? AccountID { get; set; }
    public Account? Account { get; set; }

    public required string SupplierName { get; set; }

    public required string SupplierDescription { get; set; }
    public required string SupplierAddress { get; set; }

    [MaxLength(20)]
    public string? ContactNumber { get; set; }

    public required string SupplierLogo { get; set; }

    public string? BlockReason { get; set; }

    public DateTime? BlockedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public double AccountBalance { get; set; }

    public Guid? VourcherID { get; set; }

    [ForeignKey(nameof(VourcherID))]
    public Vourcher? Vourcher { get; set; }


}
