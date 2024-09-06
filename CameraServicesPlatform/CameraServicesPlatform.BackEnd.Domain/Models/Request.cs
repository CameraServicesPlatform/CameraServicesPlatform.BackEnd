using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Request
    {
    [Key] public Guid SupplierRequestID { get; set; }
        public Guid AccountID { get; set; }
        public Guid RoleRequestID { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? ReviewedBy { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }

         public Account Account { get; set; }
        public Account Reviewer { get; set; }
    }

