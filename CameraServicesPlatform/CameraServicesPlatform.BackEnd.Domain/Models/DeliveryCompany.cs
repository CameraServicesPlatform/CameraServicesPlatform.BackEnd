using System;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class DeliveryCompany
    {
        [Key]
        public Guid DeliveryCompanyID { get; set; }

        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; }

        [MaxLength(500)]
        public string ContactInfo { get; set; }

         public virtual Delivery Delivery { get; set; }
    }
}
