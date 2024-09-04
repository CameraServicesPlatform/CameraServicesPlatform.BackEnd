using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class ReturnDetails
    {
        public Guid ReturnID { get; set; }
        public Guid OrderID { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Condition { get; set; }
        public decimal PenaltyApplied { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Orders Order { get; set; }
    }

