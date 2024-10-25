using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class DeliveriesMethodResponse
    {
        public string DeliveriesMethodID { get; set; }

        public DeliveryStatus MethodName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
