using CameraServicesPlatform.BackEnd.BusinessObject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }  
        public Guid ShopID { get; set; }   
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public Guid CategoryID { get; set; }   
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public int Quantity { get; set; }
        public ProductStatusEnum Status { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

         public virtual Shop Shop { get; set; }
        public virtual Categories Category { get; set; }
    }
}
