using CameraServicesPlatform.BackEnd.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Vourcher
    {
        [Key]
        public Guid VourcherID { get; set; }

        public Guid? SupplierID { get; set; }

        [MaxLength(50)]
        public string VourcherCode { get; set; }

        public string Description { get; set; }


        public double DiscountAmount { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
