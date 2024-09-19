﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Contract
{
    [Key]
    public Guid ContractID { get; set; }
    [ForeignKey(nameof(Order))]

    public Guid OrderID { get; set; }

    public Order Order { get; set; }

    public string ContractTerms { get; set; }

    public string PenaltyPolicy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
