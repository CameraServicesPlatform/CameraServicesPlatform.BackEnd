using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IContractTemplateService
    {
        Task<AppActionResult> CreateContractTemplate(CreateContractTemplateRequestDTO request);
        Task<AppActionResult> UpdateContractTemplate(string contractTemplateId, CreateContractTemplateRequestDTO request);
        Task<AppActionResult> DeleteContractTemplate(string contractTemplateId);
        Task<AppActionResult> GetContractTemplateById(string contractTemplateId);
        Task<AppActionResult> GetAllContractTemplates(int pageIndex, int pageSize);
    }
}
