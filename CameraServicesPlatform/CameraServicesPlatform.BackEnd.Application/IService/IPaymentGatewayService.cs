using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IPaymentGatewayService
    {
        Task<string> CreatePaymentUrlVnpay(PaymentInformationRequest request, HttpContext httpContext);
        Task<string> CreateSupplierPayment(SupplierPaymentDto request, HttpContext httpContext);

        Task<VNPayResponseDto> PaymentExcute(IQueryCollection coletions);
    }
}
