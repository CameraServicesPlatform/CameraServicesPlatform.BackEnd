using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contract
{
    [Key]
    public Guid ContractID { get; set; }

    // Foreign key to Order
    [ForeignKey(nameof(Order))]
    public Guid OrderID { get; set; }

    [ForeignKey(nameof(ContractTemplate))]
    public Guid ContractTemplateId { get; set; }
    // Navigation property for Order
    public Order Order { get; set; }
    public ContractTemplate ContractTemplate { get; set; }

    public string ContractTerms { get; set; }
    public string PenaltyPolicy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
