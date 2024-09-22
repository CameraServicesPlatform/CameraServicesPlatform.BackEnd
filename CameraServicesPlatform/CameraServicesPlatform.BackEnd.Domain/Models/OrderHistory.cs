using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderHistory
{
    [Key]
    public Guid OrderHistoryID { get; set; }


    public Guid MemberID { get; set; }

    [ForeignKey(nameof(MemberID))]
    public Member Member { get; set; }


    public Guid OrderID { get; set; }

    [ForeignKey(nameof(OrderID))]
    public Order Order { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public double TotalAmount { get; set; }


    public string OrderDetails { get; set; }


    public OrderStatus OrderStatus { get; set; }
}
