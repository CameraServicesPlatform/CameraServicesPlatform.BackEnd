using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface ISupplierReportService
    {
        Task<AppActionResult> CreateSupplierReport(SupplierReportDto supplierReportDto);
        Task<AppActionResult> GetAllSupplierReport(int pageIndex, int pageSize);
        Task<AppActionResult> GetSupplierReportById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetSupplierReportBySupplierId(string supplierId, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateSupplierReport(SupplierReportUpdateDto supplierReportUpdateDto);
    }
}
