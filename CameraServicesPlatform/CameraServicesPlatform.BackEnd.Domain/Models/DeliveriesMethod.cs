using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class DeliveriesMethod
    {
        [Key]
        public Guid DeliveriesMethodID { get; set; }

        [Required]
        [MaxLength(100)]
        public string MethodName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
