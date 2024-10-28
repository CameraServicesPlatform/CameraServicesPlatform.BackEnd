using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class BestSellingCategoryDto
    {
        public string CategoryID { get; set; } 
        public string CategoryName { get; set; } 
        public int TotalSold { get; set; } 
    }
}
