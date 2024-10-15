using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface ISupplierService
    {
        
        Task<AppActionResult> GetAllSupplier(int pageIndex, int pageSize);
        Task<AppActionResult> GetSupplierById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetSupplierByName([FromQuery] string? filter, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateSupplier(SupplierUpdateResponseDto productResponse);
        Task<AppActionResult> CreateSupplier(SupplierResponseDto supplierResponse);
        Task<AppActionResult> DeleteSupplier(string supplierId);
    }
}
