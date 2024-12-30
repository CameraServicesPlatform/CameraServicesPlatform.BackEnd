using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateExtendRequest
    {
        public string OrderID { get; set; }
        public RentalDurationUnit DurationUnit { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ExtendReturnDate { get; set; }
        public DateTime? RentalExtendStartDate { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? RentalExtendEndDate { get; set; }
    }
}
