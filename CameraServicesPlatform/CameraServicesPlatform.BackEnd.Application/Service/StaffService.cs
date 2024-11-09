using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
 using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Google.Apis.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twilio.Jwt.Taskrouter;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class StaffService : GenericBackendService, IStaffService
    {
        private readonly IMapper _mapper;
        private IRepository<Staff> _repository;
        private IRepository<Account> _accountRepository;
        private IUnitOfWork _unitOfWork;


        public StaffService(
            IRepository<Staff> repository,
            IRepository<Account> accountRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _accountRepository = accountRepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> DeleteStaff(string staffID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(staffID, out Guid DLStaffID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingST = await _repository.GetById(DLStaffID);
                if (existingST == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "staff không tồn tại!");
                    return result;
                }

                existingST.IsDisable = true;

                await _repository.Update(existingST);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Staff đã được xóa!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllStaff(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Staff, bool>>? filter = null;

                var Result = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Name,
                    isAscending: true,
                    includes: new Expression<Func<Staff, object>>[]
                    {
                        a => a.Account
                    }
                );

                var responses = Result.Items.Select(ST =>
                {
                    var response = _mapper.Map<StaffResponseDto>(ST);
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<StaffResponseDto>
                {
                    Items = responses
                };

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllAccountActive(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Account, bool>>? filter = s => s.IsVerified == true;

                var Result = await _accountRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: s => s.Email
                   
                );

                var responses = Result.Items.Select(account =>
                {
                    var response = _mapper.Map<AccountResponse>(account);
                    return response;
                }).ToList();

                var pagedResult = new PagedResult<AccountResponse>
                {
                    Items = responses,
                   
                };

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllAccountNotActive(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Account, bool>>? filter = s => s.IsVerified == false;

                var Result = await _accountRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: s => s.Email
                    
                );

                var responses = Result.Items.Select(account =>
                {
                    var response = _mapper.Map<AccountResponse>(account);
                    return response;
                }).ToList();

                var pagedResult = new PagedResult<AccountResponse>
                {
                    Items = responses,

                };

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetStaffById(string staffID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(staffID, out Guid GStaffID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var Result = await _repository.GetAllDataByExpression(
                    a => a.StaffID == GStaffID,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Name,
                    isAscending: true,
                    includes: new Expression<Func<Staff, object>>[]
                    {
                         a => a.Account
                    }
                );
                var pagedResult = _mapper.Map<StaffResponseDto>(Result);

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetStaffByName(string? staffName, int pageIndex, int pageSize)
        {

            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Staff, bool>>? filter = a => a.Name.Contains(staffName);

                if (string.IsNullOrEmpty(staffName))
                {
                    filter = null;
                }

                var Result = await _repository.GetAllDataByExpression(
                   filter,
                   pageIndex,
                   pageSize,
                   orderBy: a => a.Name,
                   isAscending: true,
                   includes: new Expression<Func<Staff, object>>[]
                   {
                        a => a.Account
                   }
               );
                var responses = Result.Items.Select(ST =>
                {
                    var response = _mapper.Map<StaffResponseDto>(ST);
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<StaffResponseDto>
                {
                    Items = responses
                };

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateStaff(string StaffID,StaffRequestDTO request)
        {
            var firebaseService = Resolve<IFirebaseService>();
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(StaffID, out Guid DLStaffID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingST = await _repository.GetById(DLStaffID);
                if (existingST == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "staff không tồn tại!");
                    return result;
                }

                existingST.Name = request.Name;
                existingST.JobTitle = request.JobTitle;
                existingST.Department = request.Department;
                existingST.StaffStatus = request.StaffStatus;
                existingST.HireDate = request.HireDate;
                existingST.IsAdmin = request.IsAdmin;
                string imageUrl = null;

                if (request.Img != null && request.Img.ToString() != existingST.Img)
                {
                    if (!string.IsNullOrEmpty(existingST.Img))
                    {
                        await firebaseService.DeleteFileFromFirebase(existingST.Img);
                    }

                    var imgPathName = SD.FirebasePathName.STAFF_PREFIX + $"{StaffID}.jpg";
                    var imgUpload = await firebaseService.UploadFileToFirebase(request.Img, imgPathName);
                    imageUrl = imgUpload?.Result?.ToString();
                }

                existingST.Img = imageUrl;

                await _repository.Update(existingST);
                await _unitOfWork.SaveChangesAsync();

                var pagedResult = _mapper.Map<StaffResponseDto>(existingST);
                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
