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
using Google.Apis.Util;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static CameraServicesPlatform.BackEnd.Application.Service.GenericBackendService;



namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderService : GenericBackendService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ProductVoucher> _productVoucherRepository;
        private readonly IRepository<Vourcher> _voucherRepository;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<ProductVoucher> productVoucherRepository,
            IRepository<Account> accountRepository,
            IRepository<Payment> paymentRepository,
            IRepository<Transaction> transactionRepository,
            IRepository<Supplier> supplierRepository,
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
            _transactionRepository = transactionRepository;
            _paymentRepository = paymentRepository;
            _supplierRepository = supplierRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _contractTemplateRepository = contractTemplateRepository;
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> GetOrderByOrderID(string OrderID)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(OrderID, out Guid OrderGetId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var order = await _orderRepository.GetById(OrderGetId);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                var orderDetail = await _orderDetailRepository.GetByExpression(
                   filter: o => o.OrderID == OrderGetId);

                var paymentInfor = await _paymentRepository.GetByExpression(
                   filter: o => o.OrderID == OrderGetId);



                var transactionInfor = await _transactionRepository.GetByExpression(
                   filter: o => o.OrderID == OrderGetId);


                var orderResponse = new OrderDetailByOrderIDResponse
                {
                    OrderID = OrderID,
                    SupplierID = order.SupplierID.ToString(),
                    OrderDetailID = orderDetail?.OrderDetailsID.ToString() ?? "N/A",
                    PaymentID = paymentInfor?.PaymentID.ToString() ?? "N/A",
                    TransactionID = transactionInfor?.TransactionID.ToString() ?? "N/A" 
                };

                result.Result = orderResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
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
                order.OrderDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.Id = request.AccountID;
                order.ShippingAddress = request.ShippingAddress;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Purchase;
                order.DeliveriesMethod = request.DeliveryMethod;

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

                var supplier = await _supplierRepository.GetById(order.SupplierID);
                var supplierAccount = await _accountRepository.GetById(supplier.AccountID);
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
                await SendOrderConfirmationEmail(getAccount,supplierAccount, getAccount.Email, getAccount.FirstName, order, orderDetail, (double)order.TotalAmount);
                await Task.Delay(100);
                await SendOrderConfirmationEmailToSupplier(getAccount , supplierAccount.Email, supplierAccount.FirstName, order, orderDetail, (double)order.TotalAmount);
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
                //var existingOrderDetail = await _orderDetailRepository.GetByExpression(x =>
                //    x.ProductID == productID && x.Order.OrderType == OrderType.Purchase
                //);
                //if (existingOrderDetail != null)
                //{
                //    throw new Exception("Order creation failed because the product has already been sold.");
                //}

                var product = await _productRepository.GetById(productID);
                if (product == null)
                {
                    throw new Exception("Không tìm thấy sản phẩm thuê.");
                }

                if (product.Status == ProductStatusEnum.Sold)
                {
                    throw new Exception("Sản phẫm đã được bán");
                }

                // Map request to Order entity and set order properties
                var order = _mapper.Map<Order>(request);
                order.OrderID = Guid.NewGuid();
                order.OrderDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow); 
                order.UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.Id = request.AccountID;
                order.ShippingAddress = request.ShippingAddress;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Purchase;
                order.DeliveriesMethod = request.DeliveryMethod;

                // Retrieve product price and apply any voucher discount if applicable

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
                var supplier = await _supplierRepository.GetById(order.SupplierID);
                var supplierAccount = await _accountRepository.GetById(supplier.AccountID);
                // Create payment URL
                var payMethod = await paymentGatewayService.CreatePaymentUrlVnpay(payment, context);
                // Send order confirmation email
                await SendOrderConfirmationEmail(getAccount, supplierAccount, getAccount.Email, getAccount.FirstName, order, orderDetail, (double)order.TotalAmount);
                await Task.Delay(100);
                await SendOrderConfirmationEmailToSupplier(getAccount, supplierAccount.Email, supplierAccount.FirstName, order, orderDetail, (double)order.TotalAmount);
                await Task.Delay(100);
                result.Result = payMethod;

            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }

            return result;
        }

        private async Task SendOrderConfirmationEmail(Account account, Account supplierAccount, string email, string firstName,Order order, OrderDetail orderDetail, double totalOrderPrice)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                "   Hình thức đơn hàng: Mua<br />" +
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
                $"{account.FirstName}<br />" +
                $"Điện thoại: {account.PhoneNumber ?? "N/A"}<br />" +
                $"Email: {account.Email}<br />" +
                $"Địa chỉ: {order.ShippingAddress ?? "Khách đến tiệm lấy"}<br /><br />" +
                "Nhà cung cấp<br />" +
                $"Tên: {supplierAccount.FirstName}<br />" +
                $"Điện thoại: {supplierAccount.PhoneNumber}<br />" +
                $"Email: {supplierAccount.Email}<br />" +
                $"Địa chỉ: {supplierAccount.Address}<br /><br />";

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
                "Bạn vừa có đơn đặt hàng. Dưới đây là thông tin hóa đơn chi tiết của đơn hàng của khách hàng:<br /><br />" +
                invoiceInfo +
                orderSummary +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Send the email asynchronously and wait for completion
             emailService.SendEmail(
                email,
                SD.SubjectMail.ORDER_CONFIRMATION_SUPPLIER,
                emailMessage
            );
        }
        public static class DateTimeHelper
        {
            private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Convert UTC DateTime to Vietnam Time
            public static DateTime ToVietnamTime(DateTime utcDateTime)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, VietnamTimeZone);
            }
        }
        private async Task SendOrderConfirmationEmailToSupplier(Account account, string email, string firstName, Order order, OrderDetail orderDetail, double totalOrderPrice)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                "   Hình thức đơn hàng: Mua<br />" +
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
                $"Địa chỉ: {order.ShippingAddress ?? "Khách đến tiệm lấy."}<br /><br />" +
                "Thông báo từ<br />" +
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
                    var createPayment = await paymentGatewayService!.CreatePaymentUrlVnpay(payment, context);
                    
                    //orderDb.OrderStatus = OrderStatus.Payment;
                    //_orderRepository.Update(orderDb);
                    //await _unitOfWork.SaveChangesAsync();

                    result.Result = createPayment;
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
        public async Task<AppActionResult> CreateOrderRent(CreateOrderRentRequest request)
        {
            var result = new AppActionResult();
            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var productID = Guid.Parse(request.ProductID);

                // Kiểm tra tài khoản người dùng
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                var supplier = await _supplierRepository.GetById(Guid.Parse(request.SupplierID));
                var supplierAccount = await _accountRepository.GetById(supplier.AccountID);

                // Khởi tạo và ánh xạ đơn hàng từ request
                var order = _mapper.Map<Order>(request);
                order.OrderID = Guid.NewGuid();
                order.OrderDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.Id = request.AccountID;
                order.OrderStatus = OrderStatus.Pending;
                order.ShippingAddress = request.ShippingAddress;
                order.OrderType = OrderType.Rental;
                order.DeliveriesMethod = request.DeliveryMethod;
                order.DurationValue = request.DurationValue;
                order.DurationUnit = request.DurationUnit;
                order.ShippingAddress = request.ShippingAddress;
                order.RentalStartDate = DateTimeHelper.ToVietnamTime(request.RentalStartDate ?? DateTime.UtcNow);

                switch (order.DurationUnit)
                {
                    case RentalDurationUnit.Hour:
                        order.RentalEndDate = order.RentalStartDate?.AddHours(order.DurationValue);
                        break;
                    case RentalDurationUnit.Day:
                        order.RentalEndDate = order.RentalStartDate?.AddDays(order.DurationValue);
                        break;
                    case RentalDurationUnit.Week:
                        order.RentalEndDate = order.RentalStartDate?.AddDays(order.DurationValue * 7);
                        break;
                    case RentalDurationUnit.Month:
                        order.RentalEndDate = order.RentalStartDate?.AddMonths(order.DurationValue);
                        break;
                    default:
                        throw new InvalidOperationException("DurationUnit is not supported.");
                }


                switch (order.DurationUnit)
                {
                    case RentalDurationUnit.Hour:
                        order.ReturnDate = order.RentalStartDate?.AddHours(order.DurationValue);
                        break;
                    case RentalDurationUnit.Day:
                        order.ReturnDate = order.RentalStartDate?.AddDays(order.DurationValue);
                        break;
                    case RentalDurationUnit.Week:
                        order.ReturnDate = order.RentalStartDate?.AddDays(order.DurationValue * 7);
                        break;
                    case RentalDurationUnit.Month:
                        order.ReturnDate = order.RentalStartDate?.AddMonths(order.DurationValue);
                        break;
                    default:
                        throw new InvalidOperationException("DurationUnit is not supported.");
                }

                var product = await _productRepository.GetByExpression(x => x.ProductID == productID);
                if (product == null)
                {
                    throw new Exception("Không tìm thấy sản phẩm.");
                }

                if (product.Status == ProductStatusEnum.Rented)
                {
                    throw new Exception("Sản phẫm đã được thuê");
                }

                double discount = 0;
                if (!string.IsNullOrEmpty(request.VoucherID))
                {
                    var productVoucher = await _productVoucherRepository.GetByExpression(
                        x => x.ProductID == productID && x.VourcherID == Guid.Parse(request.VoucherID)
                    );
                    if (productVoucher != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVoucher.VourcherID);
                        discount = voucher?.DiscountAmount ?? 0;
                    }
                }

                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = productID,
                    ProductPrice = request.ProductPriceRent,
                    Discount = discount,
                    ProductQuality = product.Quality,
                    ProductPriceTotal = request.TotalAmount,
                    PeriodRental = order.ReturnDate,
                };

                order.IsExtend = false;
                order.Deposit = product.DepositProduct;
                order.TotalAmount = request.TotalAmount;
                double TotalPrice = (double)order.TotalAmount;
                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();


                // Insert the order detail
                orderDetail.OrderID = order.OrderID;
                await _orderDetailRepository.Insert(orderDetail);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

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

                var pagedContractTemplates = await _contractTemplateRepository.GetAllDataByExpression(
                    x => x.ProductID == Guid.Parse(request.ProductID),
                    pageNumber: 1,
                    pageSize: int.MaxValue);

                if (pagedContractTemplates != null && pagedContractTemplates.Items.Any())
                {
                    var contractOfProductContract = pagedContractTemplates.Items;

                    foreach (var template in contractOfProductContract)
                    {
                        var contract = new Contract
                        {
                            OrderID = order.OrderID,
                            CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            ContractTemplateId = template.ContractTemplateId,
                            ContractTerms = template.ContractTerms,
                            TemplateDetails = template.TemplateDetails,
                            PenaltyPolicy = template.PenaltyPolicy,
                        };

                        await _contractRepository.Insert(contract);
                    }

                    await _unitOfWork.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Không có mẫu hợp đồng nào phù hợp cho sản phẩm này.");
                }

                // Xác nhận hợp đồng đã được tạo
                var checkContract = await _contractRepository.GetAllDataByExpression(x => x.CreatedAt == request.CreatedAt && x.OrderID == order.OrderID,
                    pageNumber: 1,
                    pageSize: int.MaxValue);
                if (checkContract == null)
                {
                    throw new Exception("Không có hợp đồng!");
                }

                var contractOfProduct = pagedContractTemplates.Items;
                // Send confirmation email to the customer
                await SendOrderRentConfirmationEmail(getAccount, supplierAccount, getAccount.Email, supplierAccount.FirstName, order, orderDetail, TotalPrice, contractOfProduct);
                await Task.Delay(100);
                // Send confirmation email to the supplier
                await SendOrderRentConfirmationEmailSupplier(getAccount, supplierAccount.Email, supplierAccount.FirstName, order, orderDetail, TotalPrice, contractOfProduct);
                await Task.Delay(100);

                result.Result = order;
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công", ex);
            }

            return result;
        }

        public async Task<AppActionResult> CreateOrderRentWithPayment(CreateOrderRentRequest request, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var productID = Guid.Parse(request.ProductID);

                // Kiểm tra tài khoản người dùng
                var getAccount = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                var supplier = await _supplierRepository.GetById(Guid.Parse(request.SupplierID));
                var supplierAccount = await _accountRepository.GetById(supplier.AccountID);

                // Khởi tạo và ánh xạ đơn hàng từ request
                var order = _mapper.Map<Order>(request);
                order.OrderID = Guid.NewGuid();
                order.OrderDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.ReservationMoney = 300000;
                order.Id = request.AccountID;
                order.OrderStatus = OrderStatus.Pending;
                order.ShippingAddress = request.ShippingAddress;
                order.OrderType = OrderType.Rental;
                order.DeliveriesMethod = request.DeliveryMethod;
                order.DurationValue = request.DurationValue;
                order.DurationUnit = request.DurationUnit;
                order.ShippingAddress = request.ShippingAddress;
                order.RentalStartDate = DateTimeHelper.ToVietnamTime(request.RentalStartDate ?? DateTime.UtcNow);

                switch (order.DurationUnit)
                {
                    case RentalDurationUnit.Hour:
                        order.RentalEndDate = order.RentalStartDate?.AddHours(order.DurationValue);
                        break;
                    case RentalDurationUnit.Day:
                        order.RentalEndDate = order.RentalStartDate?.AddDays(order.DurationValue);
                        break;
                    case RentalDurationUnit.Week:
                        order.RentalEndDate = order.RentalStartDate?.AddDays(order.DurationValue * 7);
                        break;
                    case RentalDurationUnit.Month:
                        order.RentalEndDate = order.RentalStartDate?.AddMonths(order.DurationValue);
                        break;
                    default:
                        throw new InvalidOperationException("DurationUnit is not supported.");
                }


                switch (order.DurationUnit)
                {
                    case RentalDurationUnit.Hour:
                        order.ReturnDate = order.RentalStartDate?.AddHours(order.DurationValue);
                        break;
                    case RentalDurationUnit.Day:
                        order.ReturnDate = order.RentalStartDate?.AddDays(order.DurationValue);
                        break;
                    case RentalDurationUnit.Week:
                        order.ReturnDate = order.RentalStartDate?.AddDays(order.DurationValue * 7);
                        break;
                    case RentalDurationUnit.Month:
                        order.ReturnDate = order.RentalStartDate?.AddMonths(order.DurationValue);
                        break;
                    default:
                        throw new InvalidOperationException("DurationUnit is not supported.");
                }

                var product = await _productRepository.GetByExpression(x=> x.ProductID == productID);
                if (product == null)
                {
                    throw new Exception("Không tìm thấy sản phẩm.");
                }

                if (product.Status == ProductStatusEnum.Rented)
                {
                    throw new Exception("Sản phẫm đã được thuê");
                }

                double discount = 0;
                if (!string.IsNullOrEmpty(request.VoucherID))
                {
                    var productVoucher = await _productVoucherRepository.GetByExpression(
                        x => x.ProductID == productID && x.VourcherID == Guid.Parse(request.VoucherID)
                    );
                    if (productVoucher != null)
                    {
                        var voucher = await _voucherRepository.GetById(productVoucher.VourcherID);
                        discount = voucher?.DiscountAmount ?? 0;
                    }
                }

                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = productID,
                    ProductPrice = request.ProductPriceRent,
                    Discount = discount,
                    ProductQuality = product.Quality,  
                    ProductPriceTotal = request.TotalAmount,
                    PeriodRental = order.ReturnDate,
                };

                order.IsExtend = false;
                order.Deposit = product.DepositProduct;
                order.TotalAmount = request.TotalAmount;
                double TotalPrice = (double)order.TotalAmount;
                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();


                // Insert the order detail
                orderDetail.OrderID = order.OrderID;
                await _orderDetailRepository.Insert(orderDetail);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                // Cập nhật trạng thái sản phẩm thành `Rented`
                //if (Guid.TryParse(request.ProductID, out var productGuid))
                //{
                //    var productEntity = await _productRepository.GetById(productGuid);
                //    if (productEntity != null)
                //    {
                //        productEntity.Status = ProductStatusEnum.Rented;
                //        _productRepository.Update(productEntity);
                //    }
                //}
                //await _unitOfWork.SaveChangesAsync();

                var pagedContractTemplates = await _contractTemplateRepository.GetAllDataByExpression(
                    x => x.ProductID == Guid.Parse(request.ProductID),
                    pageNumber: 1,
                    pageSize: int.MaxValue);

                // Kiểm tra nếu có item trong kết quả phân trang
                if (pagedContractTemplates != null && pagedContractTemplates.Items.Any())
                {
                    var contractOfProductContract = pagedContractTemplates.Items;

                    foreach (var template in contractOfProductContract)
                    {
                        var contract = new Contract
                        {
                            OrderID = order.OrderID,
                            CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            ContractTemplateId = template.ContractTemplateId,
                            ContractTerms = template.ContractTerms,
                            TemplateDetails = template.TemplateDetails,
                            PenaltyPolicy = template.PenaltyPolicy,
                        };

                        await _contractRepository.Insert(contract);
                    }

                    await _unitOfWork.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Không có mẫu hợp đồng nào phù hợp cho sản phẩm này.");
                }

                // Xác nhận hợp đồng đã được tạo
                var checkContract = await _contractRepository.GetAllDataByExpression(x => x.CreatedAt == request.CreatedAt && x.OrderID == order.OrderID,
                    pageNumber: 1,
                    pageSize: int.MaxValue);
                if (checkContract == null)
                {
                    throw new Exception("Không có hợp đồng!");
                }

                var payment = new PaymentInformationRequest
                {
                    AccountID = getAccount.Id,
                    Amount = (double)order.ReservationMoney,
                    MemberName = $"{getAccount.FirstName} {getAccount.LastName}",
                    OrderID = order.OrderID.ToString(),
                    SupplierID = request.SupplierID,
                };

                var payMethod = await paymentGatewayService.CreatePaymentUrlVnpay(payment, context);


                var contractOfProduct = pagedContractTemplates.Items;
                // Send confirmation email to the customer
                await SendOrderRentConfirmationEmail(getAccount, supplierAccount, getAccount.Email, supplierAccount.FirstName, order, orderDetail, TotalPrice, contractOfProduct);
                await Task.Delay(100);
                // Send confirmation email to the supplier
                await SendOrderRentConfirmationEmailSupplier(getAccount, supplierAccount.Email, supplierAccount.FirstName, order, orderDetail, TotalPrice, contractOfProduct);


                await Task.Delay(100);
                result.Result = payMethod;
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

        public async Task<AppActionResult> GetOrderByOrderStatus(OrderStatus orderStatus, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.OrderStatus == orderStatus,
                    pageIndex,
                    pageSize, includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail }
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
                    .Count(order => order.OrderDetail.Any(od => od.ProductID == productIdGuid));

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
                if (order.OrderType == OrderType.Rental) {
                    var orderDetail = await _orderDetailRepository.GetByExpression(x => x.OrderID == OrderUpdateId);
                    if (orderDetail != null)
                    {
                        var product = await _productRepository.GetByExpression(x => x.ProductID == orderDetail.ProductID);
                        product.Status = ProductStatusEnum.AvailableRent;
                        _productRepository.Update(product);
                        await Task.Delay(100);
                        await _unitOfWork.SaveChangesAsync();
                    }
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

        public async Task<AppActionResult> UpdateOrderStatusPlaced(string OrderID)
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
                    order.OrderStatus = OrderStatus.Placed;
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

        public async Task<AppActionResult> UpdateOrderPendingRefund(string OrderID)
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
                    order.OrderStatus = OrderStatus.PendingRefund;
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

        public async Task<AppActionResult> UpdateOrderRefund(string OrderID)
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
                    order.OrderStatus = OrderStatus.Refund;
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

        public async Task<AppActionResult> UpdateOrderDepositReturn(string OrderID)
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
                    order.OrderStatus = OrderStatus.DepositReturn;
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

        public async Task<AppActionResult> UpdateOrderFinalCompleted(string OrderID)
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
        public async Task<AppActionResult> UpdateOrderStatusPaymentBySupplier(string OrderID)
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
                    order.OrderStatus = OrderStatus.Payment;
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
                // Validate OrderID format
                if (!Guid.TryParse(OrderID, out Guid OrderUpdateId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                // Retrieve the order from the repository
                var order = await _orderRepository.GetById(OrderUpdateId);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                // Check if the cancellation is within the allowed time frame (24 hours)
                TimeSpan timeSinceOrderCreated = DateTime.UtcNow - order.CreatedAt;
                if (timeSinceOrderCreated.TotalHours > 24)
                {
                    result = BuildAppActionResultError(result, "Không thể hủy đơn hàng sau 24 giờ kể từ khi tạo!");
                    return result;
                }

                // Update order status to Cancelled
                order.OrderStatus = OrderStatus.Canceling;
                _orderRepository.Update(order);
                await _unitOfWork.SaveChangesAsync();

                // Notify the supplier about the cancelled order
                var supplier = await _supplierRepository.GetById(order.SupplierID);
                var account = await _accountRepository.GetById(supplier.AccountID);
                var orderDetail = await _orderDetailRepository.GetByExpression(x => x.OrderID == OrderUpdateId);
                double totalOrderPrice = (double)order.TotalAmount;

                await SendOrderCancelNotificationToSupplier(account, account.Email, account.FirstName, orderDetail, totalOrderPrice);

                // Prepare response data
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

        public async Task<AppActionResult> AcceptCancelOrder(string OrderID)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                // Validate OrderID format
                if (!Guid.TryParse(OrderID, out Guid OrderUpdateId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                // Retrieve the order from the repository
                var order = await _orderRepository.GetById(OrderUpdateId);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                // Check if the cancellation is within the allowed time frame (24 hours)
                TimeSpan timeSinceOrderCreated = DateTime.UtcNow - order.CreatedAt;
                if (timeSinceOrderCreated.TotalHours > 24)
                {
                    result = BuildAppActionResultError(result, "Không thể hủy đơn hàng sau 24 giờ kể từ khi tạo!");
                    return result;
                }

                // Update order status to Cancelled
                order.OrderStatus = OrderStatus.Cancelled;
                _orderRepository.Update(order);
                await _unitOfWork.SaveChangesAsync();

                // Notify the supplier about the cancelled order
                var supplier = await _supplierRepository.GetById(order.SupplierID);
                var supplierAccount = await _accountRepository.GetById(supplier.AccountID);
                var account = await _accountRepository.GetById(order.Id);
                var orderDetail = await _orderDetailRepository.GetByExpression(x => x.OrderID == OrderUpdateId);
                double totalOrderPrice = (double)order.TotalAmount;

                if (order.OrderType == OrderType.Rental)
                {
                    if (orderDetail != null)
                    {
                        var product = await _productRepository.GetByExpression(x => x.ProductID == orderDetail.ProductID);
                        product.Status = ProductStatusEnum.AvailableRent;
                        _productRepository.Update(product);
                        await Task.Delay(100);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
                else
                {
                    if (orderDetail != null)
                    {
                        var product = await _productRepository.GetByExpression(x => x.ProductID == orderDetail.ProductID);
                        product.Status = ProductStatusEnum.AvailableSell;
                        _productRepository.Update(product);
                        await Task.Delay(100);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }

                await SendOrderCancelConfirmationEmailForSupplierToMember(account, account.Email, supplierAccount.Email, account.FirstName, orderDetail, totalOrderPrice);
                await Task.Delay(100);
                await SendOrderCancelConfirmationEmailForSupplierToSystem(account, account.Email, supplierAccount.Email, supplierAccount.FirstName, account.FirstName, orderDetail, totalOrderPrice);

                // Prepare response data
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

        private async Task SendOrderCancelNotificationToSupplier(Account account, string supplierEmail, string customerFirstName, OrderDetail orderDetail, double totalOrderPrice)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                $"   Tình trạng: {orderDetail.ProductQuality}<br />" +
                $"   Đơn giá: {orderDetail.ProductPrice:N0} ₫<br />" +
                $"   Giảm giá: {orderDetail.Discount:N0} ₫<br />" +
                $"   Thành tiền: {orderDetail.ProductPriceTotal:N0} ₫<br />";

            // Invoice information for the cancellation notification
            var invoiceInfo =
                "THÔNG BÁO HỦY ĐƠN HÀNG<br /><br />" +
                $"Mã hóa đơn: #{orderDetail.OrderID}<br />" +
                $"Ngày hủy: {DateTime.Now:dd/MM/yyyy}<br /><br />" +
                "Thông tin khách hàng<br />" +
                $"{customerFirstName}<br />" +
                $"Điện thoại: {account.PhoneNumber ?? "N/A"}<br />" +
                $"Email: {account.Email}<br />" +
                $"Địa chỉ: {account.Address ?? "N/A"}<br /><br />";

            // Order summary and total
            var orderSummary =
                "=====================================<br />" +
                "         CHI TIẾT ĐƠN HÀNG ĐÃ HỦY<br />" +
                "=====================================<br />" +
                $"{orderDetailsString}<br />" +
                "-------------------------------------<br />" +
                $"Tổng số tiền đã hủy: {totalOrderPrice:N0} ₫<br />" +
                "=====================================<br />";

            var emailMessage =
                $"Kính chào {account.FirstName},<br /><br />" +
                "Chúng tôi xin thông báo rằng đơn hàng của quý khách đã bị hủy. Dưới đây là chi tiết đơn hàng đã hủy:<br /><br />" +
                invoiceInfo +
                orderSummary +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Send the email asynchronously and wait for completion
             emailService.SendEmail(
                supplierEmail,
               SD.SubjectMail.ORDER_CONFIRMATION_CANCEL_SUPPLIER,
                emailMessage
            );
        }
        private async Task SendOrderCancelConfirmationEmailForSupplierToMember(Account account,string email ,string supplierEmail, string firstName, OrderDetail orderDetail, double totalOrderPrice)
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
                $"Cảm ơn quý khách đã tin tưởng sử dụng dịch vụ của chúng tôi. Đơn hàng của bạn đã được xác nhận hủy bởi {supplierEmail}. Dưới đây là thông tin hóa đơn chi tiết của quý khách:<br /><br />" +
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

        private async Task SendOrderCancelConfirmationEmailForSupplierToSystem(Account account, string email, string supplierEmail, string supplierName, string firstName, OrderDetail orderDetail, double totalOrderPrice)
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
                $"Địa chỉ: {account.Address ?? "Khách đến lấy"}<br /><br />" +
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
                "Kính chào Đội ngũ Camera service platform,<br /><br />" +
                $"Đơn hàng của {firstName} đã được xác nhận hủy bởi {supplierName} với email là {supplierEmail}. Dưới đây là thông tin hóa đơn chi tiết của đơn được hủy:<br /><br />" +
                invoiceInfo +
                orderSummary +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                $"{supplierName}";

            // Send the email asynchronously and wait for completion
           
            string systemEmail = "dan1314705@gmail.com";

            emailService.SendEmail(
               systemEmail,
               SD.SubjectMail.ORDER_CONFIRMATION,
               emailMessage
           );
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
                if (OrderSupplierID == null)
                {
                    result = BuildAppActionResultError(result, "ID không được để tróng!");
                    return result;
                }
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
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }


        public async Task<AppActionResult> GetOrderStatusOfSupplier(string? SupplierID, OrderStatus status, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(SupplierID, out Guid OrderSupplierID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                if (OrderSupplierID == null)
                {
                    result = BuildAppActionResultError(result, "ID không được để tróng!");
                    return result;
                }
                var pagedResult1 = await _orderRepository.GetAllDataByExpression(
                        x => x.SupplierID == OrderSupplierID && x.OrderStatus == status,
                        pageIndex,
                        pageSize,
                        includes: new Expression<Func<Order, object>>[] { o => o.OrderDetail }

                    );
                var convertedResult1 = pagedResult1.Items.Select(order => _mapper.Map<OrderResponse>(order)).ToList();

                result.Result = convertedResult1;
                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderOrderStatusByAccountID(string AccountID, OrderStatus orderStatus, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
               
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.Id == AccountID && x.OrderStatus == orderStatus,
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

        public async Task<AppActionResult> GetOrderOfAccountByOrderID(string OrderId, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.OrderID == Guid.Parse(OrderId),
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

        private async Task SendOrderRentConfirmationEmail(Account account, Account supplierAccount, string email, string firstName,Order order, OrderDetail orderDetail, double totalOrderPrice, List<ContractTemplate> contractTemplates)
        {
            IEmailService? emailService = Resolve<IEmailService>();
            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                $"   Tình trạng: {orderDetail.ProductQuality}<br />" +
                $"   Đơn giá: {orderDetail.ProductPrice:N0} ₫<br />" +
                $"   Ngày thuê: {order.OrderDate}<br />" +
                $"   Ngày nhận dự kiến: {order.RentalStartDate}<br />" +
                $"   Ngày trả: {order.RentalEndDate}<br />" +
                $"   Giảm giá: {orderDetail.Discount:N0} ₫<br />" +
                $"   Tiền cọc: {order.Deposit:N0} ₫<br />" +
                $"   Thành tiền: {order.TotalAmount:N0} ₫<br />";

            // Invoice information template
            var invoiceInfo =
                "HÓA ĐƠN<br /><br />" +
                $"Mã hóa đơn: #{orderDetail.OrderID}<br />" +
                $"Ngày tạo: {DateTime.Now:dd/MM/yyyy}<br />" +
                $"Hạn thanh toán: {DateTime.Now.AddDays(3):dd/MM/yyyy}<br /><br />" + // Set payment deadline to 3 days later
                "Khách hàng<br />" +
                $"{account.FirstName}<br />" +
                $"Điện thoại: {account.PhoneNumber ?? "N/A"}<br />" +
                $"Email: {account.Email}<br />" +
                $"Địa chỉ: {order.ShippingAddress ?? "Khách đến lấy"}<br /><br />" +
                "Nhà cung cấp<br />" +
                 $"Tên: {supplierAccount.FirstName}<br />" +
                $"Điện thoại: {supplierAccount.PhoneNumber}<br />" +
                $"Email: {supplierAccount.Email}<br />" +
                $"Địa chỉ: {supplierAccount.Address}<br /><br />";

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
            var contractTemplatesString = "Điều khoản hợp đồng:<br />";
            for (int i = 0; i < contractTemplates.Count; i++)
            {
                var template = contractTemplates[i];
                contractTemplatesString += $"<b>{i + 1}. {template.TemplateName}</b><br />";
                contractTemplatesString += $"<i>Điều khoản hợp đồng:</i> {template.ContractTerms ?? "N/A"}<br />";
                contractTemplatesString += $"<i>Chi tiết hợp đồng:</i> {template.TemplateDetails ?? "N/A"}<br />";
                contractTemplatesString += $"<i>Chính sách phạt:</i> {template.PenaltyPolicy ?? "N/A"}<br /><br />";
            }
            var emailMessage =
                $"Kính chào {account.FirstName},<br /><br />" +
                $"Bạn vừa đặt hàng từ {firstName}. Dưới đây là thông tin hóa đơn chi tiết của đơn hàng của khách hàng:<br /><br />" +
                invoiceInfo +
                orderSummary +
                contractTemplatesString +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Send email with contract templates attached
            emailService.SendEmail(
               email,
               SD.SubjectMail.ORDER_CONFIRMATION_SUPPLIER,
               emailMessage
               );
        }

        private async Task SendOrderRentConfirmationEmailSupplier(Account account, string email, string firstName,Order order, OrderDetail orderDetail, double totalOrderPrice, List<ContractTemplate> contractTemplates)
        {
            IEmailService? emailService = Resolve<IEmailService>();
            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                 "   Hình thức: thuê<br />" +
                $"   Tình trạng: {orderDetail.ProductQuality}<br />" +
                $"   Đơn giá: {orderDetail.ProductPrice:N0} ₫<br />" +
                $"   Ngày thuê: {order.OrderDate}<br />" +
                $"   Ngày nhận dự kiến: {order.RentalStartDate}<br />" +
                $"   Ngày trả: {order.RentalEndDate}<br />" +
                $"   Giảm giá: {orderDetail.Discount:N0} ₫<br />" +
                $"   Tiền cọc: {order.Deposit:N0} ₫<br />" +
                $"   Thành tiền: {order.TotalAmount:N0} ₫<br />";

            // Invoice information template
            var invoiceInfo =
                "HÓA ĐƠN<br /><br />" +
                $"Mã hóa đơn: #{orderDetail.OrderID}<br />" +
                $"Ngày tạo: {DateTime.Now:dd/MM/yyyy}<br />" +
                $"Hạn thanh toán: {DateTime.Now.AddDays(3):dd/MM/yyyy}<br /><br />" + // Set payment deadline to 3 days later
                "Khách hàng<br />" +
                $"{account.FirstName}<br />" +
                $"Điện thoại: {account.PhoneNumber ?? "N/A"}<br />" +
                $"Email: {account.Email}<br />" +
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
            var contractTemplatesString = "Điều khoản hợp đồng:<br />";
            for (int i = 0; i < contractTemplates.Count; i++)
            {
                var template = contractTemplates[i];
                contractTemplatesString += $"<b>{i + 1}. {template.TemplateName}</b><br />";
                contractTemplatesString += $"<i>Nội dung hợp đồng:</i> {template.ContractTerms ?? "N/A"}<br />";
                contractTemplatesString += $"<i>Chi tiết hợp đồng:</i> {template.TemplateDetails ?? "N/A"}<br />";
                contractTemplatesString += $"<i>Chính sách phạt:</i> {template.PenaltyPolicy ?? "N/A"}<br /><br />";
            }
            var emailMessage =
                $"Kính chào {firstName},<br /><br />" +
                "Bạn vừa có đơn đặt hàng. Dưới đây là thông tin hóa đơn chi tiết của đơn hàng của khách hàng:<br /><br />" +
                invoiceInfo +
                orderSummary +
                contractTemplatesString +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Prepare the list of attachment file paths
          

            // Send email with contract templates attached
            emailService.SendEmail(
               email,
               SD.SubjectMail.ORDER_CONFIRMATION_SUPPLIER,
               emailMessage
           );
        }

        private async Task<string> GenerateContractPdf(ContractTemplate template)
        {

            string filePath = Path.Combine("path_to_save_pdfs", $"{template.ContractTemplateId}.pdf");

            var pdfDocument = new PdfDocument();
            var page = pdfDocument.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 12, XFontStyleEx.Regular);

            gfx.DrawString($"Contract Template: {template.TemplateName}", font, XBrushes.Black, new XPoint(40, 40));
            gfx.DrawString($"Terms: {template.ContractTerms}", font, XBrushes.Black, new XPoint(40, 60));
            gfx.DrawString($"Penalty Policy: {template.PenaltyPolicy}", font, XBrushes.Black, new XPoint(40, 80));

            pdfDocument.Save(filePath);

            return filePath; 
        }

        public async Task<AppActionResult> AddImageProductAfter(ImageProductAfterDTO dto)
        {
            IFirebaseService? firebaseService = Resolve<IFirebaseService>();
            AppActionResult result = new();
            try
            {

                if (!Guid.TryParse(dto.OrderID, out Guid OrderUpdateId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var order = await _orderRepository.GetById(OrderUpdateId);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                string? ImageUrl = null;
                if (dto.Img != null)
                {
                    string PathName = SD.FirebasePathName.AFTER_IMAGE + $"{dto.OrderID}_after.jpg";
                    AppActionResult frontUpload = await firebaseService.UploadFileToFirebase(dto.Img, PathName);
                    ImageUrl = frontUpload?.Result?.ToString();
                }

                result.Result = ImageUrl;
                result.IsSuccess = true;
                
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> AddImageProductBefore(ImageProductBeforeDTO dto)
        {
            IFirebaseService? firebaseService = Resolve<IFirebaseService>();
            AppActionResult result = new();
            try
            {

                if (!Guid.TryParse(dto.OrderID, out Guid OrderUpdateId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var order = await _orderRepository.GetById(OrderUpdateId);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                string? ImageUrl = null;

                if (dto.Img != null)
                {
                    string PathName = SD.FirebasePathName.BEFORE_IMAGE + $"{dto.OrderID}_.jpg";
                    AppActionResult frontUpload = await firebaseService.UploadFileToFirebase(dto.Img, PathName);
                    ImageUrl = frontUpload?.Result?.ToString();
                }

                result.Result = ImageUrl;
                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetImageProductAfter(string orderId)
        {
            IFirebaseService? firebaseService = Resolve<IFirebaseService>();
            AppActionResult result = new();

            try
            {
                if (!Guid.TryParse(orderId, out Guid orderGuid))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var order = await _orderRepository.GetById(orderGuid);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                string pathName = SD.FirebasePathName.AFTER_IMAGE + $"{orderId}_after.jpg.png";

                string? imageUrl = await firebaseService.GetUrlImageAfterAndBeforeFromFirebase(pathName);

                if (string.IsNullOrEmpty(imageUrl))
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy ảnh!");
                    return result;
                }

                result.Result = imageUrl;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetImageProductBefore(string orderId)
        {
            IFirebaseService? firebaseService = Resolve<IFirebaseService>();
            AppActionResult result = new();

            try
            {
                if (!Guid.TryParse(orderId, out Guid orderGuid))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var order = await _orderRepository.GetById(orderGuid);
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại!");
                    return result;
                }

                string pathName = SD.FirebasePathName.BEFORE_IMAGE + $"{orderId}_.jpg.png";

                string? imageUrl = await firebaseService.GetUrlImageAfterAndBeforeFromFirebase(pathName);

                if (string.IsNullOrEmpty(imageUrl))
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy ảnh!");
                    return result;
                }

                result.Result = imageUrl;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllOrderRent(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Order, bool>>? filter = x => x.OrderType == OrderType.Rental;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    filter: filter,
                    pageNumber: pageIndex,
                    pageSize: pageSize,
                    includes: new Expression<Func<Order, object>>[]
                    {
                o => o.OrderDetail,
                    }
                );

                var currentVietnamTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);

                foreach (var order in pagedResult.Items)
                {
                    if (order.RentalStartDate < currentVietnamTime.AddHours(-24) && order.OrderStatus == OrderStatus.Pending)
                    {
                        order.OrderStatus = OrderStatus.Cancelled;
                        await _orderRepository.Update(order);
                        var orderDetail = await _orderDetailRepository.GetByExpression(x => x.OrderID == order.OrderID);
                        if (orderDetail != null)
                        {
                            var product = await _productRepository.GetByExpression(x => x.ProductID == orderDetail.ProductID);
                            product.Status = ProductStatusEnum.AvailableRent;
                            _productRepository.Update(product);
                            await Task.Delay(100);
                            await _unitOfWork.SaveChangesAsync();
                        }

                    }
                }

                var convertedResult = pagedResult.Items.Select(order =>
                {
                    var orderResponse = _mapper.Map<OrderRentResponse>(order);

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

        public async Task<AppActionResult> GetAllOrderBuy(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Order, bool>>? filter = x => x.OrderType == OrderType.Purchase;

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
    }
}
