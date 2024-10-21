using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class DeliveriesMethod
    {
        [Key]
        public Guid DeliveriesMethodID { get; set; }



        public DeliveryStatus MethodName { get; set; }


        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
