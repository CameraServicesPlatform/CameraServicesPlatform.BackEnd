using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IStaffService
    {
        Task<AppActionResult> GetAllStaff(int pageIndex, int pageSize);
        Task<AppActionResult> GetStaffById(string staffID, int pageIndex, int pageSize);
        Task<AppActionResult> GetStaffByName(string? staffName, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateStaff(string StaffID, StaffRequestDTO request);
        Task<AppActionResult> DeleteStaff(string staffID);
    }
}
