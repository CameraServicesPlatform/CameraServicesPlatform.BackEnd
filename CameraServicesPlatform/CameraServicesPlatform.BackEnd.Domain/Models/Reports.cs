using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Reports
    {
    [Key] public Guid ReportID { get; set; }
        public Guid UserID { get; set; }
        public ReportType ReportType { get; set; }
        public string ReportDetails { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportStatus Status { get; set; }

        public User User { get; set; }
    }

