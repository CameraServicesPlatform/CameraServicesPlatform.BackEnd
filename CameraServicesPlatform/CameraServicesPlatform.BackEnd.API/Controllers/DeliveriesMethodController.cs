using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
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

        [HttpPost("create-deliveries-method")]
        public async Task<IActionResult> CreateDeliveriesMethod(DeliveriesMethodRequest request)
        {
            try
            {
                var response = await _deliveriesMethodService.CreateDeliveriesMethod(request);
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

        [HttpPut("update-deliveries-method")]
        public async Task<IActionResult> UpdateDeliveriesMethod(DeliveriesMethodUpdateRequest request)
        {
            try
            {
                var response = await _deliveriesMethodService.UpdateDeliveriesMethod(request);
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
