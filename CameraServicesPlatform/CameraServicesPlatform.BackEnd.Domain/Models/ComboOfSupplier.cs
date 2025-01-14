﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class ComboOfSupplier
    {
        [Key]
        public Guid ComboOfSupplierId { get; set; }
        public Guid ComboId { get; set; }
        [ForeignKey(nameof(ComboId))]
        public Combo? Combo { get; set; }
        public Guid? SupplierID { get; set; }
        [ForeignKey(nameof(SupplierID))]
        public Supplier? Supplier { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? IsMailNearExpired { get; set; }
        public bool? IsSendMailExpired { get; set; }


        public bool IsDisable { get; set; }
    }
}
