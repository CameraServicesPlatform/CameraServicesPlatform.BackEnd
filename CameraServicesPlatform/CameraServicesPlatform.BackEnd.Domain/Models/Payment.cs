using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public Guid? OrderID { get; set; }
        public Guid ShopID { get; set; }
        public Guid? UserID { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal PaymentAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? PaymentDetails { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Image { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Orders Order { get; set; }
        public virtual User User { get; set; }
    }

