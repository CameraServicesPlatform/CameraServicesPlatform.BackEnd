using CameraServicesPlatform.BackEnd.Domain.Enum.Report;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Report
    {
        [Key]
        public Guid ReportID { get; set; }

        public Guid AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; } 

        public ReportType ReportType { get; set; }

        public string ReportDetails { get; set; }

        public DateTime ReportDate { get; set; } = DateTime.UtcNow;

        public ReportStatus Status { get; set; }
    }
}
