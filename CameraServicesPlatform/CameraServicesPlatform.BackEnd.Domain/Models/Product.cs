using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public Guid ProductID { get; set; }

    public Guid SupplierID { get; set; }

    [ForeignKey(nameof(SupplierID))]
    public Supplier Supplier { get; set; }

    public Guid CategoryID { get; set; }

    [ForeignKey(nameof(CategoryID))]
    public Category Category { get; set; }

    [MaxLength(255)]
    public string ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public decimal Price { get; set; }

    [MaxLength(255)]
    public string? Brand { get; set; }

    public string Quality { get; set; }

    public ProductStatusEnum Status { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Thêm liên kết đến RentalPrice
    public Guid? RentalPriceID { get; set; }

    [ForeignKey(nameof(RentalPriceID))]
    public RentalPrice RentalPrice { get; set; }
}
