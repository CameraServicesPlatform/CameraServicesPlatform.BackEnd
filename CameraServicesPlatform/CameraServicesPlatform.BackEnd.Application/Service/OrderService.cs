using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderService : GenericBackendService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Product> productRepository,
            IRepository<Contract> contractRepository,
            IRepository<ContractTemplate> contractTemplateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _contractTemplateRepository = contractTemplateRepository;
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponse> CreateOrderBuy(CreateOrderBuyRequest request)
        {
            var result = new OrderResponse();
            try
            {
                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.Now;
                order.OrderStatus = 0;

                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                var createdOrder = await _orderRepository
                                        .GetByExpression(x => x.MemberID == request.MemberID && x.OrderDate == order.OrderDate);

                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn");
                }

                var orderDetails = _mapper.Map<List<OrderDetail>>(request.OrderDetailRequests);

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = createdOrder.OrderID;
                }

                await _orderDetailRepository.InsertRange(orderDetails);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                foreach (var orderDetailRequest in request.OrderDetailRequests)
                {
                    var product = await _productRepository.GetById(orderDetailRequest.ProductID);
                    if (product != null)
                    {
                        product.Status = ProductStatusEnum.Shipping;  
                        _productRepository.Update(product);
                    }
                }
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();
                
                result = _mapper.Map<OrderResponse>(createdOrder);
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công");
            }

            return result;
        }

        public async Task<OrderResponse> CreateOrderRent(CreateOrderRentRequest request)
        {
            var result = new OrderResponse();
            try
            {
                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.Now;
                order.OrderStatus = 0;

                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                var createdOrder = await _orderRepository
                                        .GetByExpression(x => x.MemberID == request.MemberID && x.OrderDate == order.OrderDate);

                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn");
                }

                var orderDetails = _mapper.Map<List<OrderDetail>>(request.OrderDetailRequests);

                foreach (var orderDetail in orderDetails)
                {
                    var product = await _productRepository.GetById(orderDetail.ProductID);
                    if (product != null)
                    {
                        double rentalPrice = CalculateRentalPrice((double)product.PriceRent, request.DurationUnit, request.DurationValue);
                        orderDetail.ProductPriceTotal = rentalPrice; 
                        orderDetail.OrderID = createdOrder.OrderID;
                    }
                }

                await _orderDetailRepository.InsertRange(orderDetails);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                foreach (var orderDetailRequest in request.OrderDetailRequests)
                {
                    var product = await _productRepository.GetById(orderDetailRequest.ProductID);
                    if (product != null)
                    {
                        product.Status = ProductStatusEnum.Shipping;
                        await _productRepository.Update(product);
                    }
                }
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();

                var checkTemplate = await _contractTemplateRepository.GetById(request.ContractRequest.ContractTemplateId);
                if (checkTemplate == null)
                {
                    throw new Exception("Hãy chọn mẫu hợp đồng!");
                }
                var contract = new Contract
                {
                    OrderID = createdOrder.OrderID,
                    ContractTerms = request.ContractRequest.ContractTerms,
                    PenaltyPolicy = request.ContractRequest.PenaltyPolicy,
                };

                await _contractRepository.Insert(contract);
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();

                var checkContract = await _contractRepository.GetByExpression(x => x.CreatedAt == request.CreatedAt && x.OrderID == order.OrderID);
                if (checkContract == null)
                {
                    throw new Exception("Không có hợp đồng!");
                }
                var orderResponse = _mapper.Map<OrderResponse>(createdOrder);
                orderResponse.MemberID = createdOrder.MemberID.ToString();
                orderResponse.SupplierID = createdOrder.SupplierID.ToString();

                result = orderResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công");
            }

            return result;
        }

        public async Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Order, bool>>? filter = null;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var convertedResult = pagedResult.Items.Select(order => new
                {
                    OrderID = order.OrderID.ToString(),
                    MemberID = order.MemberID.ToString(),
                    SupplierID = order.SupplierID.ToString(),
                    DeliveriesMethodID = order.DeliveriesMethodID.ToString(),
                    OrderDetailID = order.OrderDetailID.ToString(),
                    order.OrderDate,
                    order.CreatedAt,
                    order.OrderStatus,
                    order.TotalAmount,
                    order.DeliveryMethod,
                    order.ShippingAddress,
                    order.RentalStartDate,
                    order.RentalEndDate,
                    order.DurationUnit,
                    order.DurationValue,
                    order.ReturnDate,
                }).ToList();
                result.Result = convertedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderByOrderType(OrderType orderType, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.OrderType == orderType,
                    pageIndex,
                    pageSize
                );

                var convertedResult = pagedResult.Items.Select(order => new
                {
                    OrderID = order.OrderID.ToString(),
                    MemberID = order.MemberID.ToString(),
                    SupplierID = order.SupplierID.ToString(),
                    DeliveriesMethodID = order.DeliveriesMethodID.ToString(),
                    OrderDetailID = order.OrderDetailID.ToString(),
                    order.OrderDate,
                    order.CreatedAt,
                    order.OrderStatus,
                    order.TotalAmount,
                    order.DeliveryMethod,
                    order.ShippingAddress,
                    order.RentalStartDate,
                    order.RentalEndDate,
                    order.DurationUnit,
                    order.DurationValue,
                    order.ReturnDate,
                }).ToList();
                result.Result = convertedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CountProductRentals(string productId, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                if (!Guid.TryParse(productId, out Guid ProductID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var orders = await _orderRepository.GetAllDataByExpression(
                    order => order.OrderType == OrderType.Rental,
                    pageIndex,
                   pageSize
                );

                if (orders.Items == null || !orders.Items.Any())
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đơn hàng nào.");
                    return result;
                }

                int totalRentals = orders.Items
                    .SelectMany(order => order.OrderDetail) 
                    .Where(detail => detail.ProductID == ProductID)
                    .Sum(detail => detail.RentalPeriod ?? 0); 

                result.IsSuccess = true;
                result.Result = new
                {
                    ProductID = productId.ToString(),
                    TotalRentals = totalRentals 
                };
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, $"Lỗi trong quá trình đếm số lần sản phẩm được thuê: {ex.Message}");
            }

            return result;
        }

        public async Task<AppActionResult> GetByOrderId(string orderId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(orderId, out Guid OrderId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var order = await _orderRepository.GetByExpression(
                    filter: o => o.OrderID == OrderId,   
                    includeProperties: o => o.OrderDetail
                );
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại");
                    return result;
                }

                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.MemberID = order.MemberID.ToString();
                orderResponse.SupplierID = order.SupplierID.ToString();

                result.Result = orderResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message); 
            }

            return result;
        }

        public async Task<AppActionResult> UpdateOrderStatus(string OrderID)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(OrderID, out Guid OrderUpdateId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var order = await _orderRepository.GetById(OrderUpdateId);
            if (order != null)
            {
                order.OrderStatus = OrderStatus.Completed;
                _orderRepository.Update(order);
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();
                }
                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.MemberID = order.MemberID.ToString();
                orderResponse.SupplierID = order.SupplierID.ToString();

                result.Result = orderResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CancelOrder(string OrderID)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(OrderID, out Guid OrderUpdateId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var order = await _orderRepository.GetById(OrderUpdateId);
                if (order != null)
                {
                    order.OrderStatus = OrderStatus.Completed;
                    _orderRepository.Update(order);
                    await Task.Delay(100);
                    await _unitOfWork.SaveChangesAsync();
                }
                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.MemberID = order.MemberID.ToString();
                orderResponse.SupplierID = order.SupplierID.ToString();

                result.Result = orderResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderOfSupplier(string SupplierID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(SupplierID, out Guid OrderSupplierID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.SupplierID == OrderSupplierID,
                    pageIndex,
                    pageSize
                );

                var convertedResult = pagedResult.Items.Select(order => new
                {
                    OrderID = order.OrderID.ToString(),
                    MemberID = order.MemberID.ToString(),
                    SupplierID = order.SupplierID.ToString(),
                    DeliveriesMethodID = order.DeliveriesMethodID.ToString(),
                    OrderDetailID = order.OrderDetailID.ToString(),
                    order.OrderDate,
                    order.CreatedAt,
                    order.OrderStatus,
                    order.TotalAmount,
                    order.DeliveryMethod,
                    order.ShippingAddress,
                    order.RentalStartDate,
                    order.RentalEndDate,
                    order.DurationUnit,
                    order.DurationValue,
                    order.ReturnDate,
                }).ToList();
                result.Result = convertedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderByMemberID(string MemberID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(MemberID, out Guid OrderMemberID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.MemberID == OrderMemberID,
                    pageIndex,
                    pageSize
                );

                var convertedResult = pagedResult.Items.Select(order => new
                {
                    OrderID = order.OrderID.ToString(),
                    MemberID = order.MemberID.ToString(),
                    SupplierID = order.SupplierID.ToString(),
                    DeliveriesMethodID = order.DeliveriesMethodID.ToString(),
                    OrderDetailID = order.OrderDetailID.ToString(),
                    order.OrderDate,
                    order.CreatedAt,
                    order.OrderStatus,
                    order.TotalAmount,
                    order.DeliveryMethod,
                    order.ShippingAddress,
                    order.RentalStartDate,
                    order.RentalEndDate,
                    order.DurationUnit,
                    order.DurationValue,
                    order.ReturnDate,
                }).ToList();
                result.Result = convertedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        private double CalculateRentalPrice(double basePrice, RentalDurationUnit durationUnit, int durationValue)
        {
            double totalPrice = 0;

            switch (durationUnit)
            {
                case RentalDurationUnit.Hour:
                    totalPrice = basePrice * durationValue; 
                    break;
                case RentalDurationUnit.Day:
                    totalPrice = basePrice * durationValue; 
                    break;
                case RentalDurationUnit.Week:
                    totalPrice = basePrice * durationValue * 7; 
                    break;
                case RentalDurationUnit.Month:
                    totalPrice = basePrice * durationValue * 30; 
                    break;
            }

            return totalPrice; 
        }
    }
}
