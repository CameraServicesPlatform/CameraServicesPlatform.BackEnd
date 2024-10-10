using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReturnDetailController : ControllerBase
    {
        private readonly IReturnDetailService _returnDetailService;

        public ReturnDetailController(IReturnDetailService returnDetailService)
        {
            _returnDetailService = returnDetailService;
        }

        [HttpPost("create-return")]
        public async Task<IActionResult> CreateReturnDetail([FromBody] ReturnDetailRequest request)
        {
            try
            {
                var response = await _returnDetailService.CreateReturnDetail(request);
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

        [HttpPut("update-return-detail-by-id")]
        public async Task<IActionResult> UpdateReturnDetail(string ReturnId, [FromBody] ReturnDetailRequest request)
        {
            try
            {
                var response = await _returnDetailService.UpdateReturnDetail(ReturnId, request);
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

        [HttpDelete("delete-return-detail-by-id")]
        public async Task<IActionResult> DeleteReturnDetail(string ReturnId)
        {
            try
            {
                var response = await _returnDetailService.DeleteReturnDetail(ReturnId);
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

        [HttpGet("get-return-detail-by-id")]
        public async Task<IActionResult> GetReturnDetailById(string returnId)
        {
            try
            {
                var response = await _returnDetailService.GetReturnDetailById(returnId);
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

        [HttpGet("get-all-return-detail")]
        public async Task<AppActionResult> GetAllReturnDetail(int pageIndex = 1, int pageSize = 10)
        {
            return await _returnDetailService.GetAllReturnDetail(pageIndex, pageSize);
        }
    }
}
