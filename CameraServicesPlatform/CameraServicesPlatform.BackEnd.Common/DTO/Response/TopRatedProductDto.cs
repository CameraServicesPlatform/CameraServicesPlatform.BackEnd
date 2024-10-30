using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class TopRatedProductDto
    {
        public Guid ProductID { get; set; }
        public double AverageRating { get; set; }
        public int TotalRatings { get; set; }
    }
}
