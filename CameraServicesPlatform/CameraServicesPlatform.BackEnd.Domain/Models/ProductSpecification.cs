using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class ProductSpecification
    {
        [Key]
        public Guid ProductSpecificationID { get; set; }

        public Guid ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [MaxLength(255)]
        public string Specification { get; set; }

        public string? Details { get; set; }
    }
}
