using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IComboOfSupplierService
    {
        Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto request, HttpContext context);
        Task<AppActionResult> GetAllComboOfSupplier(int pageIndex, int pageSize);
        Task<AppActionResult> GetComboOfSupplierExpired(int pageIndex, int pageSize);
        Task<AppActionResult> GetComboBySupplierId(string supplierId);
        
        Task<AppActionResult> GetComboOfSupplierNearExpired(int pageIndex, int pageSize);
        Task<AppActionResult> GetComboOfSupplierByComboSupplierId(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetComboOfSupplierBySupplierId(string id, int pageIndex, int pageSize);

    }
}
