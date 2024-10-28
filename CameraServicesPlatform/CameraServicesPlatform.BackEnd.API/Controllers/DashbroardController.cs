using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("dashbroard")]
    [ApiController]
    public class DashbroardController : ControllerBase
    {
        private readonly IDashbroardService _dashbroardService;

        public DashbroardController(IDashbroardService dashbroardService)
        {
            _dashbroardService = dashbroardService;
        }

        [HttpGet("best-selling-categories")]
        public async Task<ActionResult<List<BestSellingCategoryDto>>> GetBestSellingCategories(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashbroardService.GetBestSellingCategoriesAsync(startDate, endDate);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("best-selling-categories-by-supplier/{supplierId}")]
        public async Task<ActionResult<List<BestSellingCategoryDto>>> GetBestSellingCategoriesForSupplier(string supplierId, DateTime startDate, DateTime endDate)
        {
            try { 
            var result = await _dashbroardService.GetBestSellingCategoriesForSupplierAsync(supplierId, startDate, endDate);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-supplier-product-statistics/{supplierId}")]
        public async Task<ActionResult<List<ProductStatisticsDto>>> GetSupplierProductStatisticsAsync(string supplierId)
        {
            try
            {
                var result = await _dashbroardService.GetSupplierProductStatisticsAsync(supplierId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-month-order-cost-statistics/{supplierId}")]
        public async Task<ActionResult<List<MonthlyOrderCostDto>>> GetMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashbroardService.GetMonthlyOrderCostStatisticsAsync(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-account-order-statistics/{accountId}")]
        public async Task<ActionResult<StaffOrderStatisticsDto>> GetStaffOrderStatisticsAsync(string accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashbroardService.GetStaffOrderStatisticsAsync(accountId ,startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-supplier-order-statistics/{supplierId}")]
        public async Task<ActionResult<SupplierOrderStatisticsDto>> GetSupplierOrderStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashbroardService.GetSupplierOrderStatisticsAsync(supplierId, startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
