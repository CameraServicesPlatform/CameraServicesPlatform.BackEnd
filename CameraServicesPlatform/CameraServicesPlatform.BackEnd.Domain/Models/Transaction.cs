   using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    [Key]
    public Guid TransactionID { get; set; }


    public Guid OrderID { get; set; }

    [ForeignKey(nameof(OrderID))]
    public Order Order { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public double Amount { get; set; }

    public TransactionType TransactionType { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }


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
