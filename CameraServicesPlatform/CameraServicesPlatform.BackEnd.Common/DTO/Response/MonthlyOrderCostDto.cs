using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class MonthlyOrderCostDto
    {
        public DateTime Month { get; set; }
        public double TotalCost { get; set; }
    }
}
