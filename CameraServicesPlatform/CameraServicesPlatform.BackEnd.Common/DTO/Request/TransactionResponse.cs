using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class TransactionResponse
    {
        public string TransactionID { get; set; }

        public string OrderID { get; set; }

        public DateTime TransactionDate { get; set; } 
        public double Amount { get; set; }

        public TransactionType TransactionType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public string? VNPAYTransactionID { get; set; }

        public VNPAYTransactionStatus? VNPAYTransactionStatus { get; set; }
        public DateTime? VNPAYTransactionTime { get; set; }

    }
}
