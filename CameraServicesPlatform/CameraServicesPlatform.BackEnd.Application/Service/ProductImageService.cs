using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ProductImageService : GenericBackendService, IProductImageService
    {
        private readonly IMapper _mapper;
        private IRepository<ProductImage> _repository;

        private IUnitOfWork _unitOfWork;


        public ProductImageService(
            IRepository<ProductImage> repository,
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

        public async Task<AppActionResult> GetAllProductImage(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<ProductImage, bool>>? filter = null;

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
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

        public async Task<AppActionResult> UpdateProductImage(ProductImageUpdateDto productImageResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productImageRepository = Resolve<IRepository<ProductImage>>();

                ProductImage productImageExist = await productImageRepository.GetById(productImageResponse.ProductImagesID);

                if (productImageExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                productImageExist.Image = productImageResponse.Image;
                
                
                await productImageRepository.Update(productImageExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = productImageExist;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

            
        public async Task<AppActionResult> CreateProductImage(ProductImageResponseDto productImageResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var listProductImage = Resolve<IRepository<ProductImage>>();

                ProductImage productImage = new ProductImage()
                {
                    ProductImagesID = Guid.NewGuid(),
                    ProductID = productImageResponse.ProductID,
                    Image = productImageResponse.Image
                };

                await listProductImage.Insert(productImage);
                await _unitOfWork.SaveChangesAsync();

                result.Result = productImage;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> DeleteProductImage(string productImageId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productImageRepository = Resolve<IRepository<ProductImage>>();
                Guid.TryParse(productImageId, out Guid id);
                await productImageRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Product Image deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        
    }
}
