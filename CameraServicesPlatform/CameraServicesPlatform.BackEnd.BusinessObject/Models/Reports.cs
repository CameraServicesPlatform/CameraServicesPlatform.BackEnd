using CameraServicesPlatform.BackEnd.BusinessObject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class Reports
    {
        public Guid ReportID { get; set; }
        public Guid UserID { get; set; }
        public ReportType ReportType { get; set; }
        public string ReportDetails { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportStatus Status { get; set; }

         public User User { get; set; }
    }
}
