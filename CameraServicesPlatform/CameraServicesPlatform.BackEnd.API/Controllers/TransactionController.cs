using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentGatewayService _paymentGatewayService;
        private readonly ITransactionService _transactionService;
        public TransactionController(IPaymentService paymentService, IPaymentGatewayService paymentGatewayService, ITransactionService transactionService)
        {
            _paymentService = paymentService;
            _paymentGatewayService = paymentGatewayService;
            _transactionService = transactionService;
        }

        [HttpPost("create-transaction")]
        public async Task<IActionResult> CreateTransaction(PaymentInformationRequest paymentInformationRequest)
        {
            return Ok(await _paymentGatewayService.CreatePaymentUrlVnpay(paymentInformationRequest, HttpContext));
        }

        [HttpGet("get-all-transaction")]
        public async Task<AppActionResult> GetAllTransaction(int pageIndex = 1, int pageSize = 10)
        {
            return await _transactionService.GetAllTransaction(pageIndex, pageSize);
        }

        [HttpGet("get-transaction-by-id")]
        public async Task<AppActionResult> GetTransactionById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _transactionService.GetTransactionById(id, pageIndex, pageSize);
        }
        
        
        [HttpGet("get-transaction-by-supplier-id")]
        public async Task<AppActionResult> GetTransactionBySupplierId(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _transactionService.GetTransactionBySupplierId(id, pageIndex, pageSize);
        }

        [HttpPost("create-supplier-payment")]
        public async Task<IActionResult> CreateSupplierPayment(SupplierPaymentDto supplierResponse)
        {
            return Ok(await _paymentGatewayService.CreateSupplierPayment(supplierResponse, HttpContext));
        }

        [HttpPost("create-supplier-payment-again")]
        public async Task<IActionResult> CreateSupplierPaymentAgain(SupplierPaymentAgainDto supplierResponse)
        {
            return Ok(await _paymentGatewayService.CreateSupplierPaymentAgain(supplierResponse, HttpContext));
        }
        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallBack()
        {
            string amount = Request.Query["vnp_Amount"];
            string bankCode = Request.Query["vnp_BankCode"];
            string bankTranNo = Request.Query["vnp_BankTranNo"];
            string cardType = Request.Query["vnp_CardType"];
            string orderInfo = Request.Query["vnp_OrderInfo"];
            string payDate = Request.Query["vnp_PayDate"];
            string responseCode = Request.Query["vnp_ResponseCode"];
            string tmnCode = Request.Query["vnp_TmnCode"];
            string transactionNo = Request.Query["vnp_TransactionNo"];
            string transactionStatus = Request.Query["vnp_TransactionStatus"];
            string txnRef = Request.Query["vnp_TxnRef"];
            string secureHash = Request.Query["vnp_SecureHash"];


            Dictionary<string, StringValues> dictionary = new Dictionary<string, StringValues>
        {
            { "vnp_Amount", amount },
            { "vnp_BankCode", bankCode },
            { "vnp_BankTranNo", bankTranNo },
            { "vnp_CardType", cardType },
            { "vnp_OrderInfo", orderInfo },
            { "vnp_PayDate", payDate },
            { "vnp_ResponseCode", responseCode },
            { "vnp_TmnCode", tmnCode },
            { "vnp_TransactionNo", transactionNo },
            { "vnp_TransactionStatus", transactionStatus },
            { "vnp_TxnRef", txnRef },
            { "vnp_SecureHash", secureHash },
        };

            // Chuyển đổi Dictionary sang IQueryCollection
            IQueryCollection queryParams = new QueryCollection(dictionary);
            VNPayResponseDto response = await _paymentGatewayService.PaymentExcute(queryParams);
            if(responseCode == "00") 
            {
                return Redirect($"http://localhost:5173/verify-payment?vnp_ResponseCode={responseCode}&vnp_OrderInfo={orderInfo}&vnp_TxnRef={txnRef}");

            }
            return Redirect($"http://localhost:5173/verify-payment?vnp_ResponseCode={responseCode}&vnp_OrderInfo={orderInfo}&vnp_TxnRef={txnRef}");
        
        }


    }
}
