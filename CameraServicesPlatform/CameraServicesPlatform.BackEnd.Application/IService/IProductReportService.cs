using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IProductReportService
    {
        Task<AppActionResult> CreateProductReport(ProductReportResponseDto productReportResponse);
        Task<AppActionResult> DeleteProductReport(string productReportId);
        Task<AppActionResult> GetAllProductReport(int pageIndex, int pageSize);
        Task<AppActionResult> GetProductReportById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductReportBySupplierId(string id, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateProductReport(ProductReportUpdateDto productReportResponse);


        Task<AppActionResult> RejectProductReport(ProductReportRequest productReportRequest);
        Task<AppActionResult> ApprovedProductReport(ProductReportRequest productReportRequest);
    }
}
