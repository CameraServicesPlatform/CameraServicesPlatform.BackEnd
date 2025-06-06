﻿using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.Linq.Expressions;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class DashboardService : GenericBackendService, IDashboardService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<Report> _reportRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<Staff> _staffRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Combo> _comboRepository;
        private readonly IRepository<ProductReport> _productReportRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Rating> ratingRepository,
            IRepository<Payment> paymentRepository,
            IRepository<Transaction> transactionRepository,
            IRepository<Account> accountRepository,
            IRepository<Product> productRepository,
            IRepository<Contract> contractRepository,
            IRepository<Report> reportRepository,
            IRepository<Supplier> supplierRepository,
            IRepository<Staff> staffRepository,
            IRepository<Category> categoryRepository,
            IRepository<Combo> comboRepository,
            IRepository<ProductReport> productReportRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _ratingRepository = ratingRepository;
            _paymentRepository = paymentRepository;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _contractRepository = contractRepository;
            _reportRepository = reportRepository;
            _supplierRepository = supplierRepository;
            _staffRepository = staffRepository;
            _categoryRepository = categoryRepository;
            _comboRepository = comboRepository;
            _orderRepository = orderRepository;
            _productReportRepository = productReportRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*public async Task<SupplierOrderStatisticsDto> GetSupplierOrderStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var ordersResult = await _orderRepository.GetAllDataByExpression(
                x => x.SupplierID == Guid.Parse(supplierId) || x.OrderDate >= startDate && x.OrderDate <= endDate,
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
            var approvedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Approved);
            var placedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Placed);
            var shippedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Shipped);
            var paymentFailOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.PaymentFail);
            var cancelingOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Canceling);
            var paymentOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Payment);
            var pendingRefundOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.PendingRefund);
            var refundOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Refund);
            var depositReturnOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.DepositReturn);
            var extendOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Extend);

            return new SupplierOrderStatisticsDto
            {
                TotalSales = (double)totalSales,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders,
                CanceledOrders = canceledOrders,
                ApprovedOrders = approvedOrders,
                PlacedOrders = placedOrders,
                ShippedOrders = shippedOrders,
                PaymentFailOrders = paymentFailOrders,
                CancelingOrders = cancelingOrders,
                PaymentOrders = paymentOrders,
                PendingRefundOrders = pendingRefundOrders,
                RefundOrders = refundOrders,
                DepositReturnOrders = depositReturnOrders,
                ExtendOrders = extendOrders
            };
        }*/

        public async Task<SupplierOrderStatisticsDto> GetSupplierOrderStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var ordersResult = await _orderRepository.GetAllDataByExpression(
                x => x.SupplierID == Guid.Parse(supplierId),
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
            var approvedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Approved);
            var placedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Placed);
            var shippedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Shipped);
            var paymentFailOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.PaymentFail);
            var cancelingOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Canceling);
            var paymentOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Payment);
            var pendingRefundOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.PendingRefund);
            var refundOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Refund);
            var depositReturnOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.DepositReturn);
            var extendOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Extend);

            return new SupplierOrderStatisticsDto
            {
                TotalSales = (double)totalSales,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders,
                CanceledOrders = canceledOrders,
                ApprovedOrders = approvedOrders,
                PlacedOrders = placedOrders,
                ShippedOrders = shippedOrders,
                PaymentFailOrders = paymentFailOrders,
                CancelingOrders = cancelingOrders,
                PaymentOrders = paymentOrders,
                PendingRefundOrders = pendingRefundOrders,
                RefundOrders = refundOrders,
                DepositReturnOrders = depositReturnOrders,
                ExtendOrders = extendOrders
            };
        }
        public async Task<StaffOrderStatisticsDto> GetStaffOrderStatisticsAsync(string accountId, DateTime startDate, DateTime endDate)
        {
            var ordersResult = await _orderRepository.GetAllDataByExpression(
                x => x.Id == accountId || x.OrderDate >= startDate && x.OrderDate <= endDate,
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
                x => x.OrderDate >= startDate || x.OrderDate <= endDate,
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
        public async Task<List<MonthlyOrderCostDto>> GetMonthlyOrderCostStatisticsBySupplierIDAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var monthlyCosts = new List<MonthlyOrderCostDto>();

            if (!Guid.TryParse(supplierId, out Guid supplierGuid))
            {
                throw new ArgumentException("Invalid supplier ID format.", nameof(supplierId));
            }

            var orders = await _orderRepository.GetAllDataByExpression(
                x => x.SupplierID == supplierGuid || x.OrderDate >= startDate && x.OrderDate <= endDate,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                {
            o => o.OrderDetail
                }
            );

            var groupedData = orders.Items
                .GroupBy(order => new { order.OrderDate.Year, order.OrderDate.Month })
                .Select(g => new MonthlyOrderCostDto
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalCost = g.Sum(order => order.TotalAmount)
                })
                .ToList();

            monthlyCosts.AddRange(groupedData);
            return monthlyCosts;
        }

        public async Task<List<ProductStatisticsDto>> GetSupplierProductStatisticsAsync(string supplierId)
        {
            if (!Guid.TryParse(supplierId, out Guid supplierGuid))
            {
                throw new ArgumentException("Invalid supplier ID format.", nameof(supplierId));
            }

            var productStatistics = new List<ProductStatisticsDto>();
            var orders = await _orderRepository.GetAllDataByExpression(
                o => o.SupplierID == supplierGuid,
                1, int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                {
            o => o.OrderDetail,
                }
            );

            foreach (var order in orders.Items)
            {
                foreach (var detail in order.OrderDetail)
                {
                    var product = await _productRepository.GetByExpression(x => x.ProductID == detail.ProductID, x => x.Category);
                    productStatistics.Add(new ProductStatisticsDto
                    {
                        ProductId = product.ProductID.ToString(),
                        ProductName = product.ProductName
                    });
                }
            }

            return productStatistics;
        }

        public async Task<List<BestSellingCategoryDto>> GetBestSellingCategoriesAsync(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                o => o.OrderDate >= startDate || o.OrderDate <= endDate,
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
            if (!Guid.TryParse(supplierId, out Guid supplierGuid))
            {
                throw new ArgumentException("Invalid supplier ID format.", nameof(supplierId));
            }

            var orders = await _orderRepository.GetAllDataByExpression(
                o => o.SupplierID == supplierGuid || o.OrderDate >= startDate && o.OrderDate <= endDate,
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
                    var product = await _productRepository.GetByExpression(x => x.ProductID == detail.ProductID, x => x.Category);
                    if (product != null && product.CategoryID != null) // Add null check for product.Category
                    {
                        var categoryId = product.CategoryID.ToString();

                        if (!categorySales.ContainsKey(categoryId))
                        {
                            categorySales[categoryId] = new BestSellingCategoryDto
                            {
                                CategoryID = categoryId,
                                CategoryName = product.Category.CategoryName,
                                TotalSold = 0
                            };
                        }

                        categorySales[categoryId].TotalSold += 1;
                    }
                }
            }

            return categorySales.Values.OrderByDescending(c => c.TotalSold).ToList();
        }

        public async Task<double> CalculateTotalRevenueBySupplierAsync(string supplierId)
        {
            double totalMoney = 0;

            // Tiền từ các đơn hàng hoàn thành
            var completedOrders = await _orderRepository.GetAllDataByExpression(
                x => x.OrderStatus != OrderStatus.Cancelled && x.SupplierID == Guid.Parse(supplierId),
                1,
                int.MaxValue
            );
            totalMoney += (double)completedOrders.Items.Sum(order => order.TotalAmount);

            return totalMoney;
        }

        public async Task<List<MonthlyRevenueDto>> CalculateMonthlyRevenueBySupplierAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                filter: o => o.SupplierID == Guid.Parse(supplierId)
                             && o.OrderStatus == OrderStatus.Completed
                             || o.OrderDate >= startDate
                             && o.OrderDate <= endDate,
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
        /// rating
        public async Task<SupplierRatingStatisticsDto> GetSupplierRatingStatisticsAsync(string supplierId)
        {
            // Lấy tất cả sản phẩm của supplier
            var products = await _productRepository.GetAllDataByExpression(
                filter: p => p.SupplierID == Guid.Parse(supplierId),
                pageNumber: 0,
                pageSize: 0
            );

            // Lấy danh sách các ProductID của supplier
            var productIds = products.Items.Select(p => p.ProductID).ToList();

            // Lấy tất cả đánh giá thuộc các sản phẩm của supplier
            var ratings = await _ratingRepository.GetAllDataByExpression(
                filter: r => productIds.Contains(r.ProductID) && !r.IsDisable,
                pageNumber: 0,
                pageSize: 0
            );

            // Tính toán các chỉ số
            var totalRatings = ratings.Items.Count;
            var averageRating = totalRatings > 0 ? ratings.Items.Average(r => r.RatingValue) : 0;

            // Phân loại số lượng đánh giá theo giá trị 1-5
            var ratingDistribution = ratings.Items
                .GroupBy(r => r.RatingValue)
                .Select(g => new RatingDistribution
                {
                    RatingValue = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return new SupplierRatingStatisticsDto
            {
                TotalRatings = totalRatings,
                AverageRating = averageRating,
                RatingDistribution = ratingDistribution
            };
        }

        public async Task<SystemRatingStatisticsDto> GetSystemRatingStatisticsAsync()
        {
            // Lấy tất cả đánh giá không bị ẩn trong hệ thống
            var ratings = await _ratingRepository.GetAllDataByExpression(
                filter: r => !r.IsDisable,
                pageNumber: 0,
                pageSize: 0
            );

            // Tính toán các chỉ số hệ thống
            var totalRatings = ratings.Items.Count;
            var averageRating = totalRatings > 0 ? ratings.Items.Average(r => r.RatingValue) : 0;

            // Phân loại số lượng đánh giá theo giá trị 1-5 trên toàn hệ thống
            var ratingDistribution = ratings.Items
                .GroupBy(r => r.RatingValue)
                .Select(g => new RatingDistribution
                {
                    RatingValue = g.Key,
                    Count = g.Count()
                })
                .ToList();

            // Lấy sản phẩm có đánh giá cao nhất
            var topRatedProducts = ratings.Items
                .GroupBy(r => r.ProductID)
                .Select(g => new TopRatedProductDto
                {
                    ProductID = g.Key,
                    AverageRating = g.Average(r => r.RatingValue),
                    TotalRatings = g.Count()
                })
                .OrderByDescending(p => p.AverageRating)
                .ThenByDescending(p => p.TotalRatings)
                .Take(5)
                .ToList();

            return new SystemRatingStatisticsDto
            {
                TotalRatings = totalRatings,
                AverageRating = averageRating,
                RatingDistribution = ratingDistribution,
                TopRatedProducts = topRatedProducts
            };
        }
        //Payment
        public async Task<SupplierPaymentStatisticsDto> GetSupplierPaymentStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            // Lấy tất cả thanh toán thuộc về supplier trong khoảng thời gian xác định
            var payments = await _paymentRepository.GetAllDataByExpression(
                filter: p => p.SupplierID == Guid.Parse(supplierId) || p.PaymentDate >= startDate && p.PaymentDate <= endDate,
                pageNumber: 0,
                pageSize: 0
            );

            var totalRevenue = payments.Items.Sum(p => p.PaymentAmount);
            var paymentCount = payments.Items.Count;

            // Thống kê doanh thu theo phương thức thanh toán
            var revenueByMethod = payments.Items
                .GroupBy(p => p.PaymentMethod)
                .Select(g => new RevenueByMethodDto
                {
                    PaymentMethod = g.Key,
                    TotalRevenue = g.Sum(p => p.PaymentAmount),
                    PaymentCount = g.Count()
                }).ToList();

            // Thống kê trạng thái thanh toán
            var paymentStatusCounts = payments.Items
                .GroupBy(p => p.PaymentStatus)
                .Select(g => new PaymentStatusCountDto
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();

            // Doanh thu hàng tháng
            var monthlyRevenue = payments.Items
                .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                .Select(g => new MonthlyRevenueDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(p => p.PaymentAmount)
                }).OrderBy(m => m.Year).ThenBy(m => m.Month)
                .ToList();

            return new SupplierPaymentStatisticsDto
            {
                TotalRevenue = totalRevenue,
                PaymentCount = paymentCount,
                RevenueByMethod = revenueByMethod,
                PaymentStatusCounts = paymentStatusCounts,
                MonthlyRevenue = monthlyRevenue
            };
        }

        public async Task<SystemPaymentStatisticsDto> GetSystemPaymentStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            // Lấy tất cả các thanh toán trong hệ thống trong khoảng thời gian xác định
            var payments = await _paymentRepository.GetAllDataByExpression(
                filter: p => p.PaymentDate >= startDate && p.PaymentDate <= endDate || !p.IsDisable,
                pageNumber: 0,
                pageSize: 0
            );

            var totalRevenue = payments.Items.Sum(p => p.PaymentAmount);
            var paymentCount = payments.Items.Count;

            // Doanh thu và số lượng thanh toán theo phương thức
            var revenueByMethod = payments.Items
                .GroupBy(p => p.PaymentMethod)
                .Select(g => new RevenueByMethodDto
                {
                    PaymentMethod = g.Key,
                    TotalRevenue = g.Sum(p => p.PaymentAmount),
                    PaymentCount = g.Count()
                }).ToList();

            // Trạng thái thanh toán
            var paymentStatusCounts = payments.Items
                .GroupBy(p => p.PaymentStatus)
                .Select(g => new PaymentStatusCountDto
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();

            // Doanh thu hàng tháng của toàn hệ thống
            var monthlyRevenue = payments.Items
                .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                .Select(g => new MonthlyRevenueDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(p => p.PaymentAmount)
                }).OrderBy(m => m.Year).ThenBy(m => m.Month)
                .ToList();

            // Thống kê doanh thu theo từng supplier
            var revenueBySupplier = payments.Items
                .GroupBy(p => p.SupplierID)
                .Select(g => new RevenueBySupplierDto
                {
                    SupplierID = g.Key,
                    TotalRevenue = g.Sum(p => p.PaymentAmount),
                    PaymentCount = g.Count()
                }).ToList();

            return new SystemPaymentStatisticsDto
            {
                TotalRevenue = totalRevenue,
                PaymentCount = paymentCount,
                RevenueByMethod = revenueByMethod,
                PaymentStatusCounts = paymentStatusCounts,
                MonthlyRevenue = monthlyRevenue,
                RevenueBySupplier = revenueBySupplier
            };
        }

        // transaction
        public async Task<SupplierTransactionStatisticsDto> GetSupplierTransactionStatisticsAsync(string supplierId, DateTime startDate, DateTime endDate)
        {
            // Lấy các giao dịch của supplier trong khoảng thời gian
            var transactions = await _transactionRepository.GetAllDataByExpression(
                filter: t => t.Order.SupplierID == Guid.Parse(supplierId) || t.TransactionDate >= startDate && t.TransactionDate <= endDate,
                pageNumber: 0,
                pageSize: 0,
                includes: t => t.Order
            );

            var totalRevenue = transactions.Items.Sum(t => t.Amount);
            var transactionCount = transactions.Items.Count;

            // Thống kê doanh thu theo loại giao dịch
            var revenueByTransactionType = transactions.Items
                .GroupBy(t => t.TransactionType)
                .Select(g => new RevenueByTransactionTypeDto
                {
                    TransactionType = g.Key,
                    TotalRevenue = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                }).ToList();

            // Phân tích doanh thu theo phương thức thanh toán
            var revenueByMethod = transactions.Items
                .GroupBy(t => t.PaymentMethod)
                .Select(g => new RevenueByMethodDto
                {
                    PaymentMethod = g.Key,
                    TotalRevenue = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                }).ToList();

            // Thống kê trạng thái giao dịch
            var transactionStatusCounts = transactions.Items
                .GroupBy(t => t.PaymentStatus)
                .Select(g => new TransactionStatusCountDto
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();

            // Doanh thu hàng tháng
            var monthlyRevenue = transactions.Items
                .GroupBy(t => new { t.TransactionDate.Year, t.TransactionDate.Month })
                .Select(g => new MonthlyRevenueDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(t => t.Amount)
                }).OrderBy(m => m.Year).ThenBy(m => m.Month)
                .ToList();

            return new SupplierTransactionStatisticsDto
            {
                TotalRevenue = totalRevenue,
                TransactionCount = transactionCount,
                RevenueByTransactionType = revenueByTransactionType,
                RevenueByMethod = revenueByMethod,
                TransactionStatusCounts = transactionStatusCounts,
                MonthlyRevenue = monthlyRevenue
            };
        }

        public async Task<SystemTransactionStatisticsDto> GetSystemTransactionStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            // Lấy tất cả giao dịch trong hệ thống trong khoảng thời gian
            var transactions = await _transactionRepository.GetAllDataByExpression(
                filter: t => t.TransactionDate >= startDate || t.TransactionDate <= endDate,
                pageNumber: 0,
                pageSize: 0,
                includes: t => t.Order
            );

            var totalRevenue = transactions.Items.Sum(t => t.Amount);
            var transactionCount = transactions.Items.Count;

            // Thống kê doanh thu theo loại giao dịch
            var revenueByTransactionType = transactions.Items
                .GroupBy(t => t.TransactionType)
                .Select(g => new RevenueByTransactionTypeDto
                {
                    TransactionType = g.Key,
                    TotalRevenue = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                }).ToList();

            // Phân tích doanh thu theo phương thức thanh toán
            var revenueByMethod = transactions.Items
                .GroupBy(t => t.PaymentMethod)
                .Select(g => new RevenueByMethodDto
                {
                    PaymentMethod = g.Key,
                    TotalRevenue = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                }).ToList();

            // Thống kê trạng thái giao dịch
            var transactionStatusCounts = transactions.Items
                .GroupBy(t => t.PaymentStatus)
                .Select(g => new TransactionStatusCountDto
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();

            // Doanh thu hàng tháng
            var monthlyRevenue = transactions.Items
                .GroupBy(t => new { t.TransactionDate.Year, t.TransactionDate.Month })
                .Select(g => new MonthlyRevenueDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(t => t.Amount)
                }).OrderBy(m => m.Year).ThenBy(m => m.Month)
                .ToList();

            // Thống kê doanh thu theo từng supplier
            var revenueBySupplier = transactions.Items
                .GroupBy(t => t.Order.SupplierID)
                .Select(g => new RevenueBySupplierDto
                {
                    SupplierID = g.Key,
                    TotalRevenue = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                }).ToList();

            return new SystemTransactionStatisticsDto
            {
                TotalRevenue = totalRevenue,
                TransactionCount = transactionCount,
                RevenueByTransactionType = revenueByTransactionType,
                RevenueByMethod = revenueByMethod,
                TransactionStatusCounts = transactionStatusCounts,
                MonthlyRevenue = monthlyRevenue,
                RevenueBySupplier = revenueBySupplier
            };
        }

        // Tổng đơn mua
        public async Task<List<MonthlyOrderCostDto>> GetMonthlyPurchaseOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var monthlyCosts = new List<MonthlyOrderCostDto>();

            var purchaseOrders = await _orderRepository.GetAllDataByExpression(
                x => x.OrderType == OrderType.Purchase,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.OrderDetail,
                }
            );

            var groupedData = purchaseOrders.Items
                .GroupBy(order => new { order.OrderDate.Year, order.OrderDate.Month })
                .Select(g => new MonthlyOrderCostDto
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalCost = (double)g.Sum(order => order.TotalAmount)
                });

            monthlyCosts.AddRange(groupedData);
            return monthlyCosts;
        }

        // Tổng đơn thuê
        public async Task<List<MonthlyOrderCostDto>> GetMonthlyRentalOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var monthlyCosts = new List<MonthlyOrderCostDto>();

            var rentalOrders = await _orderRepository.GetAllDataByExpression(
                 x => x.OrderType == OrderType.Rental,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.OrderDetail,
                }
            );

            var groupedData = rentalOrders.Items
                .GroupBy(order => new { order.OrderDate.Year, order.OrderDate.Month })
                .Select(g => new MonthlyOrderCostDto
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalCost = (double)g.Sum(order => order.TotalAmount)
                });

            monthlyCosts.AddRange(groupedData);
            return monthlyCosts;
        }

        // Tổng đơn
        public async Task<List<MonthlyOrderCostDto>> GetAllMonthlyOrderCostStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            var monthlyCosts = new List<MonthlyOrderCostDto>();

            var rentalOrders = await _orderRepository.GetAllDataByExpression(
                null,
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.OrderDetail,
                }
            );

            var groupedData = rentalOrders.Items
                .GroupBy(order => new { order.OrderDate.Year, order.OrderDate.Month })
                .Select(g => new MonthlyOrderCostDto
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalCost = (double)g.Sum(order => order.TotalAmount)
                });

            monthlyCosts.AddRange(groupedData);
            return monthlyCosts;
        }

        //thống kê trạng thái đơn hàng
        public async Task<SupplierOrderStatisticsDto> GetOrderStatusStatisticsBySupplierAsync(string supplierId)
        {
            var ordersResult = await _orderRepository.GetAllDataByExpression(
                x => x.SupplierID == Guid.Parse(supplierId),
                1,
                int.MaxValue,
                includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
            );

            var totalSales = ordersResult.Items.Where(order => order.OrderStatus != OrderStatus.Cancelled).Sum(order => order.TotalAmount);
            var totalOrders = ordersResult.Items.Count;
            var pendingOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Pending);
            var completedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Completed);
            var canceledOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Cancelled);
            var approvedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Approved);
            var placedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Placed);
            var shippedOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Shipped);
            var paymentFailOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.PaymentFail);
            var cancelingOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Canceling);
            var paymentOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Payment);
            var pendingRefundOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.PendingRefund);
            var refundOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Refund);
            var depositReturnOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.DepositReturn);
            var extendOrders = ordersResult.Items.Count(x => x.OrderStatus == OrderStatus.Extend);

            return new SupplierOrderStatisticsDto
            {
                TotalSales = (double)totalSales,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders + pendingRefundOrders + refundOrders + depositReturnOrders,
                CanceledOrders = canceledOrders,
                ApprovedOrders = approvedOrders,
                PlacedOrders = placedOrders,
                ShippedOrders = shippedOrders,
                PaymentFailOrders = paymentFailOrders,
                CancelingOrders = cancelingOrders,
                PaymentOrders = paymentOrders,
                ExtendOrders = extendOrders
            };
        }

        public async Task<List<OrderStatusStatisticsDto>> GetOrderStatusStatisticsAsync()
        {
            var orders = await _orderRepository.GetAllDataByExpression(
                null,
                1,
                int.MaxValue
            );

            var statistics = orders.Items
                .GroupBy(order => order.OrderStatus)
                .Select(group => new OrderStatusStatisticsDto
                {
                    Status = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return statistics;
        }


        //
        public async Task<double> GetSystemTotalMoneyAsync()
        {
            double totalMoney = 0;

            // Tiền từ các đơn hàng hoàn thành
            var completedOrders = await _orderRepository.GetAllDataByExpression(
                x => x.OrderStatus != OrderStatus.Cancelled,
                1,
                int.MaxValue
            );
            totalMoney += (double)completedOrders.Items.Sum(order => order.TotalAmount);

            return totalMoney;
        }

        public async Task<int> GetUserCountAsync()
        {
            var users = await _accountRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return users.Items.Count;
        }

        public async Task<int> GetReportCountAsync()
        {
            var reports = await _reportRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return reports.Items.Count;
        }

        public async Task<int> GetProductCountAsync()
        {
            var products = await _productRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return products.Items.Count;
        }

        public async Task<int> GetSupplierCountAsync()
        {
            var suppliers = await _supplierRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return suppliers.Items.Count;
        }

        public async Task<int> GetStaffCountAsync()
        {
            var staff = await _staffRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return staff.Items.Count;
        }

        public async Task<int> GetCategoryCountAsync()
        {
            var categories = await _categoryRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return categories.Items.Count;
        }

        public async Task<int> GetComboCountAsync()
        {
            var combos = await _comboRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return combos.Items.Count;
        }

        public async Task<int> GetOrderCountAsync()
        {
            var orders = await _orderRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return orders.Items.Count;
        }

        public async Task<int> GetProductReportCountAsync()
        {
            var productReports = await _productReportRepository.GetAllDataByExpression(null, 1, int.MaxValue);
            return productReports.Items.Count;
        }
    }
}