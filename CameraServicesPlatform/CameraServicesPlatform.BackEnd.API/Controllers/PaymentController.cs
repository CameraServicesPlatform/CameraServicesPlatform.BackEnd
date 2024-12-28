using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;
        private readonly IPaymentGatewayService _paymentGatewayService;

        public PaymentController(IPaymentService paymentService, IPaymentGatewayService paymentGatewayService)
        {
            _paymentService = paymentService;
            _paymentGatewayService = paymentGatewayService;
        }

        [HttpPut("vnpay-return")]
        public async Task<IActionResult> VNPayReturnAsync(string vnp_TxnRef, string vnp_TransactionStatus)
        {
            try
            {
                var response = await _paymentService.VNPayReturnAsync(vnp_TxnRef, vnp_TransactionStatus);
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("payment-excute")]
        public async Task<ActionResult<VNPayResponseDto>> PaymentExcute(IQueryCollection coletions)
        {
            try
            {
                var response = await _paymentGatewayService.PaymentExcute(coletions);
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
