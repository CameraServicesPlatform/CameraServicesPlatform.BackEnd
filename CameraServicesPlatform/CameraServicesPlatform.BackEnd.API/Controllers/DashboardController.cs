using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("best-selling-categories-by-supplier-id/{supplierId}")]
        public async Task<ActionResult<List<BestSellingCategoryDto>>> GetBestSellingCategoriesForSupplier(string supplierId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetBestSellingCategoriesForSupplierAsync(supplierId, startDate, endDate);
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
                var result = await _dashboardService.GetSupplierProductStatisticsAsync(supplierId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-month-order-cost-statistics-by-supplier-id/{supplierId}")]
        public async Task<ActionResult<List<MonthlyOrderCostDto>>> GetMonthlyOrderCostStatisticsBySupplierIDAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetMonthlyOrderCostStatisticsBySupplierIDAsync(supplierId, startDate, endDate);
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
                var result = await _dashboardService.GetSupplierOrderStatisticsAsync(supplierId, startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-calculate-total-revenue-by-supplier/{supplierId}")]
        public async Task<ActionResult<double>> CalculateTotalRevenueBySupplierAsync(string supplierId)
        {
            try
            {
                var result = await _dashboardService.CalculateTotalRevenueBySupplierAsync(supplierId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-calculate-monthly-revenue-by-supplier/{supplierId}")]
        public async Task<ActionResult<List<MonthlyRevenueDto>>> CalculateMonthlyRevenueBySupplierAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.CalculateMonthlyRevenueBySupplierAsync(supplierId, startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // rating
        [HttpGet("supplier-rating-statistics/{supplierId}")]
        public async Task<IActionResult> GetSupplierRatingStatistics(string supplierId)
        {
            var result = await _dashboardService.GetSupplierRatingStatisticsAsync(supplierId);
            return Ok(result);
        }

        // payment
        [HttpGet("supplier-payment-statistics/{supplierId}")]
        public async Task<IActionResult> GetSupplierPaymentStatistics(string supplierId, DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetSupplierPaymentStatisticsAsync(supplierId, startDate, endDate);
            return Ok(result);
        }

        [HttpGet("supplier-transaction-statistics/{supplierId}")]
        public async Task<IActionResult> GetSupplierTransactionStatistics(string supplierId, DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetSupplierTransactionStatisticsAsync(supplierId, startDate, endDate);
            return Ok(result);
        }

        [HttpGet("get-order-status-statistics-by-supplier-id/{supplierId}")]
        public async Task<IActionResult> GetOrderStatusStatisticsBySupplierAsync(string supplierId)
        {
            var result = await _dashboardService.GetOrderStatusStatisticsBySupplierAsync(supplierId);
            return Ok(result);
        }

        [HttpGet("get-account-order-statistics-by-account-id/{accountId}")]
        public async Task<ActionResult<StaffOrderStatisticsDto>> GetStaffOrderStatisticsAsync(string accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetStaffOrderStatisticsAsync(accountId, startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("system-rating-statistics")]
        public async Task<IActionResult> GetSystemRatingStatistics()
        {
            var result = await _dashboardService.GetSystemRatingStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("system-payment-statistics")]
        public async Task<IActionResult> GetSystemPaymentStatistics(DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetSystemPaymentStatisticsAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("best-selling-categories")]
        public async Task<ActionResult<List<BestSellingCategoryDto>>> GetBestSellingCategories(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetBestSellingCategoriesAsync(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("system-transaction-statistics")]
        public async Task<IActionResult> GetSystemTransactionStatistics(DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetSystemTransactionStatisticsAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("get-month-order-purchase-statistics")]
        public async Task<IActionResult> GetMonthlyPurchaseOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetMonthlyPurchaseOrderCostStatisticsAsync(startDate, endDate);
            return Ok(result);
        }
        [HttpGet("get-month-order-rent-statistics")]
        public async Task<IActionResult> GetMonthlyRentalOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetMonthlyRentalOrderCostStatisticsAsync(startDate, endDate);
            return Ok(result);
        }
        [HttpGet("get-all-month-order-cost-statistics")]
        public async Task<IActionResult> GetAllMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _dashboardService.GetAllMonthlyOrderCostStatisticsAsync(startDate, endDate);
            return Ok(result);
        }
        
        [HttpGet("get-order-status-statistics")]
        public async Task<IActionResult> GetOrderStatusStatisticsAsync( )
        {
            var result = await _dashboardService.GetOrderStatusStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("get-month-order-cost-statistics")]
        public async Task<ActionResult<List<MonthlyOrderCostDto>>> GetMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetMonthlyOrderCostStatisticsAsync(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-system-total-money-statistics")]
        public async Task<IActionResult> GetSystemTotalMoneyAsync()
        {
            var result = await _dashboardService.GetSystemTotalMoneyAsync();
            return Ok(result);
        }
    }
}
