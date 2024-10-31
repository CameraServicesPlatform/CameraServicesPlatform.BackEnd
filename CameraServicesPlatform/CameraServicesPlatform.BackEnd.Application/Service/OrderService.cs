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
using Microsoft.Identity.Client;
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

        public async Task<AppActionResult> CreateOrderBuy(CreateOrderBuyRequest request)
        {
            var result = new AppActionResult();
            try
            {
                // Parse product ID and retrieve account details
                var productID = Guid.Parse(request.ProductID);
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);
                if (getAccount == null)
                {
                    throw new Exception("Account not found.");
                }

                // Check if the product has already been sold
                var existingOrderDetail = await _orderDetailRepository.GetByExpression(x =>
                    x.ProductID == productID && x.Order.OrderType == OrderType.Purchase
                );
                if (existingOrderDetail != null)
                {
                    throw new Exception("Order creation failed because the product has already been sold.");
                }

                // Map request to Order entity and set order properties
                var order = _mapper.Map<Order>(request);
                order.OrderID = Guid.NewGuid();
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.Id = request.AccountID;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Purchase;
                order.DeliveryMethod = request.DeliveryMethod;

                // Retrieve product price and apply any voucher discount if applicable
                var product = await _productRepository.GetById(productID);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }

                double discount = 0;
                if (!string.IsNullOrEmpty(request.VourcherID))
                {
                    var productVoucher = await _productVoucherRepository.GetByExpression(
                        x => x.ProductID == productID && x.VourcherID == Guid.Parse(request.VourcherID)
                    );
                    if (productVoucher != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVoucher.VourcherID);
                        discount = voucher?.DiscountAmount ?? 0;
                    }
                }
                
                // Create the OrderDetail entity with applied discount
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = productID,
                    ProductPrice = product.PriceBuy ?? 0,
                    Discount = discount,
                    ProductQuality = product.Quality,  // Assuming a quantity of 1 for a single product order
                    ProductPriceTotal = (product.PriceBuy ?? 0) - discount
                };
                // Set the order's total amount and save the order and order detail
                order.TotalAmount = orderDetail.ProductPriceTotal;
                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                
                // Insert the order detail
                orderDetail.OrderID = order.OrderID;
                await _orderDetailRepository.Insert(orderDetail);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                // Update product status to 'Sold'
                var productEntity = await _productRepository.GetById(product.ProductID);
                if (productEntity != null)
                {
                    productEntity.Status = ProductStatusEnum.Sold;
                    _productRepository.Update(productEntity);
                }
                await _unitOfWork.SaveChangesAsync();

                // Send confirmation email and map created order to response
                await SendOrderConfirmationEmail(getAccount, getAccount.Email, getAccount.FirstName, orderDetail, (double)order.TotalAmount);
                result.IsSuccess = true;
                result.Result = order;
            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> CreateOrderWithPayment(CreateOrderBuyRequest request, HttpContext context)
        {
            var result = new AppActionResult();

            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();

                // Parse product ID and retrieve account details
                var productID = Guid.Parse(request.ProductID);
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);
                if (getAccount == null)
                {
                    throw new Exception("Account not found.");
                }

                // Check if the product has already been sold
                var existingOrderDetail = await _orderDetailRepository.GetByExpression(x =>
                    x.ProductID == productID && x.Order.OrderType == OrderType.Purchase
                );
                if (existingOrderDetail != null)
                {
                    throw new Exception("Order creation failed because the product has already been sold.");
                }

                // Map request to Order entity and set order properties
                var order = _mapper.Map<Order>(request);
                order.OrderID = Guid.NewGuid();
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.Id = request.AccountID;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Purchase;
                order.DeliveryMethod = request.DeliveryMethod;

                // Retrieve product price and apply any voucher discount if applicable
                var product = await _productRepository.GetById(productID);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }

                double discount = 0;
                if (!string.IsNullOrEmpty(request.VourcherID))
                {
                    var productVoucher = await _productVoucherRepository.GetByExpression(
                        x => x.ProductID == productID && x.VourcherID == Guid.Parse(request.VourcherID)
                    );
                    if (productVoucher != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVoucher.VourcherID);
                        discount = voucher?.DiscountAmount ?? 0;
                    }
                }

                // Create the OrderDetail entity with applied discount
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = productID,
                    ProductPrice = product.PriceBuy ?? 0,
                    Discount = discount,
                    ProductQuality = product.Quality,  // Assuming a quantity of 1 for a single product order
                    ProductPriceTotal = (product.PriceBuy ?? 0) - discount
                };
                // Set the order's total amount and save the order and order detail
                order.TotalAmount = orderDetail.ProductPriceTotal;
                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();


                // Insert the order detail
                orderDetail.OrderID = order.OrderID;
                await _orderDetailRepository.Insert(orderDetail);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                // Update product status to 'Sold'
                var productEntity = await _productRepository.GetById(product.ProductID);
                if (productEntity != null)
                {
                    productEntity.Status = ProductStatusEnum.Sold;
                    _productRepository.Update(productEntity);
                }
                await _unitOfWork.SaveChangesAsync();

                // Prepare payment request
                var payment = new PaymentInformationRequest
                {
                    AccountID = getAccount.Id,
                    Amount = (double)order.TotalAmount,
                    MemberName = $"{getAccount.FirstName} {getAccount.LastName}",
                    OrderID = order.OrderID.ToString(),
                    SupplierID = request.SupplierID,
                };

                // Create payment URL
                var payMethod = await paymentGatewayService.CreatePaymentUrlVnpay(payment, context);
                // Send order confirmation email
                await SendOrderConfirmationEmail(getAccount, getAccount.Email, getAccount.FirstName, orderDetail, (double)order.TotalAmount);
                result.Result = payMethod;

            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }

            return result;
        }

        private async Task SendOrderConfirmationEmail(Account account, string email, string firstName, OrderDetail orderDetail, double totalOrderPrice)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                $"   Tình trạng: {orderDetail.ProductQuality}<br />" +
                $"   Đơn giá: {orderDetail.ProductPrice:N0} ₫<br />" +
                $"   Giảm giá: {orderDetail.Discount:N0} ₫<br />" +
                $"   Thành tiền: {orderDetail.ProductPriceTotal:N0} ₫<br />";

            // Invoice information template
            var invoiceInfo =
                "HÓA ĐƠN<br /><br />" +
                $"Mã hóa đơn: #{orderDetail.OrderID}<br />" +
                $"Ngày tạo: {DateTime.Now:dd/MM/yyyy}<br />" +
                $"Hạn thanh toán: {DateTime.Now.AddDays(3):dd/MM/yyyy}<br /><br />" + // Set payment deadline to 3 days later
                "Khách hàng<br />" +
                $"{firstName}<br />" +
                $"Điện thoại: {account.PhoneNumber ?? "N/A"}<br />" +
                $"Email: {email}<br />" +
                $"Địa chỉ: {account.Address ?? "N/A"}<br /><br />" +
                "Nhà cung cấp<br />" +
                "Camera service platform Company<br />" +
                "Điện thoại: 0862448677<br />" +
                "Email: dan1314705@gmail.com<br />" +
                "Địa chỉ: 265 Hồng Lạc, Phường 10, Quận Tân Bình, TP.HCM<br /><br />";

            // Order summary and total
            var orderSummary =
                "=====================================<br />" +
                "         CHI TIẾT HÓA ĐƠN<br />" +
                "=====================================<br />" +
                $"{orderDetailsString}<br />" +
                "-------------------------------------<br />" +
                $"Thành tiền: {totalOrderPrice:N0} ₫<br />" +
                $"TỔNG CỘNG: {totalOrderPrice:N0} ₫<br />" +
                "=====================================<br />";

            var emailMessage =
                $"Kính chào {firstName},<br /><br />" +
                "Cảm ơn quý khách đã tin tưởng sử dụng dịch vụ của chúng tôi. Dưới đây là thông tin hóa đơn chi tiết của quý khách:<br /><br />" +
                invoiceInfo +
                orderSummary +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Send the email asynchronously and wait for completion
             emailService.SendEmail(
                email,
                SD.SubjectMail.ORDER_CONFIRMATION,
                emailMessage
            );
        }

        public async Task<AppActionResult> PurchaseOrder(string orderId, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var orderDb = await _orderRepository.GetByExpression(p => p!.OrderID == Guid.Parse(orderId), p => p.Account!);
                if (orderDb == null)
                {
                    result = BuildAppActionResultError(result, $"Không tìm thấy đơn hàng với id {orderId}");
                }
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == orderDb.Id);
                if (getAccount == null)
                {
                    throw new Exception("Account not found.");
                }
                if (orderDb!.OrderStatus == OrderStatus.Pending)
                {
                    var payment = new PaymentInformationRequest
                    {
                        AccountID = orderDb.Id,
                        Amount = (double)orderDb.TotalAmount,
                        MemberName = $"{getAccount!.FirstName} {getAccount.LastName}",
                        OrderID = orderDb.Id.ToString(),
                    };
                    result.Result = await paymentGatewayService!.CreatePaymentUrlVnpay(payment, context);
                }
                else
                {
                    result.Messages.Add("Đơn hàng này đã được thanh toán hoặc đã hủy");
                    result.IsSuccess = true;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;

        }
        public async Task<OrderResponse> CreateOrderRent(CreateOrderRentRequest request)
        {
            var result = new OrderResponse();

            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();

                // Kiểm tra tài khoản người dùng
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                // Kiểm tra mẫu hợp đồng
                var checkTemplate = await _contractTemplateRepository.GetById(request.ContractRequest.ContractTemplateId);
                if (checkTemplate == null)
                {
                    throw new Exception("Hãy chọn mẫu hợp đồng!");
                }

                // Khởi tạo và ánh xạ đơn hàng từ request
                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Rental;

                // Tính tổng tiền thuê
                double totalOrderPrice = CalculateRentalPrice( request.TotalAmount, request.DurationUnit, request.DurationValue);
                order.TotalAmount = totalOrderPrice;

                // Chèn đơn hàng vào cơ sở dữ liệu
                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                // Lấy lại đơn hàng sau khi đã lưu để xác thực
                var createdOrder = await _orderRepository.GetByExpression(x =>
                    x.Id == request.AccountID && x.OrderDate == order.OrderDate && x.OrderStatus == OrderStatus.Pending,
                    x => x.OrderDetail
                );

                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn.");
                }

                // Cập nhật trạng thái sản phẩm thành `Rented`
                if (Guid.TryParse(request.ProductID, out var productGuid))
                {
                    var productEntity = await _productRepository.GetById(productGuid);
                    if (productEntity != null)
                    {
                        productEntity.Status = ProductStatusEnum.Rented;
                        _productRepository.Update(productEntity);
                    }
                }
                await _unitOfWork.SaveChangesAsync();

                // Tạo hợp đồng từ thông tin sản phẩm
                var contract = new Contract
                {
                    OrderID = createdOrder.OrderID,
                    ContractTerms = $"ProductID: {request.ProductID}, Duration: {request.DurationValue} {request.DurationUnit}",
                    PenaltyPolicy = request.ContractRequest.PenaltyPolicy,
                };

                await _contractRepository.Insert(contract);
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();

                // Xác nhận hợp đồng đã được tạo
                var checkContract = await _contractRepository.GetByExpression(x => x.CreatedAt == request.CreatedAt && x.OrderID == order.OrderID);
                if (checkContract == null)
                {
                    throw new Exception("Không có hợp đồng!");
                }

                // Ánh xạ thông tin đơn hàng sang response
                var orderResponse = _mapper.Map<OrderResponse>(createdOrder);
                orderResponse.AccountID = createdOrder.Id.ToString();
                orderResponse.SupplierID = createdOrder.SupplierID.ToString();

                result = orderResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công", ex);
            }

            return result;
        }

        // Hàm tính tổng giá thuê dựa trên đơn vị thời gian và giá trị
        //private double CalculateTotalOrderPrice(RentalDurationUnit durationUnit, int durationValue, decimal baseAmount)
        //{
        //    double multiplier = durationUnit switch
        //    {
        //        RentalDurationUnit.Daily => 1,
        //        RentalDurationUnit.Weekly => 7,
        //        RentalDurationUnit.Monthly => 30,
        //        _ => 1
        //    };
        //    return (double)(baseAmount * durationValue * (decimal)multiplier);
        //}


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
