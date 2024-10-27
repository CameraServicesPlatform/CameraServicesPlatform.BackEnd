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
