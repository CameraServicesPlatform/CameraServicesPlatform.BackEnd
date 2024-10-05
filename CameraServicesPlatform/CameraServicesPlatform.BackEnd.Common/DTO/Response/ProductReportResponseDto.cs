using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductReportResponseDto
    {
        public Guid SupplierID { get; set; }

        public Guid ProductID { get; set; }

        public StatusType StatusType { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; }

        public string? Reason { get; set; }

        // Foreign key for the Account that handled this report
        [ForeignKey(nameof(Account))]
        public Guid? AccountID { get; set; }


        
    }
}
