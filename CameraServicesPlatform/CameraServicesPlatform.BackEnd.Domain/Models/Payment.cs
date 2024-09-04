using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public Guid? OrderID { get; set; }
    public Order? Order { get; set; }

    public Guid? ShopID { get; set; }

    [ForeignKey(nameof(ShopID))]
    public Shop? Shop { get; set; }

    public Guid? UserID { get; set; }

    [ForeignKey(nameof(UserID))]
    public User? User { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public decimal PaymentAmount { get; set; }

    public PaymentType PaymentType { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public string? PaymentDetails { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(255)]
    public string? Image { get; set; }
}
