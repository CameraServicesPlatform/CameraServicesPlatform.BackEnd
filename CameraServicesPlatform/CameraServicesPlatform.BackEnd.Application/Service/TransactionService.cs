using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
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
            //List<string> roleListDb = await _accountService.GetRoleListByAccountId(account);

            // Call the newly defined method
            /*List<string> roleNameList = await _accountService.GetRoleNameListById(roleListDb);

            if (roleNameList.Contains("ADMIN"))
            {
                _tokenDto.MainRole = "ADMIN";
            }
            else
            {
                _tokenDto.MainRole = roleNameList.Contains("STAFF")
                    ? "STAFF"
                    : roleNameList.Count > 0 ? roleNameList.FirstOrDefault(n => !n.Equals("MEMBER")) : "MEMBER";
            }*/
           
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
    
    }
}
