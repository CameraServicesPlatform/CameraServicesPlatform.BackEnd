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
using DinkToPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Policy;
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
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<HistoryTransaction> _historyTransaction;

        private readonly IUnitOfWork _unitOfWork;

        public PaymentGatewayService(IConfiguration configuration,
            IRepository<Payment> paymentRepository,
            IRepository<Transaction> transactionRepository,
            IRepository<Order> orderRepository,
            IRepository<Supplier> supplierRepository,
            IRepository<Product> productRepository,
            IRepository<Staff> staffRepository,
            IRepository<HistoryTransaction> historyTransaction,
            IRepository<Account> accountRepository,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _staffRepository = staffRepository;
            _unitOfWork = unitOfWork;
            _historyTransaction = historyTransaction;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
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

        public async Task<string> CreateStaffRefund(StaffRefundDto request, HttpContext httpContext)
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
            //pay.AddRequestData("vnp_Amount", ((int)request.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(httpContext));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);


            /*pay.AddRequestData("vnp_OrderInfo",
                $"{request.StaffId} {request.AccountId} don hang {request.OrderID} da duoc hoan tien");*/
            pay.AddRequestData("vnp_OrderType", "other");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);

            pay.AddRequestData("vnp_TxnRef", request.OrderID);
            paymentUrl = pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            //await SavePaymentInfoAsync(requestDto, PaymentStatus.Pending, PaymentType.Refund);

            return paymentUrl;
        }

        public async Task<string> CreateSupplierOrMemberPayment(SupplierPaymentAgainDto requestDto, HttpContext httpContext)
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
                $"{requestDto.AccountId} Khach hang: da nap tien {requestDto.Amount} VND");
            pay.AddRequestData("vnp_OrderType", "other");
            //pay.AddRequestData("vnp_Account", requestDto.AccountID);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);

            pay.AddRequestData("vnp_TxnRef", requestDto.OrderID);
            paymentUrl = pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            //await SavePaymentInfoAsync(requestDto, PaymentStatus.Pending, PaymentType.Refund);

            return paymentUrl;
        }

        public async Task<string> CreateComboPayment(CreateComboPaymentDTO requestDto, HttpContext httpContext)
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
            pay.AddRequestData("vnp_OrderInfo", $"{requestDto.AccountId} thanh toan combo {requestDto.Amount} VND");
            pay.AddRequestData("vnp_OrderType", "other");
            //pay.AddRequestData("vnp_Account", requestDto.AccountID);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);

            pay.AddRequestData("vnp_TxnRef", requestDto.OrderID);
            paymentUrl = pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            //await SavePaymentInfoAsync(requestDto, PaymentStatus.Pending, PaymentType.Refund);

            return paymentUrl;
        }
        public async Task<VNPayResponseDto> deposit(string vnp_ResponseCode, string vnp_orderId, string vnp_OrderInfo, string vnp_Amount, string vnp_TransactionId, string vnp_SecureHash)
        { 
            int spaceIndex = vnp_OrderInfo.IndexOf(' ');
            string accountId = vnp_OrderInfo.Substring(0, spaceIndex);
            vnp_OrderInfo = vnp_OrderInfo.Substring(spaceIndex + 1);
            var pagedResult = await _accountRepository.GetAllDataByExpression(
                        a => a.Id == accountId,
                        1,
                        10,
                        null,
                        isAscending: true,
                        null
                    );
            if (pagedResult.Items[0].AccountBalance == null)
                pagedResult.Items[0].AccountBalance = 0;
            pagedResult.Items[0].AccountBalance = pagedResult.Items[0].AccountBalance + Int32.Parse(vnp_Amount);
            _accountRepository.Update(pagedResult.Items[0]);
            TransactionStatus status = (vnp_ResponseCode != "00") ? TransactionStatus.Unsuccess : TransactionStatus.Success;
            var historyTransaction = new HistoryTransaction
            {
                HistoryTransactionId = Guid.Parse(vnp_orderId),
                AccountID = pagedResult.Items[0].Id,
                StaffID = null,
                Price = Int32.Parse(vnp_Amount),
                TransactionDescription = vnp_OrderInfo,
                Status = status,
                CreatedAt = DateTime.Now
            };
            await _historyTransaction.Insert(historyTransaction);
            await _unitOfWork.SaveChangesAsync();
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

        public async Task<bool> StaffRefund(string vnp_ResponseCode, string vnp_orderId, string vnp_OrderInfo, string vnp_Amount)
        {
            try
            {
                
                var infoParts = vnp_OrderInfo.Split(' ', 3);
                
                string staffId = infoParts[0];
                string accountId = infoParts[1];
                string transactionDescription = infoParts[2];

                // Validate vnp_Amount and convert to integer
                if (!int.TryParse(vnp_Amount, out int refundAmount))
                {
                    throw new FormatException("vnp_Amount is not a valid integer.");
                }

                var pagedResult = await _accountRepository.GetAllDataByExpression(
                        a => a.Id == accountId,
                        1,
                        10,
                        null,
                        isAscending: true,
                        null
                    );
                if (pagedResult == null)
                {
                    throw new InvalidOperationException($"Account with ID {accountId} not found.");
                }
                if (pagedResult.Items[0].AccountBalance == null)
                pagedResult.Items[0].AccountBalance = 0;

                pagedResult.Items[0].AccountBalance = pagedResult.Items[0].AccountBalance + Int32.Parse(vnp_Amount);
                _accountRepository.Update(pagedResult.Items[0]);

                TransactionStatus status = vnp_ResponseCode == "00"
                    ? TransactionStatus.Success
                    : TransactionStatus.Unsuccess;

                var historyTransaction = new HistoryTransaction
                {
                    HistoryTransactionId = Guid.Parse(vnp_orderId),
                    AccountID = accountId,
                    Price = Int32.Parse(vnp_Amount)  ,
                    TransactionDescription = transactionDescription,
                    Status = status,
                    CreatedAt = DateTime.UtcNow ,
                    StaffID = Guid.Parse(staffId)
                };

                await _historyTransaction.Insert(historyTransaction);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (consider injecting an ILogger for proper logging)
                Console.WriteLine($"Error in StaffRefund: {ex.Message}");
                return false;
            }
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

            
                 if (vnp_OrderInfo.Contains("thanh toan combo"))
                {
                    var infoParts = vnp_OrderInfo.Split(' ', 3);

                    string staffId = infoParts[0];
                    string accountId = infoParts[0];
                    string transactionDescription = infoParts[2];

                    TransactionStatus status = vnp_ResponseCode == "00"
                       ? TransactionStatus.Success
                       : TransactionStatus.Unsuccess;

                    var historyTransaction = new HistoryTransaction
                    {
                        HistoryTransactionId = Guid.Parse(vnp_orderId),
                        AccountID = accountId,
                        Price = Int32.Parse(vnp_Amount),
                        TransactionDescription = transactionDescription,
                        Status = status,
                        CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                        StaffID = Guid.Parse(staffId)
                    };

                    await _historyTransaction.Insert(historyTransaction);
                    await _unitOfWork.SaveChangesAsync();
                    return new VNPayResponseDto
                    {
                        Success = true,
                        PaymentMethod = "VnPay",
                        OrderDescription = transactionDescription,
                        OrderId = vnp_orderId.ToString(),
                        TransactionId = vnp_TransactionId.ToString(),
                        Token = vnp_SecureHash,
                        VnPayResponseCode = vnp_ResponseCode,
                    };
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

                        orderDb.IsPayment = true;
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
                                    if (orderDb.OrderType == OrderType.Purchase)
                                    {
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
                            PaymentDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            PaymentAmount = Int32.Parse(vnp_Amount),
                            PaymentStatus = PaymentStatus.Completed,
                            PaymentType = PaymentType.Refund,
                            PaymentMethod = PaymentMethod.VNPAY,
                            PaymentDetails = $"Payment for Order {vnp_orderId}",
                            CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
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
                            TransactionDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            Order = null,
                            Amount = Int32.Parse(vnp_Amount),
                            TransactionType = transactionType,
                            PaymentStatus = PaymentStatus.Completed,
                            PaymentMethod = PaymentMethod.VNPAY,
                            VNPAYTransactionID = vnp_TransactionId,
                            VNPAYTransactionStatus = VNPAYTransactionStatus.Success,
                            VNPAYTransactionTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
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
                            PaymentDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            PaymentAmount = Int32.Parse(vnp_Amount),
                            PaymentStatus = PaymentStatus.Failed,
                            PaymentType = PaymentType.Refund,
                            PaymentMethod = PaymentMethod.VNPAY,
                            PaymentDetails = $"Payment for Order {vnp_orderId}",
                            CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            Image = "a",
                            IsDisable = true
                        };
                        TransactionType transactionType = (staffExist.Items.Any()) ? TransactionType.Refund : TransactionType.Payment;
                        ;
                        await _paymentRepository.Insert(payment);
                        await _unitOfWork.SaveChangesAsync();

                        orderDb.OrderStatus = OrderStatus.PaymentFail;
                        orderDb.IsPayment = true;
                        _orderRepository.Update(orderDb);
                        await _unitOfWork.SaveChangesAsync();

                        Transaction transaction = new Transaction
                        {
                            TransactionID = Guid.NewGuid(),
                            OrderID = Guid.Parse(vnp_orderId),
                            TransactionDate = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                            Order = null,
                            Amount = Int32.Parse(vnp_Amount),
                            TransactionType = transactionType,
                            PaymentStatus = PaymentStatus.Failed,
                            PaymentMethod = PaymentMethod.VNPAY,
                            VNPAYTransactionID = vnp_TransactionId,
                            VNPAYTransactionStatus = VNPAYTransactionStatus.Failed,
                            VNPAYTransactionTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
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
