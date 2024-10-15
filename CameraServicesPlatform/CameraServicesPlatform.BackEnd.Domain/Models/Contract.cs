using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contract
{
    [Key]
    public Guid ContractID { get; set; }

    public Guid ContractTemplateId { get; set; }
    [ForeignKey(nameof(ContractTemplateId))]
    // Navigation property for ContractTemplate
    public ContractTemplate ContractTemplate { get; set; }

    

    public string ContractTerms { get; set; }
    public string PenaltyPolicy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
