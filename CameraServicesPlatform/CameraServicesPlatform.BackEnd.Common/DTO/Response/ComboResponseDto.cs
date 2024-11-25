using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ComboResponseDto
    {
        public string ComboId { get; set; }
        public string ComboName { get; set; }
        public double ComboPrice { get; set; }
        public bool IsDisable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
