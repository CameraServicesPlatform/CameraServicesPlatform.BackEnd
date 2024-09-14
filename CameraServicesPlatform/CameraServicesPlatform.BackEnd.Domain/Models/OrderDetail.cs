using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailsID { get; set; }

        [Required]
        public Guid OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }  

        [Required]
        public Guid ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }  

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }

        [Required]
        [MaxLength(255)] // Optional: Restrict string length
        public string ProductQuality { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPriceTotal { get; set; }

        public int? RentalPeriod { get; set; }
    }
}
