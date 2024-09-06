﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Enum.Order;
public enum OrderStatus
{
    Pending,
    Approved,
    Completed,
    Placed,
    Shipped,
    Delivered,
    Cancelled
}

