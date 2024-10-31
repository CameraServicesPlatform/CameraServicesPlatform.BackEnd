using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.PaymentLibrary;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentGatewayService(IConfiguration configuration,
            IRepository<Payment> paymentRepository,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
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
            var urlCallBack = $"{_configuration["Vnpay:ReturnUrl"]}/{requestDto.OrderID}";

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
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", requestDto.OrderID);
            paymentUrl = pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            //await SavePaymentInfoAsync(requestDto, PaymentStatus.Pending, PaymentType.Refund);

            return paymentUrl;
        }

        public async Task SavePaymentInfoAsync(PaymentInformationRequest request, PaymentStatus status, PaymentType type)
        {
            var payment = new Payment
            {
                PaymentID = Guid.NewGuid(),
                OrderID = Guid.Parse(request.OrderID),
                SupplierID = Guid.Parse(request.SupplierID),
                AccountID = request.AccountID,
                PaymentDate = DateTime.UtcNow,
                PaymentAmount = request.Amount,
                PaymentStatus = status,
                PaymentType = type,
                PaymentDetails = $"Payment for Order {request.OrderID}",
                CreatedAt = DateTime.UtcNow
            };

            await _paymentRepository.Insert(payment);
            await _unitOfWork.SaveChangesAsync();
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
            var vnp_orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
            var vnp_TransactionId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
            var vnp_SecureHash = coletions.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");

            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _configuration["VnPay:HashSecret"]);
            if (checkSignature)
            {
                return new VNPayResponseDto
                {
                    Success = false
                };
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
