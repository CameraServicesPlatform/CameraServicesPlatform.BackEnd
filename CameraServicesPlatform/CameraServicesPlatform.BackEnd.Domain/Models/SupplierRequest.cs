using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class SupplierRequest
    {
        public Guid SupplierRequestID { get; set; }
        public Guid SupplierID { get; set; }
        public RequestType RequestType { get; set; }
        public string RequestDetails { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<Supplier> Suppliers { get; set; }
    }

}
