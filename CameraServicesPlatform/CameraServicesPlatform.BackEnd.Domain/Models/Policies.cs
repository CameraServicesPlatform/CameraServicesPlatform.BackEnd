﻿using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class Policies
    {
        public Guid PolicyID { get; set; }
        public PolicyType PolicyType { get; set; }
        public string PolicyContent { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Guid UserID { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
