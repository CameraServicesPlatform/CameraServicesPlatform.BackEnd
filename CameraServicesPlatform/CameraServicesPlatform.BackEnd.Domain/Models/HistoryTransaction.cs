using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class HistoryTransaction
{
    [Key]
    public Guid HistoryTransactionId { get; set; }   
    public string AccountID { get; set; }
    public Guid? StaffID { get; set; }
    public double Price { get; set; }
    public string TransactionDescription { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
