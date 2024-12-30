using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Transaction;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class HistoryTransactionService : GenericBackendService, IHistoryTransactionService
    {
        private readonly IRepository<HistoryTransaction> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HistoryTransactionService(
            IRepository<HistoryTransaction> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> GetAllHistoryTransaction(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<HistoryTransaction, bool>>? filter = a => a.Status == TransactionStatus.Success;
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<HistoryTransactionResponse> listHistoryTransaction = new List<HistoryTransactionResponse>();

                
                foreach (var item in pagedResult.Items)
                {
                    String staffId = null;
                    if(item.StaffID != null) staffId = item.StaffID.ToString();
                    HistoryTransactionResponse historyTransactionResponse = new HistoryTransactionResponse
                    {
                        HistoryTransactionId = item.HistoryTransactionId.ToString(),
                        AccountID = item.AccountID,
                        TransactionDescription = item.TransactionDescription,
                        StaffID = staffId,
                        Price = item.Price,
                        CreatedAt = item.CreatedAt
                    };
                    listHistoryTransaction.Add(historyTransactionResponse);
                }

                result.Result = listHistoryTransaction;
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
