using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpPost("create-policy")]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyRequestDTO request)
        {
            try
            {
                var response = await _policyService.CreatePolicy(request);
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

        [HttpPut("update-policy-by-id")]
        public async Task<IActionResult> UpdatePolicy(string PolicyID, [FromBody] PolicyRequestDTO request)
        {
            try
            {
                var response = await _policyService.UpdatePolicy(PolicyID, request);
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

        [HttpDelete("delete-policy-by-id")]
        public async Task<IActionResult> DeletePolicy(string PolicyID)
        {
            try
            {
                var response = await _policyService.DeletePolicy(PolicyID);
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

        [HttpGet("get-policy-by-id")]
        public async Task<IActionResult> GetPolicyById(string PolicyID)
        {
            try
            {
                var response = await _policyService.GetPolicyById(PolicyID);
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

        [HttpGet("get-policy-by-applicable-object")]
        public async Task<IActionResult> GetPolicyByApplicableObject(ApplicableObject type, int pageIndex, int pageSize)
        {
            try
            {
                var response = await _policyService.GetPolicyByApplicableObject(type, pageIndex, pageSize);
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

        [HttpGet("get-all-policy")]
        public async Task<AppActionResult> GetAllPolicy(int pageIndex = 1, int pageSize = 10)
        {
            return await _policyService.GetAllPolicy(pageIndex, pageSize);
        }
    }
}
