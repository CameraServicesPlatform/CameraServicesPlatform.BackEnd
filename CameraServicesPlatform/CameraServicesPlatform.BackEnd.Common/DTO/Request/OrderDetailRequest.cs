using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class OrderDetailRequest
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public decimal ProductPrice { get; set; }

        [MaxLength(255)]
        public string ProductQuality { get; set; }
        public decimal Discount { get; set; }
        public decimal ProductPriceTotal { get; set; }
    }
}
