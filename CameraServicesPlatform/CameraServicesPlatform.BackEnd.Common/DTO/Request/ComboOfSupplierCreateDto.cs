using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class ComboOfSupplierCreateDto
    {
        public string ComboId { get; set; }

        public string? SupplierID { get; set; }
        public DateTime StartTime { get; set; }
    }
}
