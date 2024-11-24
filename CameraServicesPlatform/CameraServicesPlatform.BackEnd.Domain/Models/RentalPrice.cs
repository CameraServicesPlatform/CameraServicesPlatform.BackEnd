using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RentalPrice
{
    [Key]
    public Guid RentalPriceID { get; set; }


    public Guid ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }
    public double? PricePerHour { get; set; }


    public double? PricePerDay { get; set; }

    public double? PricePerWeek { get; set; }

    public double? PricePerMonth { get; set; }

    public DateTime CreatedAt { get; set; } 

    public DateTime UpdatedAt { get; set; } 
}
