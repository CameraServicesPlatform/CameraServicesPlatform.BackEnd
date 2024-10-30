using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class SupplierPaymentStatisticsDto
    {
        public double TotalRevenue { get; set; }
        public int PaymentCount { get; set; }
        public List<RevenueByMethodDto> RevenueByMethod { get; set; }
        public List<PaymentStatusCountDto> PaymentStatusCounts { get; set; }
        public List<MonthlyRevenueDto> MonthlyRevenue { get; set; }
    }

}
