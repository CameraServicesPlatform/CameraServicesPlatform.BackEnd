using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Policy
    {
    [Key]
    public Guid PolicyID { get; set; }

    public PolicyType PolicyType { get; set; }

    public string PolicyContent { get; set; }

    public DateTime EffectiveDate { get; set; }

    public Guid AccountID { get; set; }

    [ForeignKey(nameof(AccountID))]
    public Account User { get; set; }
}

