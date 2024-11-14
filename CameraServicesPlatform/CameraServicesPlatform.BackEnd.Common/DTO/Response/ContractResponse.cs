using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ContractResponse
    {
        public string ContractID { get; set; }
        public string OrderID { get; set; }
        public string TemplateDetails { get; set; }
        public string ContractTerms { get; set; }
        public string PenaltyPolicy { get; set; }
    }
}
