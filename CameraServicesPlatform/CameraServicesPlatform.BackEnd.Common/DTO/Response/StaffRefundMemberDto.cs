using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class StaffRefundMemberDto
    {
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountHolder { get; set; }
        public string OrderId { get; set; }
        public double? RefundAmount { get; set; }

    }
}
