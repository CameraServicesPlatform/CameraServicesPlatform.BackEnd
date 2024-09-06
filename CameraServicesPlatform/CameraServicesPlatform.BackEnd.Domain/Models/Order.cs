using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Order
{
    [Key]
    public Guid OrderID { get; set; }

    [Required]
    public Guid SupplierID { get; set; }

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
    //
    public   Supplier Supplier { get; set; }     
    public Account Account { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public ICollection<ReturnDetail> ReturnDetails { get; set; }
    public ICollection<Contract> Contracts { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Delivery> Deliveries { get; set; }
}

