﻿using AutoMapper;
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
    public class ContractTemplateService : GenericBackendService, IContractTemplateService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ContractTemplateService(
            IRepository<ContractTemplate> contractTemplateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _contractTemplateRepository = contractTemplateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateContractTemplate(CreateContractTemplateRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
               
                var contractTemplate = new ContractTemplate
                {
                    MemberID = request.MemberID,
                    ContractTerms = request.ContractTerms,
                    TemplateName = request.TemplateName,
                    TemplateDetails = request.TemplateDetails,
                    PenaltyPolicy = request.PenaltyPolicy,
                };

                await _contractTemplateRepository.Insert(contractTemplate);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = contractTemplate;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> DeleteContractTemplate(string contractTemplateId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(contractTemplateId, out Guid ContractTemplateID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var ctl = await _contractTemplateRepository.GetById(ContractTemplateID);
                if (ctl == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Mẫu hợp đồng không tồn tại!");
                    return result;
                }

                await _contractTemplateRepository.DeleteById(ContractTemplateID);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Mẫu hợp đồng đã được xóa!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllContractTemplates(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                var ctl = await _contractTemplateRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                result.IsSuccess = true;
                result.Result = ctl;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetContractTemplateById(string contractTemplateId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(contractTemplateId, out Guid ContractTemplateID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var contract = await _contractTemplateRepository.GetById(ContractTemplateID);
                if (contract == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Mẫu hợp đồng không tồn tại!");
                    return result;
                }

                result.IsSuccess = true;
                result.Result = contract;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> UpdateContractTemplate(string contractTemplateId, CreateContractTemplateRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(contractTemplateId, out Guid ContractTemplateID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingContractTemplate = await _contractTemplateRepository.GetById(ContractTemplateID);
                if (existingContractTemplate == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Mẫu hợp đồng không tồn tại!");
                    return result;
                }

                existingContractTemplate.ContractTerms = request.ContractTerms;
                existingContractTemplate.PenaltyPolicy = request.PenaltyPolicy;
                existingContractTemplate.TemplateDetails = request.TemplateDetails;
                existingContractTemplate.TemplateName = request.TemplateName;
                existingContractTemplate.UpdatedAt = DateTime.UtcNow;

                await _contractTemplateRepository.Update(existingContractTemplate);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = existingContractTemplate;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
