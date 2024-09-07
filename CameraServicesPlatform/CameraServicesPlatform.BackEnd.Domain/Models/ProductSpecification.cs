using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class ProductSpecification
{
    [Key]
    public Guid ProductSpecificationsID { get; set; }

    public Guid ProductID { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }

    public string? Detail { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

}

