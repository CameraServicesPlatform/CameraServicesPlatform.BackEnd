using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class SupplierTransactionStatisticsDto
    {
        public double TotalRevenue { get; set; }
        public int TransactionCount { get; set; }
        public List<RevenueByTransactionTypeDto> RevenueByTransactionType { get; set; }
        public List<RevenueByMethodDto> RevenueByMethod { get; set; }
        public List<TransactionStatusCountDto> TransactionStatusCounts { get; set; }
        public List<MonthlyRevenueDto> MonthlyRevenue { get; set; }
    }
}
