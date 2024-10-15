using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("create-Report")]
        public async Task<IActionResult> CreateReport([FromBody] ReportRequest request)
        {
            try
            {
                var response = await _reportService.CreateReport(request);
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
        public async Task<IActionResult> UpdateReport(string reportId, [FromBody] ReportRequest request)
        {
            try
            {
                var response = await _reportService.UpdateReport(reportId, request);
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
        public async Task<IActionResult> DeleteReport(string reportId)
        {
            try
            {
                var response = await _reportService.DeleteReport(reportId);
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
        public async Task<IActionResult> GetReportById(string reportId)
        {
            try 
            {
                var response = await _reportService.GetReportById(reportId);
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

        [HttpGet("get-all-reports")]
        public async Task<AppActionResult> GetAllReports(int pageIndex = 1, int pageSize = 10)
        {
            return await _reportService.GetAllReport(pageIndex, pageSize);
        }
    }
}
