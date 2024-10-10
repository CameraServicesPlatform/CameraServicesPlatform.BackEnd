using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ContractService : GenericBackendService, IContractService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ContractService(
            IRepository<Contract> contractRepository,
            IRepository<ContractTemplate> contractTemplateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _contractTemplateRepository = contractTemplateRepository;
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateContract(CreateContractRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                var checkTemplate = await _contractTemplateRepository.GetById(request.ContractTemplateId);
                if (checkTemplate == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Hãy chọn mẫu hợp đồng!");
                    return result;
                }
                if (!Guid.TryParse(request.OrderID, out Guid NOrderID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var contract = new Contract
                {
                    OrderID = NOrderID,
                    ContractTerms = request.ContractTerms,
                    PenaltyPolicy = request.PenaltyPolicy,
                };

                await _contractRepository.Insert(contract);
                await _unitOfWork.SaveChangesAsync();

                var contractResponse = _mapper.Map<ContractResponse>(contract);
                contractResponse.ContractID = contract.ContractID.ToString();


                result.IsSuccess = true;
                result.Result = contractResponse;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> UpdateContract(string contractId, ContractRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(contractId, out Guid ContractId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingContract = await _contractRepository.GetById(ContractId);
                if (existingContract == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Hợp đồng không tồn tại!");
                    return result;
                }

                existingContract.ContractTerms = request.ContractTerms;
                existingContract.PenaltyPolicy = request.PenaltyPolicy;
                existingContract.UpdatedAt = DateTime.UtcNow; 

                await _contractRepository.Update(existingContract);
                await _unitOfWork.SaveChangesAsync();

                var contractResponse = _mapper.Map<ContractResponse>(existingContract);
                contractResponse.ContractID = existingContract.ContractID.ToString();


                result.IsSuccess = true;
                result.Result = contractResponse; 
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> DeleteContract(string contractId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(contractId, out Guid ContractId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var contract = await _contractRepository.GetById(ContractId);
                if (contract == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Hợp đồng không tồn tại!");
                    return result;
                }

                await _contractRepository.DeleteById(ContractId);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Hợp đồng đã được xóa!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetContractById(string contractId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(contractId, out Guid ContractId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var contract = await _contractRepository.GetById(ContractId);
                if (contract == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Hợp đồng không tồn tại!");
                    return result;
                }

                var contractResponse = _mapper.Map<ContractResponse>(contract);
                contractResponse.ContractID = contract.ContractID.ToString();

                result.IsSuccess = true;
                result.Result = contract; 
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllContracts(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                var contracts = await _contractRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var contractResponses = contracts.Items.Select(contract =>
                {
                    var contractResponse = _mapper.Map<ContractResponse>(contract);
                    contractResponse.ContractID = contract.ContractID.ToString();
                    return contractResponse;
                }).ToList();
                var pagedResult = new PagedResult<ContractResponse>
                {
                    Items = contractResponses
                };

                result.IsSuccess = true;
                result.Result = pagedResult;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
