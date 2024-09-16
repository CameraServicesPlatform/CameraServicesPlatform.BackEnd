﻿using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class OrderHistory
    {
        [Key]
        public Guid OrderHistoryID { get; set; }

        [Required]
        public Guid MemberID { get; set; }

        [ForeignKey(nameof(MemberID))]
        public Member Member { get; set; } 

        [Required]
        public Guid OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(1000)] // Optional: Restrict string length
        public string OrderDetails { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }
    }
}
