using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class OrderStatusStatisticsDto
    {
        public OrderStatus Status { get; set; } 
        public int Count { get; set; } 
    }
}
