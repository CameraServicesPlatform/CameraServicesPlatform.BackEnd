using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Shop
    {
        public Guid ShopID { get; set; }
        public Guid UserID { get; set; }
        public string ShopName { get; set; }
        public string? ShopDescription { get; set; }
        public string? ShopAddress { get; set; }
        public string? ContactNumber { get; set; }
        public string? ShopLogo { get; set; }
        public ShopStatusEnum ShopStatus { get; set; }
        public string? BlockReason { get; set; }
        public DateTime? BlockedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public decimal AccountBalance { get; set; }

         public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

