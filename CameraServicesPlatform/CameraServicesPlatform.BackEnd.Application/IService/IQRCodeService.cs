﻿using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IQRCodeService
    {
        public Task<AppActionResult> GenerateQR(string Id);
        public Task<AppActionResult> DecodeQR(string hashedAccountData);
    }
}
