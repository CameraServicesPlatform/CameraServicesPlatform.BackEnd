using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Rating
    {
        [Key]
        public Guid RatingID { get; set; }

        public Guid ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; } 

        public Guid AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; } 

        public int RatingValue { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string ReviewComment { get; set; }
    }
}
