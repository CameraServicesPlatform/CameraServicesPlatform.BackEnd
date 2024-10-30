using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class SystemRatingStatisticsDto
    {
        public int TotalRatings { get; set; }
        public double AverageRating { get; set; }
        public List<RatingDistribution> RatingDistribution { get; set; }
        public List<TopRatedProductDto> TopRatedProducts { get; set; }
    }
}
