using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class PolicyService : GenericBackendService, IPolicyService
    {
        private readonly IRepository<Policy> _policyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PolicyService(
            IRepository<Policy> policyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _policyRepository = policyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreatePolicy(PolicyRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                
                var policy = _mapper.Map<Policy>(request);
                //policy.PolicyType = request.PolicyType;
                //policy.PolicyContent = request.PolicyContent;
                //policy.ApplicableObject = request.ApplicableObject;
                //policy.EffectiveDate = request.EffectiveDate;
                //policy.Value = request.Value;
                await _policyRepository.Insert(policy);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<PolicyResponse>(policy);

                result.IsSuccess = true;
                result.Result = policy;
               
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> DeletePolicy(string PolicyID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(PolicyID, out Guid DLPolicyID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var pl = await _policyRepository.GetById(DLPolicyID);
                if (pl == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Policy không tồn tại!");
                    return result;
                }

                await _policyRepository.DeleteById(DLPolicyID);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Policy đã được xóa!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllPolicy(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Policy, bool>>? filter = null;

                var Result = await _policyRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(PLC =>
                {
                    var response = _mapper.Map<PolicyResponse>(Result);
                    response.PolicyID = PLC.PolicyID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<PolicyResponse>
                {
                    Items = responses
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

        public async Task<AppActionResult> GetPolicyByApplicableObject(ApplicableObject type, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var Result = await _policyRepository.GetAllDataByExpression(
                    x => x.ApplicableObject == type,
                    pageIndex,
                    pageSize
                );

                var responses = Result.Items.Select(PLC =>
                {
                    var response = _mapper.Map<PolicyResponse>(Result);
                    response.PolicyID = PLC.PolicyID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<PolicyResponse>
                {
                    Items = responses
                };

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetPolicyById(string PolicyID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(PolicyID, out Guid GBPolicyID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var policyDetail = await _policyRepository.GetById(GBPolicyID);
                if (policyDetail == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy policy!");
                    return result;
                }

                var response = _mapper.Map<PolicyResponse>(policyDetail);
                response.PolicyID = policyDetail.PolicyID.ToString();

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdatePolicy(string PolicyID, PolicyRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(PolicyID, out Guid UDPolicyID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingPL = await _policyRepository.GetById(UDPolicyID);
                if (existingPL == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Policy không tồn tại!");
                    return result;
                }

                existingPL.PolicyType = request.PolicyType;
                existingPL.PolicyContent = request.PolicyContent;
                existingPL.ApplicableObject = request.ApplicableObject;
                existingPL.EffectiveDate = request.EffectiveDate;
                existingPL.Value = request.Value;
                await _policyRepository.Update(existingPL);
                await _unitOfWork.SaveChangesAsync();


                var response = _mapper.Map<PolicyResponse>(existingPL);
                response.PolicyID = existingPL.PolicyID.ToString();

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
