using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
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

        [MaxLength(255)]
        public string? VNPAYResponseCode { get; set; }

        public VNPAYTransactionStatus VNPAYTransactionStatus { get; set; }

        public DateTime? VNPAYTransactionTime { get; set; }

        [MaxLength(255)]
        public string? VNPAYOrderInfo { get; set; }

        [MaxLength(255)]
        public string? VNPAYChecksum { get; set; }
    }
}
