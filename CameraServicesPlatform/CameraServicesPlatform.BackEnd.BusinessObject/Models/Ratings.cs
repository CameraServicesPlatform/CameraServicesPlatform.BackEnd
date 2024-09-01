using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class Ratings
    {
        public Guid RatingID { get; set; }
        public Guid ProductID { get; set; }
        public Guid UserID { get; set; }
        public int RatingValue { get; set; }  
        public string ReviewComment { get; set; }
        public DateTime CreatedAt { get; set; }

         public Product Product { get; set; }
        public User User { get; set; }
    }
}
