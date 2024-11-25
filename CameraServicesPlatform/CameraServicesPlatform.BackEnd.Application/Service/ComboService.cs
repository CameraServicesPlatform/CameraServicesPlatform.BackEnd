﻿using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static CameraServicesPlatform.BackEnd.Application.Service.OrderService;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ComboService : GenericBackendService, IComboService
    {
        private readonly IMapper _mapper;
        private IRepository<Combo> _comboRepository;
        private IUnitOfWork _unitOfWork;


        public ComboService(
            IRepository<Combo> comboRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _comboRepository = comboRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateCombo(ComboCreateDto comboResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var combo = Resolve<IRepository<Combo>>();
                
                var pagedResult = await _comboRepository.GetAllDataByExpression(
                    a => a.ComboName.Equals(comboResponse.ComboName),
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                if (pagedResult.Items.Count() > 0)
                {
                    result.Result = "Combo name existed, combo name cannot duplicate";
                    result.IsSuccess = false;
                    return result;

                }
                Combo comboNew = new Combo
                {
                    ComboId = Guid.NewGuid(),
                    ComboName = comboResponse.ComboName.ToString(),
                    ComboPrice = comboResponse.ComboPrice,
                    DurationCombo = comboResponse.DurationCombo,
                    IsDisable = true,
                    CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                    UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow)

                };

                await combo.Insert(comboNew);
                await _unitOfWork.SaveChangesAsync();

                result.Result = comboNew;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllCombo(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<Combo, bool>>? filter = a => a.IsDisable == true;
                var pagedResult = await _comboRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ComboResponseDto> listCombo = new List<ComboResponseDto>();


                foreach (var item in pagedResult.Items)
                {

                    ComboResponseDto comboResponse = new ComboResponseDto
                    {
                        ComboId = item.ComboId.ToString(),
                        ComboName = item.ComboName.ToString(),
                        ComboPrice = item.ComboPrice,
                        DurationCombo = item.DurationCombo,
                        IsDisable = item.IsDisable,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                        
                    };
                    listCombo.Add(comboResponse);
                }

                result.Result = listCombo;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetComboById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid comboId))
                {
                    result = BuildAppActionResultError(result, "Invalid Combo ID format.");
                    result.IsSuccess = false;
                    return result;
                }

                var pagedResult = await _comboRepository.GetAllDataByExpression(
                    a => a.ComboId == comboId && a.IsDisable == true,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                if (pagedResult.Items.Count() == 0)
                {
                    result = BuildAppActionResultError(result, "Combo not exist");
                    return result;
                }
                ComboResponseDto comboResponse = new ComboResponseDto
                {
                    ComboId = pagedResult.Items[0].ComboId.ToString(),
                    ComboName = pagedResult.Items[0].ComboName.ToString(),
                    ComboPrice = pagedResult.Items[0].ComboPrice,
                    DurationCombo = pagedResult.Items[0].DurationCombo,
                    IsDisable = pagedResult.Items[0].IsDisable,
                    CreatedAt = pagedResult.Items[0].CreatedAt,
                    UpdatedAt = pagedResult.Items[0].UpdatedAt

                };
                result.Result = comboResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public Task<AppActionResult> UpdateCombo(ComboUpdateResponseDto voucherResponse)
        {
            throw new NotImplementedException();
        }
    }
}
