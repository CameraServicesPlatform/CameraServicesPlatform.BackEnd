using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class SupplierPaymentDto
    {

        public string SupplierID { get; set; }

        public string OrderInfo { get; set; }
        public string SupplierName { get; set; }
        public double Amount { get; set; }

    }
}
