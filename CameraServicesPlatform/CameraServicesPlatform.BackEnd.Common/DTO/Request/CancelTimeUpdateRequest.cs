using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CancelTimeUpdateRequest
    {
        public CancelDurationUnit CancelDurationUnit { get; set; }
        public int CancelVaule { get; set; }
    }
}
