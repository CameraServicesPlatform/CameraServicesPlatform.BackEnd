using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class CategoryDto
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

    }
}
