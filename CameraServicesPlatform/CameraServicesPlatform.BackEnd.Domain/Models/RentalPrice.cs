using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class RentalPrice
{
    [Key]
    public Guid RentalPriceID { get; set; }

    [Required]
    public Guid ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

     public decimal PricePerDay { get; set; }

    public decimal? PricePerWeek { get; set; }

    public decimal? PricePerMonth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
