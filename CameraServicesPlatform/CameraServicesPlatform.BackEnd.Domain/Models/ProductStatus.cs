using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class ProductStatus
    {
    [Key] public Guid ProductStatusID { get; set; }
        public Guid ProductID { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public Guid HandledBy { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }

