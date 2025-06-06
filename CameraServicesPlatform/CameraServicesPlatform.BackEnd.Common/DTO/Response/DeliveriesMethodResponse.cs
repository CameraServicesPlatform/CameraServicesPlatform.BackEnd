﻿using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class DeliveriesMethodResponse
    {
        public string DeliveriesMethodID { get; set; }

        public string DeliveriesMethodName { get; set; }
        public string OrderID { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
