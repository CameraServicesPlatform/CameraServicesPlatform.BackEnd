using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailsID { get; set; }


        public Guid OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; }


        public Guid ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual Product Product { get; set; }

        public double ProductPrice { get; set; }


        public string ProductQuality { get; set; }

        public double Discount { get; set; }

        public double ProductPriceTotal { get; set; }

        public DateTime? PeriodRental { get; set; }
    }
}
