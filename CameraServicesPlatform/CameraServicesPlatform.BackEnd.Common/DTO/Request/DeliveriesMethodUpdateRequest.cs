using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class DeliveriesMethodUpdateRequest
    {
        public string DeliveriesMethodID { get; set; }
        public string DeliveriesMethodName { get; set; }
        public string OrderID { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
