using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IReturnDetailService
    {
        Task<AppActionResult> CreateReturnDetail(ReturnDetailRequest request);
        Task<AppActionResult> CreateReturnDetailForMember(ReturnDetailMemberRequest request);
        Task<AppActionResult> UpdateReturnDetail(string ReturnID, ReturnDetailRequest request);
        Task<AppActionResult> GetReturnDetailByOrderID(string OrderID, int pageIndex, int pageSize);
        Task<AppActionResult> GetAllReturnDetail(int pageIndex, int pageSize);
        Task<AppActionResult> GetReturnDetailById(string ReturnID);
        Task<AppActionResult> DeleteReturnDetail(string ReturnID);

    }
}
