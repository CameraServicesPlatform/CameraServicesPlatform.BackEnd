using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class SystemAdminResponseDTO
    {
        public double? ReservationMoney { get; set; }
        public CancelDurationUnit? CancelDurationUnit { get; set; }
        public int? CancelVaule { get; set; }
        public CancelDurationUnit? CancelAcceptDurationUnit { get; set; }
        public int? CancelAcceptVaule { get; set; }
        public DateTime? ReservationMoneyCreatedAt { get; set; }
        public DateTime? CancelVauleCreatedAt { get; set; }
        public DateTime? CancelAcceptVauleCreatedAt { get; set; }
    }
}
