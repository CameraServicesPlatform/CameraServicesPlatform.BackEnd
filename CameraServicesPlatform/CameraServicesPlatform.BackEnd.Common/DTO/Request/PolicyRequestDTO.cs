using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class PolicyRequestDTO
    {
        public PolicyType PolicyType { get; set; }
        public string PolicyContent { get; set; }
        public ApplicableObject ApplicableObject { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime Value { get; set; }
    }
}
