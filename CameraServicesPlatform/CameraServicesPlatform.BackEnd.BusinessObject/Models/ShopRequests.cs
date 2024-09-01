using CameraServicesPlatform.BackEnd.BusinessObject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.BusinessObject.Models
{
    public class ShopRequests
    {
        public Guid ShopRequestID { get; set; }
        public Guid UserID { get; set; }
        public Guid RoleRequestID { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? ReviewedBy { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }

        // Navigation Properties
        public User User { get; set; }
         public User Reviewer { get; set; }
    }
}
