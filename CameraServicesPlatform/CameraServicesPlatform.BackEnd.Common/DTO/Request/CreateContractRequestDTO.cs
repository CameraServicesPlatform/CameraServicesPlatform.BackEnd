using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateContractRequestDTO
    {
        public Guid ContractTemplateId { get; set; }
        public Guid OrderID { get; set; }
        public string ContractTerms { get; set; }
        public string PenaltyPolicy { get; set; }
    }
}
