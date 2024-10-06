using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class RatingRequest
    {
        public Guid ProductID { get; set; }
        public Guid AccountID { get; set; }
        public int RatingValue { get; set; }
        public string ReviewComment { get; set; }
    }
}
