using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class SupplierPaymentAgainDto
    {
        public string? OrderID { get; set; } = Guid.NewGuid().ToString();
        public string SupplierID { get; set; }
        public double Amount { get; set; }

    }
}
