using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateContractTemplateRequestDTO
    {
        public string TemplateName { get; set; }
        public string ContractTerms { get; set; }
        public string TemplateDetails { get; set; }
        public string PenaltyPolicy { get; set; }
        public Guid MemberID { get; set; }
    }
}
