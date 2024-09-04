using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Contracts
    {
    [Key] public Guid ContractID { get; set; }
        public string ContractTerms { get; set; }
        public string PenaltyPolicy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Orders Order { get; set; }
    }

