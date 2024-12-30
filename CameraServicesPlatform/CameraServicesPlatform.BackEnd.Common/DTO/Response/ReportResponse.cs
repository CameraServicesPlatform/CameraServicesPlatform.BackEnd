using CameraServicesPlatform.BackEnd.Domain.Enum.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ReportResponse
    {
        public string ReportID { get; set; }

        public string? AccountId { get; set; }
        public ReportType ReportType { get; set; }
        public string ReportDetails { get; set; }
        public string? Message { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportStatus Status { get; set; }
    }
}
