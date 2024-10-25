using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class PaymentService : GenericBackendService, IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(
            IRepository<Payment> paymentRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> VNPayReturnAsync(string vnp_TxnRef, string vnp_TransactionStatus)
        {
            var result = new AppActionResult();
            try
            {
                var payment = await _paymentRepository.GetByExpression(p => p.OrderID.ToString() == vnp_TxnRef);

                if (payment == null)
                {
                    result.Result = BuildAppActionResultError(result, "Không tìm thấy thông tin thanh toán");
                }

                if (vnp_TransactionStatus == "00")
                {
                    payment.PaymentStatus = PaymentStatus.Completed;
                }
                else
                {
                    payment.PaymentStatus = PaymentStatus.Failed;
                }

                await _paymentRepository.Update(payment);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result.Result = new
                {
                    PaymentID = payment.PaymentID.ToString(),
                    PaymentStatus = payment.PaymentStatus.ToString(),
                    OrderID = payment.OrderID.ToString(),
                    Amount = payment.PaymentAmount
                };
            }
            catch (Exception ex)
            {
                result.Result = BuildAppActionResultError(result, "Có lỗi xảy ra: " + ex.Message);
            }

            return (IActionResult)result;
        }
    }
}
