﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class ContractTemplate
    {
        [Key]
        public Guid ContractTemplateId { get; set; }

        [Required, MaxLength(255)]
        public string TemplateName { get; set; }

        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product  { get; set; }

        public string ContractTerms { get; set; }

        public string TemplateDetails { get; set; }

        public string PenaltyPolicy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key to Account
        public string AccountID { get; set; }
        [ForeignKey("AccountID")]

        public Account Account { get; set; }
    }
}
