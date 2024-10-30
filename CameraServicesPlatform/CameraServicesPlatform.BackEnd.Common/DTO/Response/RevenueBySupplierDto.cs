using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class RevenueBySupplierDto
    {
        public Guid SupplierID { get; set; }
        public double TotalRevenue { get; set; }
        public int PaymentCount { get; set; }
        public int? TransactionCount { get; set; }

    }
}
