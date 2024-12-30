using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Domain.Models.CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System.Linq.Expressions;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class SystemAdminService : GenericBackendService, ISystemAdminService
    {
        private readonly IRepository<SystemAdmin> _systemAdminRepository;
       
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SystemAdminService(
           IRepository<SystemAdmin> systemAdminReposirory,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           IServiceProvider serviceProvider
       ) : base(serviceProvider)
        {
            _systemAdminRepository = systemAdminReposirory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public static class DateTimeHelper
        {
            private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            public static DateTime ToVietnamTime(DateTime utcDateTime)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, VietnamTimeZone);
            }
        }
        public async Task<AppActionResult> GetAllSystemAdmins(int pageNumber, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                var pagedData = await _systemAdminRepository.GetAllDataByExpression(
                    filter: null, 
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: x => x.ReservationMoneyCreatedAt,
                    isAscending: false 
                );

                result.IsSuccess = true;
                result.Result = pagedData; 
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> CreateSystemAdmin(SystemAdminRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                var systemAdmin = _mapper.Map<SystemAdmin>(request);
                if (request.CancelVaule != 0) { 
                systemAdmin.CancelVauleCreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                }
                if(request.CancelAcceptVaule != 0) {
                systemAdmin.CancelAcceptVauleCreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                }
                if(request.ReservationMoney != 0) {
                systemAdmin.ReservationMoneyCreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                }

                await _systemAdminRepository.Insert(systemAdmin);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<SystemAdminResponseDTO>(systemAdmin);

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }


        public async Task<AppActionResult> GetNewCancelAcceptValue()
        {
            try
            {
                DateTime timeNow = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);

                var result = await _systemAdminRepository.GetAllDataByExpression(
                    filter: r => r.CancelAcceptVauleCreatedAt <= timeNow,
                    pageNumber: 1,
                    pageSize: 1,
                    orderBy: r => r.CancelAcceptVauleCreatedAt,
                    isAscending: false
                );

                var latestSystemAdmin = result.Items?.FirstOrDefault();

                if (latestSystemAdmin == null)
                {
                    return new AppActionResult
                    {
                        IsSuccess = false,
                        Messages = new List<string> { "Không có dữ liệu giá trị đồng ý hủy." },
                        Result = null
                    };
                }

                return new AppActionResult
                {
                    IsSuccess = true,
                    Messages = new List<string> { "Thành công" },
                    Result = new
                    {
                        latestSystemAdmin.CancelAcceptVaule,
                        latestSystemAdmin.CancelAcceptDurationUnit
                    }
                };
            }
            catch (Exception ex)
            {
                return new AppActionResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { $"Đã có lỗi xảy ra: {ex.Message}" },
                    Result = null
                };
            }
        }

        public async Task<AppActionResult> GetNewCancelValue()
        {
            try
            {
                DateTime timeNow = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);

                var result = await _systemAdminRepository.GetAllDataByExpression(
                    filter: r => r.CancelVauleCreatedAt <= timeNow,  
                    pageNumber: 1,  
                    pageSize: 1,   
                    orderBy: r => r.CancelVauleCreatedAt,  
                    isAscending: false
                );

                var latestSystemAdmin = result.Items?.FirstOrDefault();

                if (latestSystemAdmin == null)
                {
                    return new AppActionResult
                    {
                        IsSuccess = false,
                        Messages = new List<string> { "Không có dữ liệu giá trị hủy." },
                        Result = null
                    };
                }

                return new AppActionResult
                {
                    IsSuccess = true,
                    Messages = new List<string> { "Thành công" },
                    Result = new
                    {
                        latestSystemAdmin.CancelVaule,
                        latestSystemAdmin.CancelAcceptDurationUnit
                    }
                };
            }
            catch (Exception ex)
            {
                return new AppActionResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { $"Đã có lỗi xảy ra: {ex.Message}" },
                    Result = null
                };
            }
        }


        public async Task<AppActionResult> GetNewReservationMoney()
        {
            try
            {
                DateTime timeNow = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);

                var result = await _systemAdminRepository.GetAllDataByExpression(
                    filter: r => r.ReservationMoneyCreatedAt <= timeNow,
                    pageNumber: 1,
                    pageSize: 1,
                    orderBy: r => r.ReservationMoneyCreatedAt,
                    isAscending: false
                );

                var latestSystemAdmin = result.Items?.FirstOrDefault();

                if (latestSystemAdmin == null)
                {
                    return new AppActionResult
                    {
                        IsSuccess = false,
                        Messages = new List<string> { "Không có dữ liệu giá trị hủy." },
                        Result = null
                    };
                }

                return new AppActionResult
                {
                    IsSuccess = true,
                    Messages = new List<string> { "Thành công" },
                    Result = new
                    {
                        latestSystemAdmin.ReservationMoney
                    }
                };
            }
            catch (Exception ex)
            {
                return new AppActionResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { $"Đã có lỗi xảy ra: {ex.Message}" },
                    Result = null
                };
            }
        }

    }
}
