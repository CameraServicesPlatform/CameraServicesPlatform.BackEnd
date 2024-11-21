using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

      

        [HttpPut("update-staff-by-id")]
        public async Task<IActionResult> UpdateStaff(string StaffID, [FromBody] StaffRequestDTO request)
        {
            try
            {
                var response = await _staffService.UpdateStaff(StaffID, request);
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

        [HttpPut("delete-staff-by-id")]
        public async Task<IActionResult> DeleteStaff(string StaffID)
        {
            try
            {
                var response = await _staffService.DeleteStaff(StaffID);
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

        [HttpGet("get-staff-by-id")]
        public async Task<IActionResult> GetStaffById(string StaffID, int pageIndex, int pageSize)
        {
            try
            {
                var response = await _staffService.GetStaffById(StaffID, pageIndex, pageSize);
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

        [HttpGet("get-staff-by-staff-name")]
        public async Task<IActionResult> GetStaffByName([FromQuery] string? name, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            try
            {
                var response = await _staffService.GetStaffByName(name, pageIndex, pageSize);
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

        [HttpGet("get-all-staff")]
        public async Task<AppActionResult> GetAllStaff(int pageIndex, int pageSize)
        {
            return await _staffService.GetAllStaff(pageIndex, pageSize);
        }

        [HttpGet("get-all-account-inactive")]
        public async Task<AppActionResult> GetAllAccountNotActive(int pageIndex, int pageSize)
        {
            return await _staffService.GetAllAccountNotActive(pageIndex, pageSize);
        }

        [HttpGet("get-all-account-active")]
        public async Task<AppActionResult> GetAllAccountActive(int pageIndex, int pageSize)
        {
            return await _staffService.GetAllAccountActive(pageIndex, pageSize);
        }
    }
}
