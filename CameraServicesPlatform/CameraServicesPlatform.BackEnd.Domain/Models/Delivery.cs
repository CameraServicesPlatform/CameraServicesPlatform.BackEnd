using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Delivery
    {
        public Guid DeliveryID { get; set; }
        public Guid OrderID { get; set; }
        public Guid DeliveryCompanyID { get; set; }
        public string DeliveryTrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        public ICollection <DeliveryCompany> DeliveryCompany { get; set; }
    }
}
