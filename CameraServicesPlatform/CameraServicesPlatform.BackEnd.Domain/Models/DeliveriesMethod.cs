using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class DeliveriesMethod
    {
        [Key]
        public Guid DeliveriesMethodID { get; set; }


        [MaxLength(100)]
        public string MethodName { get; set; }


        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
