using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Delivery
    {
        [Key]
        public Guid DeliveryID { get; set; }

        [Required]
        public Guid OrderID { get; set; }

        [Required]
        public Guid DeliveryCompanyID { get; set; }

        [Required]
        [MaxLength(255)]
        public string DeliveryTrackingNumber { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public DeliveryStatus DeliveryStatus { get; set; }

        [Required]
        [MaxLength(500)]  
        public string DeliveryAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(DeliveryCompanyID))]
        public virtual DeliveryCompany DeliveryCompany { get; set; }
    }
}
