using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IReportService
    {
        Task<AppActionResult> CreateReport(ReportRequest request);
        Task<AppActionResult> UpdateReport(string contractId, ReportRequest request);
        Task<AppActionResult> DeleteReport(string contractId);
        Task<AppActionResult> GetReportById(string contractId);
        Task<AppActionResult> GetAllReport(int pageIndex, int pageSize);

        Task<AppActionResult> RejectReport(ReportUpdateRequest request);
        Task<AppActionResult> ApprovedReport(ReportUpdateRequest request);
    }
}
