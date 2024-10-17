using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class VoucherUpdateResponseDto
    {
        public string VourcherID { get; set; }

        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
