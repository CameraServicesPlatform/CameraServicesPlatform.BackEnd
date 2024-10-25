using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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


     }
}
