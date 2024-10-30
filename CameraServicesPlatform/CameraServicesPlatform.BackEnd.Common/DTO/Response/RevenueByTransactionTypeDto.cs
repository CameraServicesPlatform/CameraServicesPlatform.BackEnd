using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class RevenueByTransactionTypeDto
    {
        public TransactionType TransactionType { get; set; }
        public double TotalRevenue { get; set; }
        public int TransactionCount { get; set; }
    }
}
