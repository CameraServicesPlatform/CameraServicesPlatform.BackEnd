using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class HistoryTransaction
    {
    [Key]
    public Guid HistoryTransactionId { get; set; }

    public Guid SupplierID { get; set; }

    [ForeignKey(nameof(SupplierID))]
    public Supplier Shop { get; set; }

    public decimal Price { get; set; }

    [MaxLength(255)]
    public string TransactionDescription { get; set; }

    public Enum.Transaction.TransactionStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}

