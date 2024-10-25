using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IDeliveriesMethodService
    {
        
        Task<AppActionResult> CreateDeliveriesMethod(DeliveriesMethodRequest request);
        Task<AppActionResult> UpdateDeliveriesMethod(string contractId, DeliveriesMethodRequest request);
        Task<AppActionResult> DeleteDeliveriesMethod(string deliveriesMethodId);
        Task<AppActionResult> GetDeliveriesMethodById(string deliveriesMethodId);
        Task<AppActionResult> GetAllDeliveriesMethod(int pageIndex, int pageSize);
    }
}

