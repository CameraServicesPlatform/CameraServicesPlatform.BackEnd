using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class OrderDetail
{
    [Key]
    public Guid OrderDetailsID { get; set; }

    public Guid OrderID { get; set; }

    [ForeignKey(nameof(OrderID))]
    public Order Order { get; set; }

    public Guid ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

    public decimal ProductPrice { get; set; }

    public string ProductQuality { get; set; }

    public decimal Discount { get; set; }

    public decimal ProductPriceTotal { get; set; }

    public int? RentalPeriod { get; set; }
}
