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
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.Id = request.AccountID;
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
                await SendOrderConfirmationEmail(getAccount, getAccount.Email, getAccount.FirstName, orderDetail, (double)order.TotalAmount);
                await Task.Delay(100);
                await SendOrderConfirmationEmailToSupplier(getAccount , supplierAccount.Email, supplierAccount.FirstName, orderDetail, (double)order.TotalAmount);
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
                await SendOrderConfirmationEmail(getAccount, getAccount.Email, getAccount.FirstName, orderDetail, (double)order.TotalAmount);
                await Task.Delay(100);
                await SendOrderConfirmationEmailToSupplier(getAccount, supplierAccount.Email, supplierAccount.FirstName, orderDetail, (double)order.TotalAmount);
                await Task.Delay(100);
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

        private async Task SendOrderConfirmationEmailToSupplier(Account account, string email, string firstName, OrderDetail orderDetail, double totalOrderPrice)
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
                    var createPayment = await paymentGatewayService!.CreatePaymentUrlVnpay(payment, context);

                    orderDb.OrderStatus = OrderStatus.Payment;
                    _orderRepository.Update(orderDb);
                    await _unitOfWork.SaveChangesAsync();

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
        public async Task<OrderResponse> CreateOrderRent(CreateOrderRentRequest request)
        {
            var result = new OrderResponse();

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
                order.OrderDate = DateTime.UtcNow;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.SupplierID = Guid.Parse(request.SupplierID);
                order.OrderStatus = OrderStatus.Pending;
                order.OrderType = OrderType.Rental;
                order.DeliveriesMethod = request.DeliveryMethod;
                order.DurationValue = request.DurationValue;
                order.DurationUnit = request.DurationUnit;
                order.ReturnDate = request.ReturnDate;
                order.ShippingAddress = request.ShippingAddress;
                order.RentalEndDate = request.RentalEndDate;
                order.RentalStartDate = request.RentalStartDate;


                // Tính tổng tiền thuê
                //double totalOrderPrice = CalculateRentalPrice( request.TotalAmount, request.DurationUnit, request.DurationValue);
                order.TotalAmount = request.TotalAmount;

                var product = await _productRepository.GetById(productID);
                if (product == null)
                {
                    throw new Exception("Product not found.");
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
                    ProductQuality = product.Quality,  // Assuming a quantity of 1 for a single product order
                    ProductPriceTotal = request.TotalAmount
                };

                order.TotalAmount = orderDetail.ProductPriceTotal;
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
                    pageSize: int.MaxValue );

                // Kiểm tra nếu có item trong kết quả phân trang
                if (pagedContractTemplates != null && pagedContractTemplates.Items.Any())
                {
                    var contractOfProductContract = pagedContractTemplates.Items;

                    foreach (var template in contractOfProductContract)
                    {
                        var contract = new Contract
                        {
                            OrderID = order.OrderID,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            ContractTemplateId = template.ContractTemplateId
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

                // Ánh xạ thông tin đơn hàng sang response
                var orderResponse = _mapper.Map<OrderResponse>(order);
                orderResponse.AccountID = order.Id.ToString();
                orderResponse.SupplierID = order.SupplierID.ToString();

                var contractOfProduct = pagedContractTemplates.Items;
                // Send confirmation email to the customer
                await SendOrderRentConfirmationEmail(getAccount, getAccount.Email, supplierAccount.FirstName, order, orderDetail, TotalPrice, contractOfProduct);

                // Send confirmation email to the supplier
                await SendOrderRentConfirmationEmailSupplier(getAccount, supplierAccount.Email, supplierAccount.FirstName, order, orderDetail, TotalPrice, contractOfProduct);

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
                var orderDetail = await _orderDetailRepository.GetById(OrderUpdateId);
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
                var orderDetail = await _orderDetailRepository.GetById(OrderUpdateId);
                double totalOrderPrice = (double)order.TotalAmount;

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

        private async Task SendOrderRentConfirmationEmail(Account account, string email, string firstName,Order order, OrderDetail orderDetail, double totalOrderPrice, List<ContractTemplate> contractTemplates)
        {
            IEmailService? emailService = Resolve<IEmailService>();
            // Generate a string representation of the order detail with HTML line breaks
            var orderDetailsString = $"{1}. Mã sản phẩm: {orderDetail.ProductID}<br />" +
                $"   Tình trạng: {orderDetail.ProductQuality}<br />" +
                $"   Đơn giá: {orderDetail.ProductPrice:N0} ₫<br />" +
                $"   Ngày thuê: {order.RentalStartDate}<br />" +
                $"   Ngày trả: {order.RentalEndDate}<br />" +
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
                $"Kính chào {account.FirstName},<br /><br />" +
                $"Bạn vừa đặt hàng từ {firstName}. Dưới đây là thông tin hóa đơn chi tiết của đơn hàng của khách hàng:<br /><br />" +
                invoiceInfo +
                orderSummary +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Prepare the list of attachment file paths
            var attachmentFilePaths = new List<string>();

            // Generate PDF contracts from the provided templates and add to attachment list
            foreach (var template in contractTemplates)
            {
                string contractPdfPath = await GenerateContractPdf(template); // Method to generate PDF contract
                if (File.Exists(contractPdfPath))
                {
                    attachmentFilePaths.Add(contractPdfPath); // Add the generated contract PDF to attachment list
                }
            }

            // Send email with contract templates attached
            emailService.SendEmailWithAttachments(
               email,
               SD.SubjectMail.ORDER_CONFIRMATION_SUPPLIER,
               emailMessage,
               attachmentFilePaths
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
                $"   Ngày thuê: {order.RentalStartDate}<br />" +
                $"   Ngày trả: {order.RentalEndDate}<br />" +
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
                "Bạn vừa có đơn đặt hàng. Dưới đây là thông tin hóa đơn chi tiết của đơn hàng của khách hàng:<br /><br />" +
                invoiceInfo +
                orderSummary +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Prepare the list of attachment file paths
            var attachmentFilePaths = new List<string>();

            // Generate PDF contracts from the provided templates and add to attachment list
            foreach (var template in contractTemplates)
            {
                string contractPdfPath = await GenerateContractPdf(template); // Method to generate PDF contract
                if (File.Exists(contractPdfPath))
                {
                    attachmentFilePaths.Add(contractPdfPath); // Add the generated contract PDF to attachment list
                }
            }

            // Send email with contract templates attached
            emailService.SendEmailWithAttachments(
               email,
               SD.SubjectMail.ORDER_CONFIRMATION_SUPPLIER,
               emailMessage,
               attachmentFilePaths
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
    }
}
