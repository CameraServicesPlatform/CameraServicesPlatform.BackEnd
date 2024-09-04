using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Order
    {
    [Key]
    public Guid OrderID { get; set; }

    public Guid UserID { get; set; }

    [ForeignKey(nameof(UserID))]
    public User User { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderType OrderType { get; set; }

    public DateTime? RentalStartDate { get; set; }

    public DateTime? RentalEndDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? ShippingAddress { get; set; }

    public DeliveryMethod DeliveryMethod { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    public virtual Contract Contract { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }

    public virtual ReturnDetail ReturnDetail { get; set; }
}

