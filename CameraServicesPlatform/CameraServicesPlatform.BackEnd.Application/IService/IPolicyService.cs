using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IPolicyService
    {
        Task<AppActionResult> CreatePolicy(PolicyRequestDTO request);
        Task<AppActionResult> UpdatePolicy(string PolicyID, PolicyRequestDTO request);
        Task<AppActionResult> GetPolicyByApplicableObject(ApplicableObject type, int pageIndex, int pageSize);
        Task<AppActionResult> GetAllPolicy(int pageIndex, int pageSize);
        Task<AppActionResult> GetPolicyById(string PolicyID);
        Task<AppActionResult> DeletePolicy(string PolicyID);
    }
}
