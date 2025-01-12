using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class DeliveriesMethod
    {
        [Key]
        public Guid DeliveriesMethodID { get; set; }
        [ForeignKey(nameof(Order))]
        public Guid? OrderID { get; set; }
        public Order Order { get; set; }
        public string DeliveriesMethodName { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
