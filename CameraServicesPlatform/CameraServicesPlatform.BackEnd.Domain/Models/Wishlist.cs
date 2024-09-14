using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Wishlist
    {
        [Key]
        public Guid WishlistID { get; set; }

        [Required]
        public Guid MemberID { get; set; }

        [ForeignKey(nameof(MemberID))]
        public Member Member { get; set; }

        [Required]
        public Guid ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
