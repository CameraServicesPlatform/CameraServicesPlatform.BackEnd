using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CancelOrderRequest
    {
        public string OrderID {  get; set; }
        public string CancelMessage { get; set; }

    }
}
