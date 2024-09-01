using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class ProductImages
    {
        public Guid ProductImagesID { get; set; }
        public Guid ProductID { get; set; }
        public string Image { get; set; }

         public Product Product { get; set; }
    }
}
