using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPut("update-contract-by-id")]
        public async Task<IActionResult> UpdateContract(string contractId, [FromBody] ContractRequestDTO request)
        {
            try
            {
                var response = await _contractService.UpdateContract(contractId, request);
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

        [HttpDelete("delete-contract-by-id")]
        public async Task<IActionResult> DeleteContract(string contractId)
        {
            try
            {
                var response = await _contractService.DeleteContract(contractId);
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

        [HttpGet("get-contract-by-id")]
        public async Task<IActionResult> GetContractById(string contractId)
        {
            try
            {
                var response = await _contractService.GetContractById(contractId);
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

        [HttpGet("get-all-contracts")]
        public async Task<AppActionResult> GetAllContracts(int pageIndex = 1, int pageSize = 10)
        {
            return await _contractService.GetAllContracts(pageIndex, pageSize);
        }
    }
}
