using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Transactions
    {
        public Guid TransactionID { get; set; }
        public Guid OrderID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string VNPAYTransactionID { get; set; }
        public string VNPAYResponseCode { get; set; }
        public VNPAYTransactionStatus VNPAYTransactionStatus { get; set; }
        public DateTime? VNPAYTransactionTime { get; set; }
        public string VNPAYOrderInfo { get; set; }
        public string VNPAYChecksum { get; set; }

        public Orders Order { get; set; }
    }

