using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
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

    public double? PriceRent { get; set; }
    public double? PriceBuy { get; set; }

    public double? DepositProduct { get; set; }


    public BrandEnum? Brand { get; set; }

    public string Quality { get; set; }

    public ProductStatusEnum Status { get; set; }

    public double Rating { get; set; }

    public DateTime CreatedAt { get; set; } 

    public DateTime UpdatedAt { get; set; } 

}
