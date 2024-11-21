using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class StaffRefundDto
    {
        public string? OrderID { get; set; } 
        public string? AccountId { get; set; }
        public string StaffId { get; set; }
        public double? Amount { get; set; }


    }
}
