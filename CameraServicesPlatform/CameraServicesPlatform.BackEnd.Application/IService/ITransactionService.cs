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
        
   
        Task<AppActionResult> GetAllTransaction(int pageIndex, int pageSize);
        Task<AppActionResult> GetTransactionById(string id, int pageIndex, int pageSize); 
        Task<AppActionResult> GetTransactionBySupplierId(string id, int pageIndex, int pageSize); 
        Task<AppActionResult> CreateSupplierOrMemberPayment(SupplierPaymentAgainDto supplierResponse, HttpContext context);
        
        Task<AppActionResult> CreateStaffRefund(StaffRefundDto supplierResponse, HttpContext context);
        Task<AppActionResult> CreateStaffRefundPurchuse(string historyTransaction, HttpContext context);
        Task<AppActionResult> CreateSupplierPaymentPurchuse(string historyTransaction, HttpContext context);

    }
}
