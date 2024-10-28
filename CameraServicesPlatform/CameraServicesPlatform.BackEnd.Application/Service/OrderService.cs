using AutoMapper;
using AutoMapper.Execution;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Domain.Models.CameraServicesPlatform.BackEnd.Domain.Models;
using Firebase.Auth;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderService : GenericBackendService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ProductVoucher> _productVoucherRepository;
        private readonly IRepository<Vourcher> _voucherRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<ProductVoucher> productVoucherRepository,
            IRepository<Account> accountRepository,
            IRepository<Vourcher> voucherRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Product> productRepository,
            IRepository<Contract> contractRepository,
            IRepository<ContractTemplate> contractTemplateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _productVoucherRepository = productVoucherRepository;
            _voucherRepository = voucherRepository;
            _accountRepository = accountRepository;
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
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var productIDs = request.Products.Select(p => Guid.Parse(p.ProductID)).ToList();

                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                var existingOrderDetails = await _orderDetailRepository.GetByExpression(x =>
                    productIDs.Contains(x.ProductID) && x.Order.OrderType == OrderType.Purchase
                );

                if (existingOrderDetails != null)
                {
                    throw new Exception("Không tạo đơn hàng thành công vì một hoặc nhiều sản phẩm đã được bán!");
                }

                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.Id = request.AccountID;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Purchase;
                order.DeliveryMethod = request.DeliveryMethod;
                double totalOrderPrice = 0;
                var orderDetails = new List<OrderDetail>();

 
                order.TotalAmount = totalOrderPrice;

                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync(); 

                var createdOrder = await _orderRepository.GetByExpression(x =>
                    x.Id == request.AccountID && x.OrderDate == order.OrderDate && x.OrderStatus == OrderStatus.Pending,
                    x => x.OrderDetail
                );


                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn.");
                }
                var orderDetaills = new List<OrderDetail>();

                foreach (var product in request.Products)
                {
                    var orderDetailRequest = request.OrderDetailRequests
                    .FirstOrDefault(x => x.ProductID == Guid.Parse(product.ProductID));

                    var productVouchers = await _productVoucherRepository.GetByExpression(
                      x => x.ProductID == orderDetailRequest.ProductID && x.VourcherID == Guid.Parse(request.VourcherID));

                    double discount = 0;

                    if (productVouchers != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVouchers.VourcherID);

                        if (voucher != null)
                        {
                            discount = voucher.DiscountAmount;
                        }
                    }
                    var orderDetail = new OrderDetail
                    {
                        OrderID = createdOrder.OrderID,
                        ProductID = Guid.Parse(product.ProductID),
                        ProductPrice = product.PriceBuy ?? 0,
                        Discount = discount,
                        ProductQuality = product.Quality,
                    };

                    double priceAfterDiscount = orderDetail.ProductPrice -  orderDetail.Discount;
                    orderDetail.ProductPriceTotal = priceAfterDiscount;

                    totalOrderPrice += priceAfterDiscount;

                    orderDetaills.Add(orderDetail);
                }

                await _orderDetailRepository.InsertRange(orderDetaills);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                foreach (var product in request.Products)
                {
                    var productEntity = await _productRepository.GetById(Guid.Parse(product.ProductID));

                    if (productEntity != null)
                    {
                        productEntity.Status = ProductStatusEnum.Sold;
                        _productRepository.Update(productEntity);
                    }
                }
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();

                await SendOrderConfirmationEmail(getAccount.Email, getAccount.FirstName, orderDetails, totalOrderPrice);
                result = _mapper.Map<OrderResponse>(createdOrder);

            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công. Lỗi: " + ex.Message);
            }

            return result;
        }
        public async Task<OrderResponse> CreateOrderWithPayment(CreateOrderBuyRequest request, HttpContext context)
        {
            var result = new OrderResponse();

            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var productIDs = request.Products.Select(p => Guid.Parse(p.ProductID)).ToList();
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                var existingOrderDetails = await _orderDetailRepository.GetByExpression(x =>
                    productIDs.Contains(x.ProductID) && x.Order.OrderType == OrderType.Purchase
                );

                if (existingOrderDetails != null)
                {
                    throw new Exception("Không tạo đơn hàng thành công vì một hoặc nhiều sản phẩm đã được bán!");
                }

                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.Id = request.AccountID;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Purchase;

                double totalOrderPrice = 0;
                var orderDetails = new List<OrderDetail>();

                foreach (var product in request.Products)
                {
                    var orderDetailRequest = request.OrderDetailRequests
                        .FirstOrDefault(x => x.ProductID == Guid.Parse(product.ProductID));

                    var productVouchers = await _productVoucherRepository.GetByExpression(
                      x => x.ProductID == orderDetailRequest.ProductID && x.VourcherID == Guid.Parse(request.VourcherID));

                    double discount = 0;

                    if (productVouchers != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVouchers.VourcherID);

                        if (voucher != null)
                        {
                            discount = voucher.DiscountAmount;
                        }
                    }

                    var orderDetail = new OrderDetail
                    {
                        OrderID = order.OrderID,
                        ProductID = Guid.Parse(product.ProductID),
                        ProductPrice = product.PriceBuy ?? 0,
                        Discount = discount,
                        ProductQuality = product.Quality,
                    };

                    double priceAfterDiscount = orderDetail.ProductPrice -  orderDetail.Discount;
                    orderDetail.ProductPriceTotal = priceAfterDiscount;

                    totalOrderPrice += priceAfterDiscount;

                    orderDetails.Add(orderDetail);
                }

                order.TotalAmount = totalOrderPrice;

                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                var createdOrder = await _orderRepository.GetByExpression(x =>
                    x.Id == request.AccountID && x.OrderDate == order.OrderDate && x.OrderStatus == OrderStatus.Pending,
                    x => x.OrderDetail
                );

                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn.");
                }
                var orderDetaills = new List<OrderDetail>();

                foreach (var product in request.Products)
                {
                    var orderDetailRequest = request.OrderDetailRequests
                        .FirstOrDefault(x => x.ProductID == Guid.Parse(product.ProductID));

                    var productVouchers = await _productVoucherRepository.GetByExpression(
                      x => x.ProductID == orderDetailRequest.ProductID && x.VourcherID == Guid.Parse(request.VourcherID));

                    double discount = 0;

                    if (productVouchers != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVouchers.VourcherID);

                        if (voucher != null)
                        {
                            discount = voucher.DiscountAmount;
                        }
                    }

                    var orderDetail = new OrderDetail
                    {
                        OrderID = createdOrder.OrderID,
                        ProductID = Guid.Parse(product.ProductID),
                        ProductPrice = product.PriceBuy ?? 0,
                        Discount = discount,
                        ProductQuality = product.Quality,
                    };

                    double priceAfterDiscount = orderDetail.ProductPrice -  orderDetail.Discount;
                    orderDetail.ProductPriceTotal = priceAfterDiscount;

                    totalOrderPrice += priceAfterDiscount;

                    orderDetaills.Add(orderDetail);
                }

                await _orderDetailRepository.InsertRange(orderDetaills);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                foreach (var product in request.Products)
                {
                    var productEntity = await _productRepository.GetById(Guid.Parse(product.ProductID));

                    if (productEntity != null)
                    {
                        productEntity.Status = ProductStatusEnum.Sold;
                        _productRepository.Update(productEntity);
                    }
                }
                await _unitOfWork.SaveChangesAsync();


                var payment = new PaymentInformationRequest
                {
                    AccountID = createdOrder.Id,
                    Amount = (double)order.TotalAmount,
                    MemberName = $"{order.Account!.FirstName} {order.Account.LastName}",
                    OrderID = order.Id.ToString(),
                    SupplierID = request.SupplierID,
                };

                await paymentGatewayService.CreatePaymentUrlVnpay(payment, context);

                await SendOrderConfirmationEmail(getAccount.Email, getAccount.FirstName, orderDetaills, totalOrderPrice);

                result = _mapper.Map<OrderResponse>(createdOrder);

            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công. Lỗi: " + ex.Message);
            }

            return result;
        }

        private async Task SendOrderConfirmationEmail(string email, string firstName, List<OrderDetail> orderDetails, double totalOrderPrice)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            var orderDetailsString = string.Join("\n", orderDetails.Select(od =>
                $"- Mã sản phẩm: {od.ProductID}\n" +
                $"  Tình trạng: {od.ProductQuality}\n" +
                $"  Đơn giá: {od.ProductPrice:C}\n" +
                $"  Giảm giá: {od.Discount:C}\n" +
                $"  Thành tiền: {od.ProductPriceTotal:C}\n"
            ));

            var orderSummary =
                "=====================================\n" +
                "         CHI TIẾT ĐƠN HÀNG\n" +
                "=====================================\n" +
                $"{orderDetailsString}" +
                "\n-------------------------------------\n" +
                $"Tổng giá trị đơn hàng: {totalOrderPrice:C}\n" +
                "=====================================\n";

            var emailMessage =
                $"Kính chào {firstName},\n\n" +
                "Cảm ơn quý khách đã tin tưởng và đặt hàng!\n\n" +
                "Đơn hàng của quý khách đã được đặt thành công.\n\n" +
                orderSummary +
                "\nNếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ, xin vui lòng liên hệ với chúng tôi.\n\n" +
                "Trân trọng,\n" +
                "Đội ngũ hỗ trợ của Công ty";

            emailService.SendEmail(
               email,
               SD.SubjectMail.ORDER_CONFIRMATION,
               emailMessage
           );
        }
        public async Task<OrderResponse> CreateOrderRent(CreateOrderRentRequest request)
        {
            var result = new OrderResponse();

            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var productIDs = request.Products.Select(p => Guid.Parse(p.ProductID)).ToList();

                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                var checkTemplate = await _contractTemplateRepository.GetById(request.ContractRequest.ContractTemplateId);
                if (checkTemplate == null)
                {
                    throw new Exception("Hãy chọn mẫu hợp đồng!");
                }

                var existingOrderDetails = await _orderDetailRepository.GetByExpression(x =>
                    productIDs.Contains(x.ProductID) && x.Order.OrderType == OrderType.Purchase
                );

                if (existingOrderDetails != null)
                {
                    throw new Exception("Không tạo đơn hàng thành công vì một hoặc nhiều sản phẩm đã được bán!");
                }

                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.Id = request.AccountID;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Rental;

                double totalOrderPrice = 0;
                var orderDetails = new List<OrderDetail>();

                foreach (var product in request.Products)
                {
                    var orderDetailRequest = request.OrderDetailRequests
                        .FirstOrDefault(x => x.ProductID == Guid.Parse(product.ProductID));

                    var productVouchers = await _productVoucherRepository.GetByExpression(
                      x => x.ProductID == orderDetailRequest.ProductID && x.VourcherID == Guid.Parse(request.VoucherID));

                    double discount = 0;

                    if (productVouchers != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVouchers.VourcherID);

                        if (voucher != null)
                        {
                            discount = voucher.DiscountAmount;
                        }
                    }

                    var orderDetail = new OrderDetail
                    {
                        OrderID = order.OrderID,
                        ProductID = Guid.Parse(product.ProductID),
                        ProductPrice = CalculateRentalPrice((double)product.PriceRent, request.DurationUnit, request.DurationValue),
                        Discount = discount,
                        ProductQuality = product.Quality,
                    };

                    double priceAfterDiscount = orderDetail.ProductPrice - orderDetail.Discount;
                    orderDetail.ProductPriceTotal = priceAfterDiscount;

                    totalOrderPrice += priceAfterDiscount;

                    orderDetails.Add(orderDetail);
                }

                order.TotalAmount = totalOrderPrice;

                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                var createdOrder = await _orderRepository.GetByExpression(x =>
                    x.Id == request.AccountID && x.OrderDate == order.OrderDate && x.OrderStatus == OrderStatus.Pending,
                    x => x.OrderDetail
                );

                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn.");
                }
                var orderDetaills = new List<OrderDetail>();

                foreach (var product in request.Products)
                {
                    var orderDetailRequest = request.OrderDetailRequests
                       .FirstOrDefault(x => x.ProductID == Guid.Parse(product.ProductID));

                    var productVouchers = await _productVoucherRepository.GetByExpression(
                      x => x.ProductID == orderDetailRequest.ProductID && x.VourcherID == Guid.Parse(request.VoucherID));

                    double discount = 0;

                    if (productVouchers != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVouchers.VourcherID);

                        if (voucher != null)
                        {
                            discount = voucher.DiscountAmount;
                        }
                    }

                    var orderDetail = new OrderDetail
                    {
                        OrderID = createdOrder.OrderID,
                        ProductID = Guid.Parse(product.ProductID),
                        ProductPrice = CalculateRentalPrice((double)product.PriceRent, request.DurationUnit, request.DurationValue),
                        Discount = discount,
                        ProductQuality = product.Quality,
                    };

                    double priceAfterDiscount = orderDetail.ProductPrice -orderDetail.Discount;
                    orderDetail.ProductPriceTotal = priceAfterDiscount;

                    totalOrderPrice += priceAfterDiscount;

                    orderDetaills.Add(orderDetail);
                }

                await _orderDetailRepository.InsertRange(orderDetaills);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                foreach (var product in request.Products)
                {
                    var productEntity = await _productRepository.GetById(Guid.Parse(product.ProductID));

                    if (productEntity != null)
                    {
                        productEntity.Status = ProductStatusEnum.Rented;
                        _productRepository.Update(productEntity);
                    }
                }
                await _unitOfWork.SaveChangesAsync();


                var productDescriptions = orderDetails.Select(od =>
                    $"ProductID: {od.ProductID}, Price: {od.ProductPrice}, Quantity: {od.ProductQuality}, Discount: {od.Discount}, Total: {od.ProductPriceTotal}")
                    .ToList();

                var contractTerms = string.Join("; ", productDescriptions);

                var contract = new Contract
                {
                    OrderID = createdOrder.OrderID,
                    ContractTerms = contractTerms,
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

                await SendOrderConfirmationEmail(getAccount.Email, getAccount.FirstName, orderDetails, totalOrderPrice);

                var orderResponse = _mapper.Map<OrderResponse>(createdOrder);
                orderResponse.AccountID = createdOrder.Id.ToString();
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
                    filter: filter,
                    pageNumber: pageIndex,
                    pageSize: pageSize,
                    includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,       
                    }
                );

                var convertedResult = pagedResult.Items.Select(order =>
                {
                    var orderResponse = _mapper.Map<OrderResponse>(order); 

                    orderResponse.OrderDetails = _mapper.Map<List<OrderDetailResponse>>(order.OrderDetail.ToList());
                    return orderResponse;
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
                    pageSize,includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail }
                );

                var convertedResult = pagedResult.Items.Select(order => _mapper.Map<OrderResponse>(order)).ToList();

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
                if (!Guid.TryParse(productId, out Guid productIdGuid))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var orders = await _orderRepository.GetAllDataByExpression(
                    order => order.OrderType == OrderType.Rental &&
                              order.OrderDetail.Any(od => od.ProductID == productIdGuid), 
                    pageIndex,
                    pageSize,
                    includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail } 
                );

                if (orders.Items == null || !orders.Items.Any())
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đơn hàng nào.");
                    return result;
                }

                int totalRentals = orders.Items
                    .Sum(order => order.OrderDetail.Where(od => od.ProductID == productIdGuid).Sum(od => od.RentalPeriod ?? 0));

                result.IsSuccess = true;
                result.Result = new
                {
                    ProductID = productId,
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
                    includeProperties: o => o.OrderDetail.Select(od => od.Product)
                );
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại");
                    return result;
                }

                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.AccountID = order.Id.ToString();
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

        public async Task<AppActionResult> UpdateOrderStatusCompletedBySupplier(string OrderID)
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
                orderResponse.AccountID = order.Id.ToString();
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
        public async Task<AppActionResult> UpdateOrderStatusShippedBySupplier(string OrderID)
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
                    order.OrderStatus = OrderStatus.Shipped;
                    _orderRepository.Update(order);
                    await Task.Delay(100);
                    await _unitOfWork.SaveChangesAsync();
                }
                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.AccountID = order.Id.ToString();
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

        public async Task<AppActionResult> UpdateOrderStatusApprovedBySupplier(string OrderID)
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
                    order.OrderStatus = OrderStatus.Approved;
                    _orderRepository.Update(order);
                    await Task.Delay(100);
                    await _unitOfWork.SaveChangesAsync();
                }
                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.AccountID = order.Id.ToString();
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

                TimeSpan timeSinceOrderCreated = DateTime.UtcNow - order.CreatedAt;
                if (timeSinceOrderCreated.TotalHours > 24)
                {
                    result = BuildAppActionResultError(result, "Không thể hủy đơn hàng sau 24 giờ kể từ khi tạo!");
                    return result;
                }

                if (order != null)
                {
                    order.OrderStatus = OrderStatus.Cancelled;
                    _orderRepository.Update(order);
                    await Task.Delay(100);
                    await _unitOfWork.SaveChangesAsync();
                }
                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.AccountID = order.Id.ToString();
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

        public async Task<AppActionResult> GetOrderOfSupplier(string? SupplierID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(SupplierID, out Guid OrderSupplierID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                if (OrderSupplierID != null)
                {
                    var pagedResult1 = await _orderRepository.GetAllDataByExpression(
                        x => x.SupplierID == OrderSupplierID,
                        pageIndex,
                        pageSize,
                        includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail }

                    );
                    var convertedResult1 = pagedResult1.Items.Select(order => _mapper.Map<OrderResponse>(order)).ToList();

                    result.Result = convertedResult1;
                    result.IsSuccess = true;
                }

                Expression<Func<Order, bool>>? filter = null;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize,
                    includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail }

                );

                var convertedResult = pagedResult.Items.Select(order => _mapper.Map<OrderResponse>(order)).ToList();

                result.Result = convertedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderByAccountID(string AccountID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
               
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.Id == AccountID,
                    pageIndex,
                    pageSize, 
                    includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail }

                );

                var convertedResult = pagedResult.Items.Select(order => _mapper.Map<OrderResponse>(order)).ToList();

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
