using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IDashboardService
    {
        Task<List<ProductStatisticsDto>> GetSupplierProductStatisticsAsync(string supplierId);
        Task<List<MonthlyOrderCostDto>> GetMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<StaffOrderStatisticsDto> GetStaffOrderStatisticsAsync(string accountId, DateTime startDate, DateTime endDate);
        Task<SupplierOrderStatisticsDto> GetSupplierOrderStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate);
        Task<List<BestSellingCategoryDto>> GetBestSellingCategoriesAsync(DateTime startDate, DateTime endDate);
        Task<List<BestSellingCategoryDto>> GetBestSellingCategoriesForSupplierAsync(string supplierId, DateTime startDate, DateTime endDate);
        Task<double> CalculateTotalRevenueBySupplierAsync(string supplierId);
        Task<List<MonthlyRevenueDto>> CalculateMonthlyRevenueBySupplierAsync(string supplierId, DateTime startDate, DateTime endDate);
        Task<SupplierRatingStatisticsDto> GetSupplierRatingStatisticsAsync(string supplierId);
        Task<SystemRatingStatisticsDto> GetSystemRatingStatisticsAsync();
        Task<SystemPaymentStatisticsDto> GetSystemPaymentStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<SupplierPaymentStatisticsDto> GetSupplierPaymentStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate);
        Task<SupplierTransactionStatisticsDto> GetSupplierTransactionStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate);
        Task<SystemTransactionStatisticsDto> GetSystemTransactionStatisticsAsync(DateTime startDate, DateTime endDate);

        Task<SupplierOrderStatisticsDto> GetOrderStatusStatisticsBySupplierAsync(string supplierId);
        Task<List<MonthlyOrderCostDto>> GetAllMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<List<MonthlyOrderCostDto>> GetMonthlyRentalOrderCostStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<List<MonthlyOrderCostDto>> GetMonthlyPurchaseOrderCostStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<double> GetSystemTotalMoneyAsync();
        Task<List<OrderStatusStatisticsDto>> GetOrderStatusStatisticsAsync();
    }
}
