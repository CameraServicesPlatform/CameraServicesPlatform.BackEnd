using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("extend")]
    [ApiController]
    public class ExtendController : ControllerBase
    {
        private readonly IExtendService _extendService;

        public ExtendController(IExtendService extendService)
        {
            _extendService = extendService;
        }

        [HttpPost("create-extend")]
        public async Task<IActionResult> CreateExtendl([FromBody] CreateExtendRequest request)
        {
            try
            {
                var response = await _extendService.CreateExtend(request);
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

        [HttpGet("get-extend-by-id")]
        public async Task<IActionResult> GetExtendById(string extensID)
        {
            try
            {
                var response = await _extendService.GetExtendById(extensID);
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

        [HttpGet("get-extend-by-order-id")]
        public async Task<IActionResult> GetExtendByOrderId(string orderID, int pageIndex, int pageSize)
        {
            try
            {
                var response = await _extendService.GetExtendByOrderId(orderID, pageIndex, pageSize);
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

    }
}
