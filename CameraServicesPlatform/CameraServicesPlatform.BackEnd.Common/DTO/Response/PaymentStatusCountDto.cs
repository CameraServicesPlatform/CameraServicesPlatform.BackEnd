using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class PaymentStatusCountDto
    {
        public PaymentStatus Status { get; set; }
        public int Count { get; set; }
    }
}
