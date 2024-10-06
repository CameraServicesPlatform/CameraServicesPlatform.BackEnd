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
    public class ProductReportUpdateDto
    {
        
        public Guid ProductReportID { get; set; }

        public StatusType StatusType { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Reason { get; set; }
    }
}
