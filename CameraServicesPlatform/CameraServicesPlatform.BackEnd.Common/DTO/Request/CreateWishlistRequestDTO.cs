﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class CreateWishlistRequestDTO
    {
        public Guid MemberID { get; set; }
        public Guid ProductID { get; set; }
    }
}