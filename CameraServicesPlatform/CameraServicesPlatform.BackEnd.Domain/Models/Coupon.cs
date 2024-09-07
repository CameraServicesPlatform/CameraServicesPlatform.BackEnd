using CameraServicesPlatform.BackEnd.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Coupon
    {
        [Key]
        [Required]
        public Guid CouponID { get; set; }

        [Required]
        public Guid SupplierID { get; set; }

        [Required]
        [MaxLength(50)]
        public string CouponCode { get; set; }
        public string Description { get; set; }

        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        [Column(TypeName = "ENUM('Percentage', 'Fixed')")]
        public DiscountType DiscountType { get; set; }

        public int? MaxUsageLimit { get; set; }

        public int? UsagePerCustomer { get; set; }

        public decimal? MinOrderAmount { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey(nameof(SupplierID))]
        public virtual Supplier Supplier { get; set; }
    }
}
