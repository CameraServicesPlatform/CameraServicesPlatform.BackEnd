using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contract
{
    [Key]
    public Guid ContractID { get; set; }

    [ForeignKey(nameof(Order))]
    public Guid OrderID { get; set; }
    public Order Order { get; set; }

    public Guid ContractTemplateId { get; set; }
    [ForeignKey("ContractTemplateId")]
    public ContractTemplate ContractTemplate { get; set; }
    public string ContractTerms { get; set; }
    public string TemplateDetails { get; set; }
    public string PenaltyPolicy { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
}
