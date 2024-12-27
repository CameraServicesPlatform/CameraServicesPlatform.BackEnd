using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateComboPaymentDTO
    {
        public string? OrderID { get; set; } = Guid.NewGuid().ToString();
        public string AccountId { get; set; }
        public string ComboOfSupplierId { get; set; }
        public double Amount { get; set; }
    }
}
