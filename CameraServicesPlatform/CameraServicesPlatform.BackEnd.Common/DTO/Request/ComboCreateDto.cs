using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ComboCreateDto
    {
        public string ComboName { get; set; }
        public double ComboPrice { get; set; }
        public DurationCombo? DurationCombo { get; set; }

    }
}
