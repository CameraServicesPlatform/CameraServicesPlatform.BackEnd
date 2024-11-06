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
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ProductVoucherService : GenericBackendService, IProductVoucherService
    {
        private readonly IRepository<ProductVoucher> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductVoucherService(
            IRepository<ProductVoucher> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<AppActionResult> GetAllProductVoucher(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<ProductVoucher, bool>>? filter = null;
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                foreach (var item in pagedResult.Items)
                {

                    ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                    {
                        ProductVoucherID = item.ProductVoucherID.ToString(),
                        VourcherID = item.VourcherID.ToString(),
                        ProductID = item.ProductID.ToString(),

                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                    };
                    listProductVoucher.Add(productVoucherResponse);
                }

                result.Result = listProductVoucher;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductVoucherById(string id, int pageIndex, int pageSize)
        {

            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid voucherId))
                {
                    result = BuildAppActionResultError(result, "Invalid Voucher ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.VourcherID == voucherId,
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

        public async Task<AppActionResult> GetProductVoucherByProductId(string ProductId, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ProductId, out Guid Id))
                {
                    result = BuildAppActionResultError(result, "Invalid Product Voucher ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.ProductID == Id,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                foreach (var item in pagedResult.Items)
                {

                    ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                    {
                        ProductVoucherID = item.ProductVoucherID.ToString(),
                         VourcherID = item.VourcherID.ToString(),
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                    };
                    listProductVoucher.Add(productVoucherResponse);
                }
                result.Result = listProductVoucher;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateProductVoucher(ProductVoucherUpdateDto productVoucherResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productVoucherRepository = Resolve<IRepository<ProductVoucher>>();

                ProductVoucher productVoucherExist = await productVoucherRepository.GetById(productVoucherResponse.ProductVoucherID);

                if (productVoucherExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                productVoucherExist.ProductID = productVoucherResponse.ProductID;
                productVoucherExist.VourcherID = productVoucherResponse.VourcherID;
                productVoucherExist.UpdatedAt = DateTime.UtcNow;

                await productVoucherRepository.Update(productVoucherExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = productVoucherExist;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> CreateProductVoucher(ProductVoucherResponseDto voucherResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var listProductVoucher = Resolve<IRepository<ProductVoucher>>();
                ProductVoucher productVoucher = new ProductVoucher()
                {
                    ProductVoucherID = Guid.NewGuid(),
                    ProductID = voucherResponse.ProductID,
                    VourcherID = voucherResponse.VourcherID
                };

                await listProductVoucher.Insert(productVoucher);
                await _unitOfWork.SaveChangesAsync();

                result.Result = productVoucher;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> DeleteProductVoucher(string productVoucherId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productVoucherRepository = Resolve<IRepository<ProductVoucher>>();
                Guid.TryParse(productVoucherId, out Guid id);
                await productVoucherRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Product Voucher deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

    }
}
