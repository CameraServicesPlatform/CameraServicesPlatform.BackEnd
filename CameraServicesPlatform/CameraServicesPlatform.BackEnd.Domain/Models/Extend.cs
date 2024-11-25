using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Extend
    {
        [Key]
        public Guid ExtendId { get; set; }
        public Guid OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; }
        public RentalDurationUnit DurationUnit { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ExtendReturnDate { get; set; }
        public DateTime? RentalExtendStartDate { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? RentalExtendEndDate { get; set; }
        public bool IsDisable { get; set; }

    }
}
