using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class SystemAdminRequestDTO
    {
        public double? ReservationMoney { get; set; }
        public CancelDurationUnit? CancelDurationUnit { get; set; }
        public int? CancelVaule { get; set; }
        public CancelDurationUnit? CancelAcceptDurationUnit { get; set; }
        public int? CancelAcceptVaule { get; set; }
        public DateTime? ReservationMoneyCreatedAt { get; set; }
        public DateTime? CancelVauleCreatedAt { get; set; }
        public DateTime? CancelAcceptVauleCreatedAt { get; set; }
        public static class DateTimeHelper
        {
            private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Convert UTC DateTime to Vietnam Time
            public static DateTime ToVietnamTime(DateTime utcDateTime)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, VietnamTimeZone);
            }
        }
    }
}
