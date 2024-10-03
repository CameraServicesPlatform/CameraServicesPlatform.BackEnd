using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public Guid ProductID { get; set; }
    public string SerialNumber { get; set; }

    public Guid? SupplierID { get; set; }


    [ForeignKey(nameof(SupplierID))]
    public Supplier? Supplier { get; set; }

    public Guid? CategoryID { get; set; }

    [ForeignKey(nameof(CategoryID))]
    public Category? Category { get; set; }


    public string ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public double Price { get; set; }


    public string? Brand { get; set; }

    public string Quality { get; set; }

    public ProductStatusEnum Status { get; set; }

    public double Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
