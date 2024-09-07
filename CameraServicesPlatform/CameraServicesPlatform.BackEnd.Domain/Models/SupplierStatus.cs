using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class SupplierStatus
    {
    [Key] public Guid SupplierStatusID { get; set; }
        public Guid SupplierID { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public Guid HandledBy { get; set; }

    // Navigation Properties
    public   ICollection<Supplier> Suppliers { get; set; }
    public Account Account { get; set; }
    }

