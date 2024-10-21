using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class DeliveriesMethodRequest
    {
        public string MethodName { get; set; }

        public string Description { get; set; }

        
    }
}
