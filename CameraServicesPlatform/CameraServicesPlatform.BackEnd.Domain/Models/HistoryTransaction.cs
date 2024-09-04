using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class HistoryTransaction
    {
    [Key] public Guid HistoryTransactionId { get; set; }
        public Guid ShopID { get; set; }
        public decimal Price { get; set; }
        public string? TransactionDescription { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Shop Shop { get; set; }
    }

