using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductSpecificationResponse
    {
        public string ProductSpecificationID { get; set; }

        public string Specification { get; set; }

        public string? Details { get; set; }
    }
}
