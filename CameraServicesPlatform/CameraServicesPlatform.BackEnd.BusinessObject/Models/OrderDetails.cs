using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class OrderDetails
    {
        public Guid OrderDetailsID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuality { get; set; }
        public decimal Discount { get; set; }
        public decimal ProductPriceTotal { get; set; }
        public int RentalPeriod { get; set; }

         public Orders Order { get; set; }
        public Product Product { get; set; }
    }
}
