using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class Contracts
    {
        public Guid ContractID { get; set; }  
        public string ContractTerms { get; set; }
        public string PenaltyPolicy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Orders Order { get; set; }
    }
}
