using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    public Guid PaymentID { get; set; }

    // Foreign key for Order
    [ForeignKey(nameof(Order))]
    public Guid? OrderID { get; set; }
    public Order Order { get; set; }

    // Foreign key for Supplier
    public Guid SupplierID { get; set; }
    public Supplier Supplier { get; set; }

    [ForeignKey(nameof(Account))]
    public string AccountID { get; set; }
    public Account Account { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public double PaymentAmount { get; set; }

    public PaymentType PaymentType { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public string PaymentDetails { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public string Image { get; set; }
    public Boolean IsDisable { get; set; }

}

