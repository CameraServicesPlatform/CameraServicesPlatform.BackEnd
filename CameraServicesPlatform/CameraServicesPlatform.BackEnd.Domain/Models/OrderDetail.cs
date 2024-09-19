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
        public virtual Order Order { get; set; }

        [Required]
        public Guid ProductID { get; set; }

         [ForeignKey(nameof(ProductID))]
        public virtual Product Product { get; set; }

        [Required]
         public decimal ProductPrice { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductQuality { get; set; }

        [Required]
         public decimal Discount { get; set; }

        [Required]
         public decimal ProductPriceTotal { get; set; }

        public int? RentalPeriod { get; set; }
    }
}
