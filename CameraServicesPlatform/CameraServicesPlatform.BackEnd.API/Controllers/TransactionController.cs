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

        /*[HttpPost("create-transaction")]
        public async Task<IActionResult> CreateTransaction(PaymentInformationRequest paymentInformationRequest)
        {
            return Ok(await _paymentGatewayService.CreatePaymentUrlVnpay(paymentInformationRequest, HttpContext));
        }*/

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

        [HttpPost("create-supplier-or-member-payment")]
        public async Task<IActionResult> CreateSupplierOrMemberPayment(SupplierPaymentAgainDto supplierResponse)
        {
            return Ok(await _transactionService.CreateSupplierOrMemberPayment(supplierResponse, HttpContext));
        }
        
        [HttpPost("create-staff-refund-return-detail")]
        public async Task<IActionResult> CreateStaffRefundReturnDetail(StaffRefundDto supplierResponse)
        {
            return Ok(await _transactionService.CreateStaffRefundReturnDetail(supplierResponse, HttpContext));
        }

        [HttpPost("create-staff-refund-deposit")]
        public async Task<IActionResult> CreateStaffRefundDeposit(StaffRefundDto supplierResponse)
        {
            return Ok(await _transactionService.CreateStaffRefundDeposit(supplierResponse, HttpContext));
        }
        [HttpPost("create-staff-refund-supplier")]
        public async Task<IActionResult> CreateStaffRefundSupplier(StaffRefundDto supplierResponse)
        {
            return Ok(await _transactionService.CreateStaffRefundSupplier(supplierResponse, HttpContext));
        }

        [HttpPost("get-image")]
        public async Task<IActionResult> GetImage(string orderId)
        {
            return Ok(await _transactionService.GetImagePayment(orderId));
        }

        [HttpPost("add-image-payment")]
        public async Task<IActionResult> AddImagePayment(ImageProductAfterDTO dto)
        {
            return Ok(await _transactionService.AddImagePayment(dto));
        }

        [HttpPost("create-staff-refund-member-purchuse")]
        public async Task<IActionResult> CreateStaffRefundMemberPurchuse(string orderId)
        {
            return Ok(await _transactionService.CreateStaffRefundPurchuse(orderId, HttpContext));
        }

        /*[HttpPost("create-member-refund")]//member rút tìn từ ví ra tìn mặt
        public async Task<IActionResult> CreateMemberRefund(string orderId)
        {
            return Ok(await _transactionService.CreateMemberRefund(orderId, HttpContext));
        }
*/
        [HttpPost("create-supplier-payment-purchuse/{orderId}")]
        public async Task<IActionResult> CreateSupplierPaymentPurchuse(string orderId)
        {
            return Ok(await _transactionService.CreateSupplierPaymentPurchuse(orderId, HttpContext));
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

            if (responseCode == "00")
            {
                var encodedOrderDescription = Uri.EscapeDataString(response.OrderDescription);
                return Redirect($"http://14.225.212.43/verify-payment?vnp_ResponseCode={responseCode}&vnp_OrderInfo={encodedOrderDescription}&vnp_TxnRef={txnRef}");
            }
            else
            {
                var encodedOrderInfo = Uri.EscapeDataString(orderInfo);
                return Redirect($"http://14.225.212.43/verify-payment?vnp_ResponseCode={responseCode}&vnp_OrderInfo={encodedOrderInfo}&vnp_TxnRef={txnRef}");
            }
        }


    }
}
