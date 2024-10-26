using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
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
    public class ProductSpecificationService : GenericBackendService, IProductSpecificationService
    {
        private readonly IMapper _mapper;
        private IRepository<ProductSpecification> _repository;
        private IUnitOfWork _unitOfWork;


        public ProductSpecificationService(
            IRepository<ProductSpecification> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateProductSpecification(ProductSpecificationResponseDto productSpecificationResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var listProductSpecification = Resolve<IRepository<ProductSpecification>>();
                ProductSpecification productSpecification = new ProductSpecification()
                {
                    ProductSpecificationID = Guid.NewGuid(),
                    ProductID = productSpecificationResponse.ProductID,
                    Specification = productSpecificationResponse.Specification,
                    Details = productSpecificationResponse.Details
            };

                await listProductSpecification.Insert(productSpecification);
                await _unitOfWork.SaveChangesAsync();

                result.Result = productSpecification;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> DeleteProductSpecification(string productSpecificationId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productSpecificationRepository = Resolve<IRepository<ProductSpecification>>();
                Guid.TryParse(productSpecificationId, out Guid id);
                await productSpecificationRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Product Specification deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllProductSpecification(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<ProductSpecification, bool>>? filter = null;

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    includes: new Expression<Func<ProductSpecification, object>>[]
                    {
                a => a.Product
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

        public async Task<AppActionResult> GetProductSpecificationById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid productSpecificationId))
                {
                    result = BuildAppActionResultError(result, "Invalid Product Specification ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.ProductSpecificationID == productSpecificationId,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    includes: new Expression<Func<ProductSpecification, object>>[]
                    {
                a => a.Product
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

        public async Task<AppActionResult> UpdateProductSpecification(ProductSpecificationUpdateDto productSpecificationResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productSpecificationRepository = Resolve<IRepository<ProductSpecification>>();

                ProductSpecification productSpecificationExist = await productSpecificationRepository.GetById(productSpecificationResponse.ProductSpecificationID);

                if (productSpecificationExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                productSpecificationExist.Specification = productSpecificationResponse.Specification;
                productSpecificationExist.Details = productSpecificationResponse.Details;

                await productSpecificationRepository.Update(productSpecificationExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = productSpecificationExist;
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
