using AutoMapper;
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

        public Task<AppActionResult> CreateCombo(ComboCreateDto voucherResponse)
        {
            throw new NotImplementedException();
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

        public Task<AppActionResult> GetComboById(string id, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AppActionResult> UpdateCombo(ComboUpdateResponseDto voucherResponse)
        {
            throw new NotImplementedException();
        }
    }
}
