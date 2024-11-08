using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class OrderDetailByOrderIDResponse
    {
        public string SupplierID { get; set; }
        public string? TransactionID { get; set; }
        public string OrderID { get; set; }
        public string AccountID { get; set; }
        public string? PaymentID { get; set; }
        public string? OrderDetailID { get; set; }

    }
}
