using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Migrations;
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Domain.Models.CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ProductReportService : GenericBackendService, IProductReportService
    {
        private readonly IRepository<ProductReport> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductReportService(
            IRepository<ProductReport> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateProductReport(ProductReportResponseDto productReportResponse)
        {
            throw new Exception();
        }

        public async Task<AppActionResult> DeleteProductReport(string productReportId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productReportRepository = Resolve<IRepository<Product>>();
                Guid.TryParse(productReportId, out Guid id);
                await productReportRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Product report deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllProductReport(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<ProductReport, bool>>? filter = null;

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    includes: new Expression<Func<ProductReport, object>>[]
                    {
                         a => a.Product,
                         a => a.Supplier                    }
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductReportById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid productReportId))
                {
                    result = BuildAppActionResultError(result, "Invalid product report ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.ProductReportID == productReportId,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    includes: new Expression<Func<ProductReport, object>>[]
                    {
                         a => a.Product,
                         a => a.Supplier
                    }
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductReportBySupplierId(string id, int pageIndex, int pageSize)
        {

            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid supllierId))
                {
                    result = BuildAppActionResultError(result, "Invalid supplier ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.SupplierID == supllierId,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    includes: new Expression<Func<ProductReport, object>>[]
                    {
                         a => a.Product,
                         a => a.Supplier
                    }
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateProductReport(ProductReportUpdateDto productReportResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productReportRepository = Resolve<IRepository<ProductReport>>();

                ProductReport productReportExist = await productReportRepository.GetById(productReportResponse.ProductReportID);

                if (productReportExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                productReportExist.StatusType = productReportResponse.StatusType;
                productReportExist.EndDate = productReportResponse.EndDate;
                productReportExist.Reason = productReportResponse.Reason;


                await productReportRepository.Update(productReportExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = productReportExist;
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
