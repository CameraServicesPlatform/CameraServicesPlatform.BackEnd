using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;

public class HistoryTransaction
{
    [Key]
    public Guid HistoryTransactionId { get; set; }

    public Guid SupplierID { get; set; }

    [ForeignKey(nameof(SupplierID))]
    public Supplier Supplier { get; set; }

    public decimal Price { get; set; }

    [MaxLength(255)]
    public string TransactionDescription { get; set; }

    public TransactionStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
