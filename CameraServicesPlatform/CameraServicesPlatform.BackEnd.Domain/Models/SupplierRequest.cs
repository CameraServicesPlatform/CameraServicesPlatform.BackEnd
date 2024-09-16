using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class SupplierRequest
    {
        [Key]
        public Guid SupplierRequestID { get; set; }

        [Required]
        public Guid SupplierID { get; set; }

        public RequestType RequestType { get; set; }

        [Required]
        public string RequestDetails { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(SupplierID))]
        public Supplier Supplier { get; set; }
    }
}
