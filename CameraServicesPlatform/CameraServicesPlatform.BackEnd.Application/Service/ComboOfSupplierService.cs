using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using PdfSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static CameraServicesPlatform.BackEnd.Application.Service.OrderService;

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

        public async Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto Response)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var comboOfSupplier = Resolve<IRepository<ComboOfSupplier>>();
                if(Response.StartTime < DateTime.UtcNow)
                {
                    result = BuildAppActionResultError(result, "Start time must be larger than now");
                    result.IsSuccess = false;
                    return result;
                }
                var check = await _comboSupplierRepository.GetAllDataByExpression(
                    a => a.ComboId == Guid.Parse(Response.ComboId) && a.IsDisable == true && a.SupplierID == Guid.Parse(Response.SupplierID),
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                if (check.Items.Count() > 0)
                {
                    if (Response.StartTime < DateTime.UtcNow)
                    {
                        result = BuildAppActionResultError(result, "Combo of supplier has not expired yet so a new combo cannot be purchased");
                        result.IsSuccess = false;
                        return result;
                    }
                }
                ComboOfSupplier comboNew = new ComboOfSupplier
                {
                    ComboId = Guid.Parse(Response.ComboId),
                    SupplierID = Guid.Parse(Response.SupplierID),
                    IsDisable = true,
                    StartTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                    EndTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow)

                };

                await comboOfSupplier.Insert(comboNew);
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

        public async Task<AppActionResult> GetComboOfSupplierByComboId(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid comboSupplierId))
                {
                    result = BuildAppActionResultError(result, "Invalid Combo Supplier ID format.");
                    result.IsSuccess = false;
                    return result;
                }

                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    a => a.ComboId == comboSupplierId && a.IsDisable == true,
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
                ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                {
                    ComboId = pagedResult.Items[0].ComboId.ToString(),
                    SupplierID = pagedResult.Items[0].SupplierID.ToString(),
                    StartTime = pagedResult.Items[0].StartTime,
                    EndTime = pagedResult.Items[0].EndTime,
                    IsDisable = pagedResult.Items[0].IsDisable

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

        public Task<AppActionResult> UpdateComboOfSupplier(ComboOfSupplierUpdateDto Response)
        {
            throw new NotImplementedException();
        }
    }
}
