using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class DeliveriesMethodService : GenericBackendService, IDeliveriesMethodService
    {
        private readonly IRepository<DeliveriesMethod> _deliveriesMethodRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeliveriesMethodService(
            IRepository<DeliveriesMethod> deliveriesMethodRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _deliveriesMethodRepository = deliveriesMethodRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateDeliveriesMethod(DeliveriesMethodRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AppActionResult> DeleteDeliveriesMethod(string deliveriesMethodId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppActionResult> GetAllDeliveriesMethod(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<DeliveriesMethod, bool>>? filter = null;
                List<DeliveriesMethodResponse> listDeliveriesMethod = new List<DeliveriesMethodResponse>();
                var pagedResult = await _deliveriesMethodRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                foreach (var item in pagedResult.Items)
                {

                    DeliveriesMethodResponse deliveriesMethodResponse = new DeliveriesMethodResponse
                    {
                        DeliveriesMethodID = item.DeliveriesMethodID.ToString(),
                        MethodName = item.MethodName,
                        Description = item.Description,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                    };
                    listDeliveriesMethod.Add(deliveriesMethodResponse);
                }

                result.Result = listDeliveriesMethod;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
    

        public async Task<AppActionResult> GetDeliveriesMethodById(string deliveriesMethodId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(deliveriesMethodId, out Guid Id))
                {
                    result = BuildAppActionResultError(result, "Invalid deliver method ID format.");
                    return result;
                }

                var pagedResult = await _deliveriesMethodRepository.GetAllDataByExpression(
                    a => a.DeliveriesMethodID == Id,
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                DeliveriesMethodResponse DeliveriesMethodResponse = new DeliveriesMethodResponse
                {
                    DeliveriesMethodID = pagedResult.Items[0].DeliveriesMethodID.ToString(),
                    MethodName = pagedResult.Items[0].MethodName,
                    Description = pagedResult.Items[0].Description,
                    CreatedAt = pagedResult.Items[0].CreatedAt,
                    UpdatedAt = pagedResult.Items[0].UpdatedAt
                };
                result.Result = DeliveriesMethodResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateDeliveriesMethod(string contractId, DeliveriesMethodRequest request)
        {
            throw new NotImplementedException();

        }
    }
}

