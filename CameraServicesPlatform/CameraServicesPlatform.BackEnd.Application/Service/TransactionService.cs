using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Firebase.Auth;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PdfSharp;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class TransactionService : GenericBackendService, ITransactionService
    {
        private readonly IRepository<Transaction> _repository;
        private readonly IRepository<Payment> _paymentRepository;
        IRepository<Domain.Models.Order> _orderRepository;
        IRepository<Account> _accountRepository;
        IRepository<HistoryTransaction> _historyTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(
            IRepository<Transaction> repository,
            IUnitOfWork unitOfWork,
            IRepository<Account> accountRepository,
            IRepository<Payment> paymentRepository,
            IRepository<Domain.Models.Order> orderRepository,
            IRepository<HistoryTransaction> historyTransactionRepository,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _accountRepository = accountRepository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _historyTransactionRepository = historyTransactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        /*public async Task<AppActionResult> CreateTransaction(VNPayResponseDto response, double amount, string account)
        {
            var newTransaction = Resolve<IRepository<Transaction>>();

            AppActionResult result = new AppActionResult();
            
            if (response.VnPayResponseCode == "00")
            {
                Transaction transaction = new Transaction()
                {
                    TransactionID = Guid.NewGuid(),
                    OrderID = Guid.Parse(response.OrderId),
                    Order = null,
                    Amount = amount,
                    TransactionType = TransactionType.Payment,
                    PaymentStatus = PaymentStatus.Completed,
                    PaymentMethod = PaymentMethod.VNPAY,
                    VNPAYTransactionID = response.TransactionId,
                    VNPAYTransactionTime = DateTime.Parse(response.PayDate),
                    
                };
                await newTransaction.Insert(transaction);
                await _unitOfWork.SaveChangesAsync();

                result.Result = transaction;
                result.IsSuccess = true;
                return result;
            }
            else
            {
                Transaction transaction = new Transaction()
                {
                    TransactionID = Guid.NewGuid(),
                    OrderID = Guid.Parse(response.OrderId),
                    Order = null,
                    Amount = amount,
                    TransactionType = TransactionType.Payment,
                    PaymentStatus = PaymentStatus.Failed,
                    PaymentMethod = PaymentMethod.VNPAY,
                    VNPAYTransactionID = response.TransactionId,
                    VNPAYTransactionTime = DateTime.Parse(response.PayDate),
                    
                };
                await newTransaction.Insert(transaction);
                await _unitOfWork.SaveChangesAsync();

                result.Result = transaction;
                result.IsSuccess = true;
                return result;
            }

                        
        }*/

        public async Task<AppActionResult> GetAllTransaction(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<Transaction, bool>>? filter = null;
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<TransactionResponse> listTransaction = new List<TransactionResponse>();
                foreach (var item in pagedResult.Items)
                {

                    TransactionResponse transactionResponse = new TransactionResponse
                    {
                        TransactionID = item.TransactionID.ToString(),
                        OrderID = item.OrderID.ToString(),
                        TransactionDate = item.TransactionDate,
                        Amount = item.Amount,
                        TransactionType = item.TransactionType,
                        PaymentStatus = item.PaymentStatus,
                        PaymentMethod = item.PaymentMethod,
                        VNPAYTransactionID=item.VNPAYTransactionID,
                        VNPAYTransactionStatus=item.VNPAYTransactionStatus,
                        VNPAYTransactionTime=item.VNPAYTransactionTime

                    };
                    listTransaction.Add(transactionResponse);
                }
                result.Result = listTransaction;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetTransactionById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid transactionId))
                {
                    result = BuildAppActionResultError(result, "Invalid Voucher ID format.");
                    result.IsSuccess = false;
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.TransactionID == transactionId ,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                if (pagedResult.Items.Count() == 0)
                {
                    result = BuildAppActionResultError(result, "Transaction not exist");
                    return result;
                }
                TransactionResponse transactionResponse = new TransactionResponse
                {
                    TransactionID = pagedResult.Items[0].TransactionID.ToString(),
                    OrderID = pagedResult.Items[0].OrderID.ToString(),
                    TransactionDate = pagedResult.Items[0].TransactionDate,
                    Amount = pagedResult.Items[0].Amount,
                    TransactionType = pagedResult.Items[0].TransactionType,
                    PaymentStatus = pagedResult.Items[0].PaymentStatus,
                    PaymentMethod = pagedResult.Items[0].PaymentMethod,
                    VNPAYTransactionID = pagedResult.Items[0].VNPAYTransactionID,
                    VNPAYTransactionStatus = pagedResult.Items[0].VNPAYTransactionStatus,
                    VNPAYTransactionTime = pagedResult.Items[0].VNPAYTransactionTime

                };
                result.Result = transactionResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetTransactionBySupplierId(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid supplierId))
                {
                    result = BuildAppActionResultError(result, "Invalid Supplier ID format.");
                    result.IsSuccess = false;
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.Order.SupplierID == supplierId,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                if (pagedResult.Items.Count() == 0)
                {
                    result = BuildAppActionResultError(result, "Supplier not exist");
                    return result;
                }
                List<TransactionResponse> listTransaction = new List<TransactionResponse>();
                foreach (var item in pagedResult.Items)
                {

                    TransactionResponse transactionResponse = new TransactionResponse
                    {
                        TransactionID = item.TransactionID.ToString(),
                        OrderID = item.OrderID.ToString(),
                        TransactionDate = item.TransactionDate,
                        Amount = item.Amount,
                        TransactionType = item.TransactionType,
                        PaymentStatus = item.PaymentStatus,
                        PaymentMethod = item.PaymentMethod,
                        VNPAYTransactionID = item.VNPAYTransactionID,
                        VNPAYTransactionStatus = item.VNPAYTransactionStatus,
                        VNPAYTransactionTime = item.VNPAYTransactionTime

                    };
                    listTransaction.Add(transactionResponse);
                }
                result.Result = listTransaction;
                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CreateSupplierOrMemberPayment(SupplierPaymentAgainDto supplierResponse, HttpContext context)
        {
            var result = new AppActionResult();

            try
            {
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                
                // Create payment URL
                var createPayment = await paymentGatewayService.CreateSupplierOrMemberPayment(supplierResponse, context);
                // Send order confirmation email
                await Task.Delay(100);
                await Task.Delay(100);
                result.Result = createPayment;

            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CreateSupplierPaymentPurchuse(string historyTransaction, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var historyTransactionExist = await _historyTransactionRepository.GetByExpression(p => p.HistoryTransactionId == Guid.Parse(historyTransaction));
                if (historyTransactionExist == null)
                {
                    result = BuildAppActionResultError(result, $"Không tìm thấy giao dịch với id {historyTransaction}");
                }
                else
                {
                   if( historyTransactionExist.Status == TransactionStatus.Unsuccess)
                    {
                        var payment = new SupplierPaymentAgainDto
                        {
                            AccountId = historyTransactionExist.AccountID.ToString(),
                            Amount = historyTransactionExist.Price,
                            OrderID = historyTransactionExist.HistoryTransactionId.ToString(),  
                        };
                        var createPayment = await paymentGatewayService!.CreateSupplierOrMemberPayment(payment, context);
                        result.Result = createPayment;

                    }
                    else
                    {
                        result.Messages.Add("Giao dịch này đã được thành công hoặc đã hủy");
                        result.IsSuccess = true;
                        return result;
                    }
                }
                 
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> CreateStaffRefundReturnDetail(StaffRefundDto response, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    a => a.OrderID == Guid.Parse(response.OrderID),
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                string id = pagedResult.Items[0].Id;
                var accountExist = await _accountRepository.GetAllDataByExpression(
                    a => a.Id == pagedResult.Items[0].Id,
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                if(accountExist.Items[0].AccountNumber == null || accountExist.Items[0].BankName == null || accountExist.Items[0].AccountHolder == null)
                {
                    await SendUpdateBankInformation(accountExist.Items[0]);
                }
                else
                {
                    StaffRefundMemberDto staffRefundMemberDto = new StaffRefundMemberDto
                    {
                        BankName = accountExist.Items[0].BankName,
                        AccountNumber = accountExist.Items[0].AccountNumber,
                        AccountHolder = accountExist.Items[0].AccountHolder,
                        OrderId = pagedResult.Items[0].OrderID.ToString(),
                        TotalAmount = pagedResult.Items[0].TotalAmount
                    };
                    pagedResult.Items[0].OrderStatus = OrderStatus.Refund;
                    _orderRepository.Update(pagedResult.Items[0]);
                    await _unitOfWork.SaveChangesAsync();
                    result.Result = staffRefundMemberDto;
                }

                await Task.Delay(100);
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }
            return result;
        }
        private async Task SendUpdateBankInformation(Account account)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            var emailMessage =
                $"Kính chào {account.LastName} {account.FirstName},<br /><br />" +
                "Quý khách vui lòng cập nhật thông tin tài khoản ngân hàng trên app Camera service platform.<br /><br />" +
                "Camera service platform sẽ lấy thông tin quý khách cung cấp để tiến hành hoàn tiền lại cho đơn hàng quý khách đã hủy. <br /><br />" +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Send the email asynchronously and wait for completion
            emailService.SendEmail(
               account.Email,
               SD.SubjectMail.UPDATE_BANK_INFORMATION,
               emailMessage
           );
        }

        private async Task SendUpdateBankInformation1(Account account)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            var emailMessage =
                $"Kính chào {account.LastName} {account.FirstName},<br /><br />" +
                "Quý khách vui lòng cập nhật thông tin tài khoản ngân hàng trên app Camera service platform. <br /><br />" +
                "Camera service platform sẽ lấy thông tin quý khách cung cấp để tiến hành hoàn trả lại tiền cọc cho đơn hàng đã thuê. <br /><br />" +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Send the email asynchronously and wait for completion
            emailService.SendEmail(
               account.Email,
               SD.SubjectMail.UPDATE_BANK_INFORMATION,
               emailMessage
           );
        }
        public async Task<AppActionResult> CreateStaffRefundPurchuse(string historyTransaction, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var historyTransactionExist = await _historyTransactionRepository.GetByExpression(p => p.HistoryTransactionId == Guid.Parse(historyTransaction));
                if (historyTransactionExist == null)
                {
                    result = BuildAppActionResultError(result, $"Không tìm thấy giao dịch với id {historyTransaction}");
                }
                else
                {
                    if (historyTransactionExist.Status == TransactionStatus.Unsuccess)
                    {
                        var staffRefundDto = new StaffRefundDto
                        {
                            StaffId = historyTransactionExist.StaffID.ToString(),
                            
                            OrderID = historyTransactionExist.HistoryTransactionId.ToString(),
                        };
                        var createPayment = await paymentGatewayService!.CreateStaffRefund(staffRefundDto, context);
                        result.Result = createPayment;

                    }
                    else
                    {
                        result.Messages.Add("Giao dịch này đã được thành công hoặc đã hủy");
                        result.IsSuccess = true;
                        return result;
                    }
                }

            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> CreateStaffRefundDeposit(StaffRefundDto response, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    a => a.OrderID == Guid.Parse(response.OrderID),
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                string id = pagedResult.Items[0].Id;
                var accountExist = await _accountRepository.GetAllDataByExpression(
                    a => a.Id == pagedResult.Items[0].Id,
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                if (accountExist.Items[0].AccountNumber == null || accountExist.Items[0].BankName == null || accountExist.Items[0].AccountHolder == null)
                {
                    await SendUpdateBankInformation1(accountExist.Items[0]);
                }
                else
                {
                    StaffRefundMemberDto staffRefundMemberDto = new StaffRefundMemberDto
                    {
                        BankName = accountExist.Items[0].BankName,
                        AccountNumber = accountExist.Items[0].AccountNumber,
                        AccountHolder = accountExist.Items[0].AccountHolder,
                        OrderId = pagedResult.Items[0].OrderID.ToString(),
                        TotalAmount = pagedResult.Items[0].Deposit
                    };
                    pagedResult.Items[0].OrderStatus = OrderStatus.Completed;
                    _orderRepository.Update(pagedResult.Items[0]);
                    await _unitOfWork.SaveChangesAsync();
                    result.Result = staffRefundMemberDto;
                }

                await Task.Delay(100);
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> CreateStaffRefundSupplier(StaffRefundDto response, HttpContext context)
        {
            var result = new AppActionResult();
            try
            {
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    a => a.OrderID == Guid.Parse(response.OrderID),
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                string id = pagedResult.Items[0].Id;
                var accountExist = await _accountRepository.GetAllDataByExpression(
                    a => a.Id == pagedResult.Items[0].Supplier.AccountID,
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                
                    StaffRefundMemberDto staffRefundMemberDto = new StaffRefundMemberDto
                    {
                        BankName = accountExist.Items[0].BankName,
                        AccountNumber = accountExist.Items[0].AccountNumber,
                        AccountHolder = accountExist.Items[0].AccountHolder,
                        OrderId = pagedResult.Items[0].OrderID.ToString(),
                        TotalAmount = pagedResult.Items[0].TotalAmount
                    };
                    
                    result.Result = staffRefundMemberDto;
                

                await Task.Delay(100);
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                throw new Exception("Order creation failed. Error: " + ex.Message);
            }
            return result;
        }
    }
}
