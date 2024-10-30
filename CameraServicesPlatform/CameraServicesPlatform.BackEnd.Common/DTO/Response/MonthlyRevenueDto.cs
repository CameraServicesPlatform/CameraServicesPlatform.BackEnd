using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class MonthlyRevenueDto
    {
        public int Month { get; set; }   
        public int Year { get; set; }    
        public double TotalRevenue { get; set; }  
    }
}
