using CameraServicesPlatform.BackEnd.BusinessObject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class ShopStatus
    {
        public Guid ShopStatusID { get; set; }
        public Guid ShopID { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public Guid HandledBy { get; set; }

        // Navigation Properties
        public Shop Shop { get; set; }
        public User User { get; set; }
    }
}
