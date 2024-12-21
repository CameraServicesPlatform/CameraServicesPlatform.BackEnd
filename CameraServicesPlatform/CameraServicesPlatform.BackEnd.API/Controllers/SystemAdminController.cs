using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("SystemAdmin")]
    [ApiController]
    public class SystemAdminController : ControllerBase
    {
        private readonly ISystemAdminService _systemAdminService;

        public SystemAdminController(
        ISystemAdminService systemAdminService
        )
        {
            _systemAdminService = systemAdminService;
        }

        [HttpGet("get-all-system-admins")]
        public async Task<IActionResult> GetAllSystemAdmins(int pageNumber, int pageSize)
        {
            var result = await _systemAdminService.GetAllSystemAdmins(pageNumber, pageSize);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create-system-admin")]
        public async Task<IActionResult> CreateSystemAdmin([FromBody] SystemAdminRequestDTO request)
        {
            var result = await _systemAdminService.CreateSystemAdmin(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-new-cancel-accept-value")]
        public async Task<IActionResult> GetNewCancelAcceptValue()
        {
            var result = await _systemAdminService.GetNewCancelAcceptValue();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-new-cancel-value")]
        public async Task<IActionResult> GetNewCancelValue()
        {
            var result = await _systemAdminService.GetNewCancelValue();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-new-reservation-money")]
        public async Task<IActionResult> GetNewReservationMoney()
        {
            var result = await _systemAdminService.GetNewReservationMoney();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
