using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Report;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

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
        public static class DateTimeHelper
        {
            private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Convert UTC DateTime to Vietnam Time
            public static DateTime ToVietnamTime(DateTime utcDateTime)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, VietnamTimeZone);
            }
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
                    ReportDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
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

                var responses = report.Items.Select(RB =>
                {
                    var response = _mapper.Map<ReportResponse>(RB);
                    response.ReportID = RB.ReportID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<ReportResponse>
                {
                    Items = responses
                };

                result.IsSuccess = true;
                result.Result = pagedResult;
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

                var response = _mapper.Map<ReportResponse>(report);
                response.ReportID = report.ReportID.ToString();

                result.IsSuccess = true;
                result.Result = response;
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
                var existingReport = await _reportRepository.GetByExpression(x => x.ReportID == ReportId);
                if (existingReport == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Báo cáo không tồn tại!");
                    return result;
                }

                existingReport.ReportType = request.ReportType;
                existingReport.ReportDetails = request.ReportDetails;
                existingReport.Status = ReportStatus.Pending;

                await _reportRepository.Update(existingReport);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<ReportResponse>(existingReport);
                response.ReportID = existingReport.ReportID.ToString();

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> ApprovedReport(ReportUpdateRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(request.ReportId, out Guid ReportId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingReport = await _reportRepository.GetByExpression(x => x.ReportID == ReportId);
                if (existingReport == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Báo cáo không tồn tại!");
                    return result;
                }

                existingReport.Status = ReportStatus.Approved;
                existingReport.Message = request.Message;

                await _reportRepository.Update(existingReport);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<ReportResponse>(existingReport);
                response.ReportID = existingReport.ReportID.ToString();

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> RejectReport(ReportUpdateRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(request.ReportId, out Guid ReportId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingReport = await _reportRepository.GetByExpression(x => x.ReportID == ReportId);
                if (existingReport == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Báo cáo không tồn tại!");
                    return result;
                }

                existingReport.Status = ReportStatus.Reject;
                existingReport.Message = request.Message;

                await _reportRepository.Update(existingReport);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<ReportResponse>(existingReport);
                response.ReportID = existingReport.ReportID.ToString();

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
