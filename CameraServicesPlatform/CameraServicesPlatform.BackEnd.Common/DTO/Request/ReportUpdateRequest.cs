using CameraServicesPlatform.BackEnd.Domain.Enum.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ReportUpdateRequest
    {
        public string? ReportId { get; set; }
        public string Message { get; set; }
    }
}
