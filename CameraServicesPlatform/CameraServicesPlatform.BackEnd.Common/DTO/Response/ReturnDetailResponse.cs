using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ReturnDetailResponse
    {
        public string ReturnID { get; set; }
        public string OrderID { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Condition { get; set; }
        public double PenaltyApplied { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
