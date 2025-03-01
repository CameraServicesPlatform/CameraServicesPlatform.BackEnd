﻿using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
 using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Google.Apis.Util;
using Microsoft.AspNetCore.Identity;
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
            AppActionResult result = new();
            Expression<Func<Account, bool>>? filter = s => s.IsVerified == true;
            PagedResult<Account> list = await _accountRepository.GetAllDataByExpression(filter, pageIndex, pageSize, null, false, null);

            IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            IRepository<IdentityRole>? roleRepository = Resolve<IRepository<IdentityRole>>();
            PagedResult<IdentityRole> listRole = await roleRepository!.GetAllDataByExpression(null, 1, 100, null, false, null);

            // Add repositories for Supplier and Staff
            IRepository<Supplier>? supplierRepository = Resolve<IRepository<Supplier>>();
            IRepository<Staff>? staffRepository = Resolve<IRepository<Staff>>();

            List<AccountResponse> listMap = _mapper.Map<List<AccountResponse>>(list.Items);
            foreach (AccountResponse item in listMap)
            {
                // Retrieve User Roles
                List<IdentityRole> userRole = new(); // Corrected empty list initialization
                PagedResult<IdentityUserRole<string>> role = await userRoleRepository!.GetAllDataByExpression(a => a.UserId == item.Id, 1, 100, null, false, null);
                foreach (IdentityUserRole<string> itemRole in role.Items ?? new List<IdentityUserRole<string>>()) // Null check for Items
                {
                    IdentityRole? roleUser = listRole.Items?.FirstOrDefault(a => a.Id == itemRole.RoleId); // Null check for Items
                    if (roleUser != null)
                    {
                        userRole.Add(roleUser);
                    }
                }

                item.Role = userRole;

                // Determine MainRole with more readable logic
                if (userRole.Any(u => u.Name.Equals("ADMIN", StringComparison.OrdinalIgnoreCase)))
                {
                    item.MainRole = "ADMIN";
                }
                else if (userRole.Any(u => u.Name.Equals("SUPPLIER", StringComparison.OrdinalIgnoreCase)))
                {
                    item.MainRole = "SUPPLIER";
                }
                else if (userRole.Any(u => u.Name.Equals("STAFF", StringComparison.OrdinalIgnoreCase)))
                {
                    item.MainRole = "STAFF";
                }
                else
                {
                    // Default to "MEMBER" if no matching roles are found
                    item.MainRole = userRole.FirstOrDefault(u => u.Name != "MEMBER")?.Name ?? "MEMBER";
                }

                // Retrieve Supplier data with null check
                var supplier = await supplierRepository!.GetSingleByExpressionAsync(s => s.AccountID == item.Id);
                if (supplier != null)
                {
                    item.SupplierID = supplier.SupplierID.ToString();
                    item.Supplier = supplier;
                }
            }

            result.Result = new PagedResult<AccountResponse> { Items = listMap, TotalPages = list.TotalPages };
            return result;
        }

        public async Task<AppActionResult> GetAllAccountNotActive(int pageIndex, int pageSize)
        {
            AppActionResult result = new();
            Expression<Func<Account, bool>>? filter = s => s.IsVerified == false;
            PagedResult<Account> list = await _accountRepository.GetAllDataByExpression(filter, pageIndex, pageSize, null, false, null);

            IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            IRepository<IdentityRole>? roleRepository = Resolve<IRepository<IdentityRole>>();
            PagedResult<IdentityRole> listRole = await roleRepository!.GetAllDataByExpression(null, 1, 100, null, false, null);

            // Add repositories for Supplier and Staff
            IRepository<Supplier>? supplierRepository = Resolve<IRepository<Supplier>>();
            IRepository<Staff>? staffRepository = Resolve<IRepository<Staff>>();

            List<AccountResponse> listMap = _mapper.Map<List<AccountResponse>>(list.Items);
            foreach (AccountResponse item in listMap)
            {
                // Retrieve User Roles
                List<IdentityRole> userRole = new(); // Corrected empty list initialization
                PagedResult<IdentityUserRole<string>> role = await userRoleRepository!.GetAllDataByExpression(a => a.UserId == item.Id, 1, 100, null, false, null);
                foreach (IdentityUserRole<string> itemRole in role.Items ?? new List<IdentityUserRole<string>>()) // Null check for Items
                {
                    IdentityRole? roleUser = listRole.Items?.FirstOrDefault(a => a.Id == itemRole.RoleId); // Null check for Items
                    if (roleUser != null)
                    {
                        userRole.Add(roleUser);
                    }
                }

                item.Role = userRole;

                // Determine MainRole with more readable logic
                if (userRole.Any(u => u.Name.Equals("ADMIN", StringComparison.OrdinalIgnoreCase)))
                {
                    item.MainRole = "ADMIN";
                }
                else if (userRole.Any(u => u.Name.Equals("SUPPLIER", StringComparison.OrdinalIgnoreCase)))
                {
                    item.MainRole = "SUPPLIER";
                }
                else if (userRole.Any(u => u.Name.Equals("STAFF", StringComparison.OrdinalIgnoreCase)))
                {
                    item.MainRole = "STAFF";
                }
                else
                {
                    // Default to "MEMBER" if no matching roles are found
                    item.MainRole = userRole.FirstOrDefault(u => u.Name != "MEMBER")?.Name ?? "MEMBER";
                }

                // Retrieve Supplier data with null check
                var supplier = await supplierRepository!.GetSingleByExpressionAsync(s => s.AccountID == item.Id);
                if (supplier != null)
                {
                    item.SupplierID = supplier.SupplierID.ToString();
                    item.Supplier = supplier;
                }
            }

            result.Result = new PagedResult<AccountResponse> { Items = listMap, TotalPages = list.TotalPages };
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

                var staff = await _repository.GetByExpression(
           a => a.StaffID == GStaffID,
           includeProperties: new Expression<Func<Staff, object>>[] { a => a.Account }
       );

                if (staff == null)
                {
                    result = BuildAppActionResultError(result, "Nhân viên không tồn tại.");
                    return result;
                }

                var staffResponse = _mapper.Map<StaffResponseDto>(staff);

                result.Result = staffResponse;
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
                // Kiểm tra nếu staffName rỗng hoặc null, sẽ tìm tất cả
                Expression<Func<Staff, bool>>? filter = null;

                if (!string.IsNullOrEmpty(staffName))
                {
                    filter = a => a.Name.Contains(staffName);
                }

                // Truy vấn từ repository với filter, phân trang và sắp xếp
                var resultData = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Name,
                    isAscending: true,
                    includes: new Expression<Func<Staff, object>>[] { a => a.Account }
                );

                // Ánh xạ các kết quả thành StaffResponseDto
                var responses = resultData.Items.Select(ST =>
                {
                    var response = _mapper.Map<StaffResponseDto>(ST);
                    return response;
                }).ToList();

                // Tạo PagedResult cho kết quả
                var pagedResult = new PagedResult<StaffResponseDto>
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
