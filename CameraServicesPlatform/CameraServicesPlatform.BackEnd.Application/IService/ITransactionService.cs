﻿using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface ITransactionService
    {
        Task<AppActionResult> CreateTransaction(VNPayResponseDto response, double amount, string account);
    }
}
