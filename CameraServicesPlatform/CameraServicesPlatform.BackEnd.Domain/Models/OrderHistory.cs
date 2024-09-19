using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CameraServicesPlatform.BackEnd.Domain.Models;

public class OrderHistory
{
    [Key]
    public Guid OrderHistoryID { get; set; }

    [Required]
    public Guid MemberID { get; set; }

    [ForeignKey(nameof(MemberID))]
    public Member Member { get; set; }

    [Required]
    public Guid OrderID { get; set; }

    [ForeignKey(nameof(OrderID))]
    public Order Order { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

      public decimal TotalAmount { get; set; }

    [Required]
    public string OrderDetails { get; set; }

    [Required]
    public OrderStatus OrderStatus { get; set; }
}
