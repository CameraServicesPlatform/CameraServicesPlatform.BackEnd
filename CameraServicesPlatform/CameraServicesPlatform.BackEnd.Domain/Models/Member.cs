using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Member
    {
        [Key]
        public Guid MemberID { get; set; }

        [ForeignKey(nameof(Account))]
        public string? AccountID { get; set; }

        public Account Account { get; set; }

        public DateTime JoinedAt { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Wishlist))]
        public Guid? WishlistID { get; set; }
        public Wishlist Wishlist { get; set; }

        [ForeignKey(nameof(OrderHistory))]
        public Guid? OrderHistoryID { get; set; }
        public OrderHistory OrderHistory { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid? OrderID { get; set; }
        public Order Order { get; set; }
    }
}
