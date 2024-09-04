using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Payment
{
    [Key]
    public Guid PaymentID { get; set; }

    public Guid ShopID { get; set; }

    [ForeignKey(nameof(ShopID))]
    public Shop Shop { get; set; }

    public Guid? OrderID { get; set; }

    [ForeignKey(nameof(OrderID))]
    public Order? Order { get; set; }

    public Guid? UserID { get; set; }

    [ForeignKey(nameof(UserID))]
    public User? User { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public PaymentType PaymentType { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public string? PaymentDetails { get; set; }

    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
