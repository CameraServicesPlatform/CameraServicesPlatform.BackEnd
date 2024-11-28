using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IExtendService
    {
        Task<AppActionResult> CreateExtend(CreateExtendRequest request);
        Task<AppActionResult> GetAllExtend(int pageIndex, int pageSize);
        Task<AppActionResult> GetExtendById(string ExtendID);
        Task<AppActionResult> GetAllExtendByOrderId(string OrderID, int pageIndex, int pageSize);



    }
}
