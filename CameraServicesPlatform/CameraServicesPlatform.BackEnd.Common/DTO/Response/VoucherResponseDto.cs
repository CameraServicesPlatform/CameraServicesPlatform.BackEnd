﻿using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class VoucherResponseDto
    {
        
        public string? SupplierID { get; set; }

        [MaxLength(50)]
        public string VourcherCode { get; set; }

        public double DiscountAmount { get; set; }

        public string Description { get; set; }

        public DateTime ValidFrom { get; set; }


        public DateTime ExpirationDate { get; set; }
    }
}
