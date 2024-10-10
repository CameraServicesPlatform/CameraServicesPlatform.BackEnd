using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("contractTemplate")]
    [ApiController]
    public class ContractTemplateController : ControllerBase
    {
        private readonly IContractTemplateService _contractTemplateService;

        public ContractTemplateController(IContractTemplateService contractTemplateService)
        {
            _contractTemplateService = contractTemplateService;
        }

        [HttpPost("create-contract-template")]
        public async Task<IActionResult> CreateContract([FromBody] CreateContractTemplateRequestDTO request)
        {
            try
            {
                var response = await _contractTemplateService.CreateContractTemplate(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-contract-template-by-id")]
        public async Task<IActionResult> UpdateContract(string contractTemplateId, [FromBody] CreateContractTemplateRequestDTO request)
        {
            try
            {
                var response = await _contractTemplateService.UpdateContractTemplate(contractTemplateId, request);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-contract-template-by-id")]
        public async Task<IActionResult> DeleteContract(string contractTemplateId)
        {
            try
            {
                var response = await _contractTemplateService.DeleteContractTemplate(contractTemplateId);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-contract-template-by-id")]
        public async Task<IActionResult> GetContractById(string contractTemplateId)
        {
            try
            {
                var response = await _contractTemplateService.DeleteContractTemplate(contractTemplateId);
                if (!response.IsSuccess)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-contract-templates")]
        public async Task<AppActionResult> GetAllContracts(int pageIndex = 1, int pageSize = 10)
        {
            return await _contractTemplateService.GetAllContractTemplates(pageIndex, pageSize);
        }
    }
}
