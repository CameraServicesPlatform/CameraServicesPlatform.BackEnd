using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class ShopRequest
    {
    [Key] public Guid ShopRequestID { get; set; }
        public Guid AccountID { get; set; }
        public Guid RoleRequestID { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? ReviewedBy { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }

         public Account User { get; set; }
        public Account Reviewer { get; set; }
    }

