using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ReturnDetailMemberRequest
    {
        public Guid OrderID { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Condition { get; set; }
    }
}
