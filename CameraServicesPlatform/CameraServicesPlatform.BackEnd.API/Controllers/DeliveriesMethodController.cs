using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("deliveriesMethod")]
    [ApiController]
    public class DeliveriesMethodController : ControllerBase
    {
        private readonly IDeliveriesMethodService _deliveriesMethodService;

        public DeliveriesMethodController(IDeliveriesMethodService deliveriesMethodService)
        {
            _deliveriesMethodService = deliveriesMethodService;
        }

        [HttpPost("create-deliveries-method")]
        public async Task<IActionResult> CreateDeliveriesMethod([FromBody] DeliveriesMethodRequest request)
        {
            try
            {
                var response = await _deliveriesMethodService.CreateDeliveriesMethod(request);
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

        [HttpPut("update-report-by-id")]
        public async Task<IActionResult> UpdateDeliveriesMethod(string deliveriesMethodId, [FromBody] DeliveriesMethodRequest request)
        {
            try
            {
                var response = await _deliveriesMethodService.UpdateDeliveriesMethod(deliveriesMethodId, request);
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

        [HttpDelete("delete-report-by-id")]
        public async Task<IActionResult> DeleteDeliveriesMethod(string deliveriesMethodId)
        {
            try
            {
                var response = await _deliveriesMethodService.DeleteDeliveriesMethod(deliveriesMethodId);
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

        [HttpGet("get-report-by-id")]
        public async Task<IActionResult> GetDeliveriesMethodById(string deliveriesMethodId)
        {
            try
            {
                var response = await _deliveriesMethodService.GetDeliveriesMethodById(deliveriesMethodId);
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

        [HttpGet("get-all-deliveries-method")]
        public async Task<AppActionResult> GetAllDeliveriesMethod(int pageIndex = 1, int pageSize = 10)
        {
            return await _deliveriesMethodService.GetAllDeliveriesMethod(pageIndex, pageSize);
        }
    }
}
