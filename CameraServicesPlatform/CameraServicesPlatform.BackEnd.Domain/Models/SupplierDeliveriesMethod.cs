using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class SupplierDeliveriesMethod
    {
        [Key]
        public Guid SupplierDeliveriesMethodID { get; set; }

        [Required]
        public Guid SupplierID { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Supplier Supplier { get; set; }

        [Required]
        public Guid DeliveriesMethodID { get; set; }

        [ForeignKey(nameof(DeliveriesMethodID))]
        public DeliveriesMethod DeliveriesMethod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
