using CameraServicesPlatform.BackEnd.Domain.Enum.Report;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ReportRequest
    {
        public string? AccountId { get; set; }
        public ReportType ReportType { get; set; }
        public string ReportDetails { get; set; }
    }
}
