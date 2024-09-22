using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Rating
    {
        [Key]
        public Guid RatingID { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }

        public Product Product { get; set; }

        [ForeignKey(nameof(Account))]
        public string AccountID { get; set; }

        public Account Account { get; set; }

        public int RatingValue { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string ReviewComment { get; set; }
    }
}
