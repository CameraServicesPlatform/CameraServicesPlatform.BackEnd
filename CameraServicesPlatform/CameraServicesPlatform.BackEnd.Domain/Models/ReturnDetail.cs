﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class ReturnDetail
    {
        [Key]
        public Guid ReturnID { get; set; }


        public Guid OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; }

        public DateTime ReturnDate { get; set; }
        public string Condition { get; set; }

        public double PenaltyApplied { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDisable { get; set; }
    }
}
