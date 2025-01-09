using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ProductReportRequest
    {
        public string ProductReportID { get; set; }
        public string? Message { get; set; }

    }
}
