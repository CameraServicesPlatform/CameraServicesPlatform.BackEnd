using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
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

    public int Quantity { get; set; }

    public ProductStatusEnum Status { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; }
}

