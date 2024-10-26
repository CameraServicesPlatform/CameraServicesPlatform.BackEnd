using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
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
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<Product> _productRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductReportService(
            IRepository<ProductReport> repository,
            IRepository<Supplier> supplierRepository,
             IRepository<Product> productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateProductReport(ProductReportResponseDto productReportResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                if (!Guid.TryParse(productReportResponse.SupplierID, out var supplierGuid))
                {
                    result.Result = "Invalid SupplierID format";
                    result.IsSuccess = false;
                    return result;
                }
                if (!Guid.TryParse(productReportResponse.ProductID, out var productGuid))
                {
                    result.Result = "Invalid ProductID format";
                    result.IsSuccess = false;
                    return result;
                }

                var supplierExist = await _supplierRepository.GetByExpression(a => a.SupplierID == supplierGuid);
                var productExist = await _productRepository.GetByExpression(a => a.ProductID == productGuid);

                if (supplierExist == null)
                {
                    result.Result = "SupplierID does not exist";
                    result.IsSuccess = false;
                    return result;
                }
                if (productExist == null)
                {
                    result.Result = "ProductID does not exist";
                    result.IsSuccess = false;
                    return result;
                }

                if (productReportResponse.StartDate > productReportResponse.EndDate)
                {
                    result.Result = "StartDate must be earlier than EndDate";
                    result.IsSuccess = false;
                    return result;
                }

                ProductReport productReport = new ProductReport()
                {
                    ProductReportID = Guid.NewGuid(),
                    SupplierID = supplierGuid,
                    ProductID = productGuid,
                    StatusType = productReportResponse.StatusType,
                    EndDate = productReportResponse.EndDate,
                    Reason = productReportResponse.Reason,
                    AccountID = productReportResponse.AccountID
                };

                var newProductReport = Resolve<IRepository<ProductReport>>();
                await newProductReport.Insert(productReport);
                await _unitOfWork.SaveChangesAsync();

                result.Result = "Create success";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
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
            var result = new AppActionResult();

            try
            {
                Expression<Func<ProductReport, bool>>? filter = null;
                List<ProductReportResponse> listProductReport = new List<ProductReportResponse>();
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                foreach (var item in pagedResult.Items)
                {

                    ProductReportResponse productReportResponse = new ProductReportResponse
                    {
                        ProductReportID = item.ProductReportID.ToString(),
                        SupplierID = item.SupplierID.ToString(),
                        ProductID = item.ProductID.ToString(),
                        StatusType = item.StatusType,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Reason = item.Reason,
                        AccountID = item.AccountID,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                    };
                    listProductReport.Add(productReportResponse);
                }

                result.Result = listProductReport;
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

                var productReportExist = await _repository.GetByExpression(
                    a => a.ProductReportID == productReportId,
                    null
                );
                ProductReportResponse productReportResponse = new ProductReportResponse
                {
                    ProductReportID = productReportExist.ProductReportID.ToString(),
                    SupplierID = productReportExist.SupplierID.ToString(),
                    ProductID = productReportExist.ProductID.ToString(),
                    StatusType = productReportExist.StatusType,
                    StartDate = productReportExist.StartDate,
                    EndDate = productReportExist.EndDate,
                    Reason = productReportExist.Reason,
                    AccountID = productReportExist.AccountID,
                    CreatedAt = productReportExist.CreatedAt,
                    UpdatedAt = productReportExist.UpdatedAt
                };
                result.Result = productReportResponse;
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
                    null
                );
                List<ProductReportResponse> listProductReport = new List<ProductReportResponse>();

                foreach (var item in pagedResult.Items)
                {

                    ProductReportResponse productReportResponse = new ProductReportResponse
                    {
                        ProductReportID = item.ProductReportID.ToString(),
                        SupplierID = item.SupplierID.ToString(),
                        ProductID = item.ProductID.ToString(),
                        StatusType = item.StatusType,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Reason = item.Reason,
                        AccountID = item.AccountID,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                    };
                    listProductReport.Add(productReportResponse);
                }
                result.Result = listProductReport;
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
                    result.Result = "Product report not exist";
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
