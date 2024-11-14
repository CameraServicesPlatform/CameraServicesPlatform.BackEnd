using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class PaymentInformationRequest
    {
        public string OrderID { get; set; }
        public string SupplierID { get; set; }
        public string ProductID { get; set; }


        public string OrderInfo { get; set; }
        public string AccountID { get; set; }

        public string MemberName { get; set; }
        public double Amount { get; set; }
    }
}
