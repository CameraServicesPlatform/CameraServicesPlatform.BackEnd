using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Enum.Payment;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class TransactionService : GenericBackendService, ITransactionService
    {
        private readonly IRepository<Transaction> _repository;
        IRepository<Account> _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(
            IRepository<Transaction> repository,
            IUnitOfWork unitOfWork,
            IRepository<Account> accountRepository,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<AppActionResult> CreateTransaction(VNPayResponseDto response, double amount, string account)
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

                        
        }

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
    }
}
