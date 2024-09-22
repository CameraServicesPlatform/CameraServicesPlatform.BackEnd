using CameraServicesPlatform.BackEnd.Domain.Enum.Report;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Report
    {
        [Key]
        public Guid ReportID { get; set; }
        
        [ForeignKey(nameof(Account))]
        public string? AccountId { get; set; }
        public Account? Account { get; set; }

        public ReportType ReportType { get; set; }

        public string ReportDetails { get; set; }

        public DateTime ReportDate { get; set; } = DateTime.UtcNow;

        public ReportStatus Status { get; set; }
    }
}
