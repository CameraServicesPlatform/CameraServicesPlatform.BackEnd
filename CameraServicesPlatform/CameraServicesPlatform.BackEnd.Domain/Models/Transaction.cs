using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Transaction
{
    [Key]
    public Guid TransactionID { get; set; }

    [Required]
    public Guid OrderID { get; set; }

    [ForeignKey(nameof(OrderID))]
    public Order Order { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }

    public TransactionType TransactionType { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    [MaxLength(255)]
    public string? VNPAYTransactionID { get; set; }

    public VNPAYTransactionStatus? VNPAYTransactionStatus { get; set; }
    public DateTime? VNPAYTransactionTime { get; set; }

    // Foreign key to Bank
    [ForeignKey("Bank")]
    public Guid BankId { get; set; }
    public virtual BankInformation BankInformation { get; set; }

    // Foreign key to Member
    [ForeignKey("Member")]
    public Guid MemberId { get; set; }
    public virtual Member Member { get; set; }
}
