﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class ProductSpecifications
    {
        public Guid ProductSpecificationsID { get; set; }
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public Product Product { get; set; }
    }
