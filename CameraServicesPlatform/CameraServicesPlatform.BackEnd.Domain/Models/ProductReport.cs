﻿using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class ProductReport
    {
        [Key]
        public Guid ProductReportID { get; set; }

        public Guid SupplierID { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Supplier? Supplier { get; set; } // Made nullable

        public Guid ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product? Product { get; set; } // Made nullable

        public StatusType StatusType { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; }

        public string? Reason { get; set; } // Made nullable

        // Foreign key for the Account that handled this report
        [ForeignKey(nameof(Account))]
        public Guid? AccountID { get; set; }

        public Account? HandledBy { get; set; } // Made nullable

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}