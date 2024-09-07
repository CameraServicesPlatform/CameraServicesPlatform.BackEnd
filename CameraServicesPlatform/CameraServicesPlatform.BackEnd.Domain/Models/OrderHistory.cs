using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class OrderHistory
    {
        [Key]
        public Guid OrderHistoryID { get; set; }

        public Guid MemberID { get; set; }

        [ForeignKey(nameof(MemberID))]
        public Member Member { get; set; }

        public Guid OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public string OrderDetails { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }

}
