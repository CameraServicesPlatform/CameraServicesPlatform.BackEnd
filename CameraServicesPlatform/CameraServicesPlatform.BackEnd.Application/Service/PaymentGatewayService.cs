using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.PaymentLibrary;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Staff> _staffRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<HistoryTransaction> _historyTransaction;

        private readonly IUnitOfWork _unitOfWork;

        public PaymentGatewayService(IConfiguration configuration,
            IRepository<Payment> paymentRepository,
            IRepository<Transaction> transactionRepository,
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            IRepository<Staff> staffRepository,
            IRepository<HistoryTransaction> historyTransaction,
            IRepository<Supplier> supplierRepository,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _staffRepository = staffRepository;
            _unitOfWork = unitOfWork;
            _historyTransaction = historyTransaction;
            _supplierRepository = supplierRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<string> CreatePaymentUrlVnpay(PaymentInformationRequest requestDto, HttpContext httpContext)
        {
            var paymentUrl = "";
            var momo = new PaymentInformationRequest
            {
                AccountID = requestDto.AccountID,
                Amount = requestDto.Amount,
                MemberName = requestDto.MemberName,
                OrderID = requestDto.OrderID
            };
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var pay = new VNPayLibrary();
            //var urlCallBack = $"{_configuration["Vnpay:ReturnUrl"]}/{requestDto.OrderID}";
            var urlCallBack = $"{_configuration["Vnpay:ReturnUrl"]}";
            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)requestDto.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(httpContext));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo",
                $"Khach hang: {requestDto.MemberName} thanh toan hoa don {requestDto.OrderID}");
            pay.AddRequestData("vnp_OrderType", "other");
            //pay.AddRequestData("vnp_Account", requestDto.AccountID);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);

            pay.AddRequestData("vnp_TxnRef", requestDto.OrderID);
            paymentUrl = pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            //await SavePaymentInfoAsync(requestDto, PaymentStatus.Pending, PaymentType.Refund);

            return paymentUrl;
        }
        
        public async Task<string> CreateSupplierPayment(SupplierPaymentDto requestDto, HttpContext httpContext)
        {
            var paymentUrl = "";
            
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var pay = new VNPayLibrary();
            //var urlCallBack = $"{_configuration["Vnpay:ReturnUrl"]}/{requestDto.OrderID}";
            var urlCallBack = $"{_configuration["Vnpay:ReturnUrl"]}";
            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)requestDto.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(httpContext));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo",
                $"{requestDto.SupplierID} shop: {requestDto.SupplierName} da nap tien: {requestDto.Amount} vnd");
            pay.AddRequestData("vnp_OrderType", "other");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", Guid.NewGuid().ToString());
            paymentUrl = pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            //await SavePaymentInfoAsync(requestDto, PaymentStatus.Pending, PaymentType.Refund);

            return paymentUrl;
        }



        public async Task<VNPayResponseDto> PaymentExcute(IQueryCollection coletions)
        {
            var vnpay = new VNPayLibrary();
            foreach (var (key, value) in coletions)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value.ToString());
                }
            }

            var vnp_orderId = vnpay.GetResponseData("vnp_TxnRef");
            var vnp_TransactionId = vnpay.GetResponseData("vnp_TransactionNo");
            var vnp_SecureHash = coletions.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
            var vnp_Amount = vnpay.GetResponseData("vnp_Amount");
            int spaceIndex = vnp_OrderInfo.IndexOf(' ');
            string supplierId = vnp_OrderInfo.Substring(0, spaceIndex);
            vnp_OrderInfo = vnp_OrderInfo.Substring(spaceIndex + 1);
            // List<string> roleListDb = await _accountService.GetRoleListByAccountId(pagedResult.Items[0].Id);
            if (vnp_OrderInfo.Contains("da nap tien"))
            {
                
                var pagedResult = await _supplierRepository.GetById(Guid.Parse(supplierId));
                pagedResult.AccountBalance = pagedResult.AccountBalance + Int32.Parse(vnp_Amount);
                _supplierRepository.Update(pagedResult);
                if (vnp_ResponseCode == "00")
                {
                    var historyTransaction = new HistoryTransaction
                    {
                        HistoryTransactionId = Guid.NewGuid(),
                        SupplierID = pagedResult.SupplierID,
                        Price = Int32.Parse(vnp_Amount),
                        TransactionDescription = vnp_OrderInfo,
                        Status = TransactionStatus.Success,
                        CreatedAt = DateTime.Now
                    };
                    await _historyTransaction.Insert(historyTransaction);
                    await _unitOfWork.SaveChangesAsync();

                }
                else
                {
                    var historyTransaction = new HistoryTransaction
                    {
                        HistoryTransactionId = Guid.NewGuid(),
                        SupplierID = Guid.Parse(vnp_orderId),
                        Price = Int32.Parse(vnp_Amount),
                        TransactionDescription = vnp_OrderInfo,
                        Status = TransactionStatus.Unsuccess,
                        CreatedAt = DateTime.Now
                    };
                    await _historyTransaction.Insert(historyTransaction);
                    await _unitOfWork.SaveChangesAsync();

                }

            }
            else
            {
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                     a => a.OrderID == Guid.Parse(vnp_orderId),
                     1,
                     10,
                     null,
                     isAscending: true,
                     null
                 );
                var staffExist = await _staffRepository.GetAllDataByExpression(
                        a => a.AccountID == pagedResult.Items[0].Id,
                        1,
                        10,
                        null,
                        isAscending: true,
                        null
                    );

                var orderDb = await _orderRepository.GetByExpression(a => a.OrderID == Guid.Parse(vnp_orderId));

               


                if (vnp_ResponseCode == "00")
                {
                    orderDb.OrderStatus = OrderStatus.Payment;
                    _orderRepository.Update(orderDb);
                    await _unitOfWork.SaveChangesAsync();

                    var productEntity = await _orderRepository.GetByExpression(
                    x => x.OrderID == Guid.Parse(vnp_orderId),
                    a => a.OrderDetail 
                    );

                    if (productEntity != null && productEntity.OrderDetail != null)
                    {
                        foreach (var detail in productEntity.OrderDetail)
                        {
                            var product = await _productRepository.GetByExpression(x => x.ProductID == detail.ProductID);

                            if (product != null)
                            {
                                if (orderDb.OrderType == OrderType.Purchase) {
                                    product.Status = ProductStatusEnum.Sold;
                                    _productRepository.Update(product);
                                }
                                else
                                {
                                    product.Status = ProductStatusEnum.Rented;
                                    _productRepository.Update(product);
                                }
                               
                            }
                        }
                        await _unitOfWork.SaveChangesAsync();
                    }

                    var payment = new Payment
                    {
                        PaymentID = Guid.NewGuid(),
                        OrderID = Guid.Parse(vnp_orderId),
                        SupplierID = pagedResult.Items[0].SupplierID,
                        AccountID = pagedResult.Items[0].Id,
                        PaymentDate = DateTime.UtcNow,
                        PaymentAmount = Int32.Parse(vnp_Amount),
                        PaymentStatus = PaymentStatus.Completed,
                        PaymentType = PaymentType.Refund,
                        PaymentMethod = PaymentMethod.VNPAY,
                        PaymentDetails = $"Payment for Order {vnp_orderId}",
                        CreatedAt = DateTime.UtcNow,
                        Image = "a",
                        IsDisable = true
                    };
                    TransactionType transactionType = (staffExist.Items.Any()) ? TransactionType.Refund : TransactionType.Payment;
                    ;
                    await _paymentRepository.Insert(payment);

                    Transaction transaction = new Transaction
                    {
                        TransactionID = Guid.NewGuid(),
                        OrderID = Guid.Parse(vnp_orderId),
                        TransactionDate = DateTime.UtcNow,
                        Order = null,
                        Amount = Int32.Parse(vnp_Amount),
                        TransactionType = transactionType,
                        PaymentStatus = PaymentStatus.Completed,
                        PaymentMethod = PaymentMethod.VNPAY,
                        VNPAYTransactionID = vnp_TransactionId,
                        VNPAYTransactionStatus = VNPAYTransactionStatus.Success,
                        VNPAYTransactionTime = DateTime.UtcNow,
                    };
                    await _transactionRepository.Insert(transaction);
                    await _unitOfWork.SaveChangesAsync();


                }
                if (vnp_ResponseCode != "00")
                {
                    var payment = new Payment
                    {
                        PaymentID = Guid.NewGuid(),
                        OrderID = Guid.Parse(vnp_orderId),
                        SupplierID = pagedResult.Items[0].SupplierID,
                        AccountID = pagedResult.Items[0].Id,
                        PaymentDate = DateTime.UtcNow,
                        PaymentAmount = Int32.Parse(vnp_Amount),
                        PaymentStatus = PaymentStatus.Failed,
                        PaymentType = PaymentType.Refund,
                        PaymentMethod = PaymentMethod.VNPAY,
                        PaymentDetails = $"Payment for Order {vnp_orderId}",
                        CreatedAt = DateTime.UtcNow,
                        Image = "a",
                        IsDisable = true
                    };
                    TransactionType transactionType = (staffExist.Items.Any()) ? TransactionType.Refund : TransactionType.Payment;
                    ;
                    await _paymentRepository.Insert(payment);
                    await _unitOfWork.SaveChangesAsync();

                    orderDb.OrderStatus = OrderStatus.PaymentFail;
                    _orderRepository.Update(orderDb);
                    await _unitOfWork.SaveChangesAsync();

                    Transaction transaction = new Transaction
                    {
                        TransactionID = Guid.NewGuid(),
                        OrderID = Guid.Parse(vnp_orderId),
                        TransactionDate = DateTime.UtcNow,
                        Order = null,
                        Amount = Int32.Parse(vnp_Amount),
                        TransactionType = transactionType,
                        PaymentStatus = PaymentStatus.Failed,
                        PaymentMethod = PaymentMethod.VNPAY,
                        VNPAYTransactionID = vnp_TransactionId,
                        VNPAYTransactionStatus = VNPAYTransactionStatus.Failed,
                        VNPAYTransactionTime = DateTime.UtcNow,
                    };
                    await _transactionRepository.Insert(transaction);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            
            return new VNPayResponseDto
            {
                Success = true,
                PaymentMethod = "VnPay",
                OrderDescription = vnp_OrderInfo,
                OrderId = vnp_orderId.ToString(),
                TransactionId = vnp_TransactionId.ToString(),
                Token = vnp_SecureHash,
                VnPayResponseCode = vnp_ResponseCode,
            };
        }
    }
}
