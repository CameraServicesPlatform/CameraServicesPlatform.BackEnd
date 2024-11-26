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
    public class ComboOfSupplierService : GenericBackendService, IComboOfSupplierService
    {
        private readonly IMapper _mapper;
        private IRepository<ComboOfSupplier> _comboSupplierRepository;
        private IUnitOfWork _unitOfWork;


        public ComboOfSupplierService(
            IRepository<ComboOfSupplier> comboSupplierRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _comboSupplierRepository = comboSupplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto Response)
        {
            throw new NotImplementedException();
        }

        public async Task<AppActionResult> GetAllComboOfSupplier(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<ComboOfSupplier, bool>>? filter = a => a.IsDisable == true;
                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ComboOfSupplierResponse> listComboOfSupplier = new List<ComboOfSupplierResponse>();


                foreach (var item in pagedResult.Items)
                {

                    ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                    {
                        ComboId = item.ComboId.ToString(),
                        SupplierID = item.SupplierID.ToString(),
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        IsDisable = true

                    };
                    listComboOfSupplier.Add(comboResponse);
                }

                result.Result = listComboOfSupplier;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public Task<AppActionResult> GetComboOfSupplierById(string id, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AppActionResult> UpdateComboOfSupplier(ComboOfSupplierUpdateDto Response)
        {
            throw new NotImplementedException();
        }
    }
}
