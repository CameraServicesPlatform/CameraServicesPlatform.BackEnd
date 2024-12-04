using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class SupplierOrderStatisticsDto
    {
        public double TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int CanceledOrders { get; set; }
        public int ApprovedOrders { get; set; }
        public int PlacedOrders { get; set; }
        public int ShippedOrders { get; set; }
        public int PaymentFailOrders { get; set; }
        public int CancelingOrders { get; set; }
        public int PaymentOrders { get; set; }
        public int PendingRefundOrders { get; set; }
        public int RefundOrders { get; set; }
        public int DepositReturnOrders { get; set; }
        public int ExtendOrders { get; set; }
    }
}
