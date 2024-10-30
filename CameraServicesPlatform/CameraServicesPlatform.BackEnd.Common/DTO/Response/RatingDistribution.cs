using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class RatingDistribution
    {
        public int RatingValue { get; set; } // Giá trị đánh giá (1-5 sao)
        public int Count { get; set; }       // Số lượng đánh giá cho giá trị này
    }
}
