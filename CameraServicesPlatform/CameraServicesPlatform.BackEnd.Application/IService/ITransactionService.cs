﻿using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
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

        Task<AppActionResult> GetAllTransaction(int pageIndex, int pageSize);
        Task<AppActionResult> GetTransactionById(string id, int pageIndex, int pageSize); 
        Task<AppActionResult> GetTransactionBySupplierId(string id, int pageIndex, int pageSize); 
        Task<AppActionResult> CreateSupplierPaymentAgain1(SupplierPaymentAgainDto supplierResponse, HttpContext context);
        
        Task<AppActionResult> CreateSupplierPaymentPurchuse(string historyTransaction, HttpContext context);

    }
}
