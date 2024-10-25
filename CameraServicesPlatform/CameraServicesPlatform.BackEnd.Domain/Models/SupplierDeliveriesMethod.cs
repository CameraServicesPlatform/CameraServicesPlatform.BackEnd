using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;

public class SupplierDeliveriesMethod
{
    [Key]
    public Guid SupplierDeliveriesMethodID { get; set; }


    public Guid SupplierID { get; set; } // Foreign key property
    public Supplier Supplier { get; set; } // Navigation property


    public Guid DeliveriesMethodID { get; set; } // Foreign key property
    public DeliveriesMethod DeliveriesMethod { get; set; } // Navigation property

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Boolean IsDisable { get; set; }
}

