using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Wishlist
{
    [Key]
    public Guid WishlistID { get; set; }


    public string AccountID { get; set; }

    [ForeignKey(nameof(AccountID))]
    public Account Account { get; set; }


    public Guid ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
