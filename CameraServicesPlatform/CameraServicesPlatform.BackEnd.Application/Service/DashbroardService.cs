using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class DashbroardService : GenericBackendService, IDashbroardService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DashbroardService(
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Account> accountRepository,
            IRepository<Product> productRepository,
            IRepository<Contract> contractRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierOrderStatisticsDto> GetSupplierOrderStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var ordersResult = await _orderRepository.GetAllDataByExpression(
                x => x.SupplierID == Guid.Parse(supplierId) && x.OrderDate >= startDate && x.OrderDate <= endDate,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
            );

            var totalSales = ordersResult.Items.Sum(order => order.TotalAmount); 
            var totalOrders = ordersResult.Items.Count;
            var pendingOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Pending);
            var completedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Completed);
            var canceledOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Cancelled);

            return new SupplierOrderStatisticsDto
            {
                TotalSales = (double)totalSales,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders,
                CanceledOrders = canceledOrders
            };
        }

        public async Task<StaffOrderStatisticsDto> GetStaffOrderStatisticsAsync(string accountId, DateTime startDate, DateTime endDate)
        {
            var ordersResult = await _orderRepository.GetAllDataByExpression(
                x => x.Id == accountId && x.OrderDate >= startDate && x.OrderDate <= endDate,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
            );

            var totalSales = ordersResult.Items.Sum(order => order.TotalAmount);
            var totalOrders = ordersResult.Items.Count;
            var pendingOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Pending);
            var completedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Completed);
            var canceledOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Cancelled);

            return new StaffOrderStatisticsDto
            {
                TotalSales = (double)totalSales,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders,
                CanceledOrders = canceledOrders
            };
        }

        public async Task<List<MonthlyOrderCostDto>> GetMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var monthlyCosts = new List<MonthlyOrderCostDto>();

            var orders = await _orderRepository.GetAllDataByExpression(
                x => x.OrderDate >= startDate && x.OrderDate <= endDate,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
            );

            var groupedData = orders.Items
                .GroupBy(order => new { order.OrderDate.Year, order.OrderDate.Month })
                .Select(g => new MonthlyOrderCostDto
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalCost = (double)g.Sum(order => order.TotalAmount) 
                });

            monthlyCosts.AddRange(groupedData);
            return monthlyCosts;
        }
        public async Task<List<ProductStatisticsDto>> GetSupplierProductStatisticsAsync(string supplierId)
        {
            var products = await _productRepository.GetAllDataByExpression(
                x => x.SupplierID == Guid.Parse(supplierId),
                1, int.MaxValue

            );

            var productStatistics = new List<ProductStatisticsDto>();

            foreach (var product in products.Items)
            {
                var orderDetails = await _orderDetailRepository.GetAllDataByExpression(
                    od => od.ProductID == product.ProductID, 
                    1, int.MaxValue
                );

                productStatistics.Add(new ProductStatisticsDto
                {
                    ProductId = product.ProductID.ToString(),
                    ProductName = product.ProductName
                });
            }

            return productStatistics;
        }

        public async Task<List<BestSellingCategoryDto>> GetBestSellingCategoriesAsync(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                o => o.OrderDate >= startDate && o.OrderDate <= endDate,
                1, int.MaxValue,
                 includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
            );

            var categorySales = new Dictionary<string, BestSellingCategoryDto>(); 

            foreach (var order in orders.Items)
            {
                foreach (var detail in order.OrderDetail)
                {
                    var product = await _productRepository.GetById(detail.ProductID);
                    if (product != null)
                    {
                        var productWithCategory = await _productRepository.GetByExpression(
                                                   p => p.ProductID == detail.ProductID,
                                                   p => p.Category
                                                    );
                        if (!categorySales.ContainsKey(productWithCategory.CategoryID.ToString()))
                        {
                            categorySales[product.CategoryID.ToString()] = new BestSellingCategoryDto
                            {
                                CategoryID = product.CategoryID.ToString(),
                                CategoryName = product.Category.CategoryName, 
                                TotalSold = 0 
                            };
                        }

                        categorySales[product.CategoryID.ToString()].TotalSold += 1; 
                    }
                }
            }

            return categorySales.Values.OrderByDescending(c => c.TotalSold).ToList();
        }

        public async Task<List<BestSellingCategoryDto>> GetBestSellingCategoriesForSupplierAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                o => o.OrderDate >= startDate && o.OrderDate <= endDate && o.SupplierID == Guid.Parse(supplierId),
                1, int.MaxValue,
                 includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
            );

            var categorySales = new Dictionary<string, BestSellingCategoryDto>(); 
            foreach (var order in orders.Items)
            {
                foreach (var detail in order.OrderDetail)
                {
                    var product = await _productRepository.GetById(detail.ProductID);
                    if (product != null)
                    {
                        if (!categorySales.ContainsKey(product.CategoryID.ToString()))
                        {
                            categorySales[product.CategoryID.ToString()] = new BestSellingCategoryDto
                            {
                                CategoryID = product.CategoryID.ToString(),
                                CategoryName = product.Category.CategoryName, 
                                TotalSold = 0 
                            };
                        }

                        categorySales[product.CategoryID.ToString()].TotalSold += 1; 
                    }
                }
            }
            return categorySales.Values.OrderByDescending(c => c.TotalSold).ToList();
        }

        public async Task<double> CalculateTotalRevenueBySupplierAsync(string supplierId)
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                filter: o => o.SupplierID == Guid.Parse(supplierId) && o.OrderStatus == OrderStatus.Completed,
                pageNumber: 0,
                pageSize: 0
            );

            var totalRevenue = orders.Items.Sum(o => o.TotalAmount);

            return (double)totalRevenue;
        }

        public async Task<List<MonthlyRevenueDto>> CalculateMonthlyRevenueBySupplierAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                filter: o => o.SupplierID == Guid.Parse(supplierId)
                             && o.OrderDate >= startDate
                             && o.OrderDate <= endDate
                             && o.OrderStatus == OrderStatus.Completed,
                pageNumber: 0,
                pageSize: 0 
            );

            var monthlyRevenue = orders.Items
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new MonthlyRevenueDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = (double)g.Sum(o => o.TotalAmount)
                })
                .OrderBy(r => r.Year).ThenBy(r => r.Month)  
                .ToList();

            return monthlyRevenue;
        }

    }
}
