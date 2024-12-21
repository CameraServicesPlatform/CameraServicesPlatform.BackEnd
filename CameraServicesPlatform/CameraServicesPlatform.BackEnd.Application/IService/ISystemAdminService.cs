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
    public interface ISystemAdminService
    {
        Task<AppActionResult> GetAllSystemAdmins(int pageNumber, int pageSize);
        Task<AppActionResult> CreateSystemAdmin(SystemAdminRequestDTO request);
        Task<AppActionResult> GetNewReservationMoney();
        Task<AppActionResult> GetNewCancelValue();
        Task<AppActionResult> GetNewCancelAcceptValue();

    }
}
