﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class CategoryUpdateResponseDto
    {
        public Guid CategoryID { get; set; }


        public string CategoryName { get; set; }


        public string? CategoryDescription { get; set; }
    }
}
