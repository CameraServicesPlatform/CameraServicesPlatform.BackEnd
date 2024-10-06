using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ReportService : GenericBackendService, IReportService
    {
        private readonly IRepository<Report> _reportRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ReportService(
            IRepository<Report> reportRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateReport(ReportRequest request)
        {
            var result = new AppActionResult();
            try
            {
                var report = new Report
                {
                    AccountId = request.AccountId,
                    ReportType = request.ReportType,
                    ReportDetails = request.ReportDetails,
                };

                await _reportRepository.Insert(report);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = report;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> DeleteReport(string reportId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(reportId, out Guid ReportId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var report = await _reportRepository.GetById(ReportId);
                if (report == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Báo cáo không tồn tại!");
                    return result;
                }

                await _reportRepository.DeleteById(ReportId);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Báo cáo đã được xóa!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllReport(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                var report = await _reportRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                result.IsSuccess = true;
                result.Result = report;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetReportById(string reportId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(reportId, out Guid ReportId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var report = await _reportRepository.GetById(ReportId);
                if (report == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Báo cáo không tồn tại!");
                    return result;
                }

                result.IsSuccess = true;
                result.Result = report;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> UpdateReport(string reportId, ReportRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(reportId, out Guid ReportId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingReport = await _reportRepository.GetById(ReportId);
                if (existingReport == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Báo cáo không tồn tại!");
                    return result;
                }

                existingReport.ReportType = request.ReportType;
                existingReport.ReportDetails = request.ReportDetails;

                await _reportRepository.Update(existingReport);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = existingReport;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
