using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ProductService : GenericBackendService, IProductService
    {
        private readonly IMapper _mapper;
        private IRepository<Product> _repository;
        private IUnitOfWork _unitOfWork;

        public ProductService(
            IRepository<Product> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AppActionResult> GetAllProduct(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                // Đặt filter là null nếu không có điều kiện lọc
                Expression<Func<Product, bool>>? filter = null; // Thay Product bằng kiểu thực thể thực tế

                // Gọi hàm GetAllDataByExpression với các tham số đúng
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName, // Sắp xếp theo SupplierName
                    isAscending: true, // Thay đổi giá trị nếu bạn muốn sắp xếp giảm dần
                    includes: new Expression<Func<Product, object>>[]
                    {
                a => a.Supplier, // Bao gồm Supplier
                a => a.Category   // Bao gồm Category
                    }
                );

                // Gán kết quả vào result
                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductByName(string? productNameFilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                // Kiểm tra nếu productNameFilter là null hoặc rỗng, không áp dụng điều kiện lọc (lấy tất cả sản phẩm)
                Expression<Func<Product, bool>>? filter = null;

                if (!string.IsNullOrEmpty(productNameFilter))
                {
                    // Nếu productNameFilter có giá trị, áp dụng điều kiện lọc theo ProductName
                    filter = a => a.ProductName.Contains(productNameFilter);
                }

                // Gọi hàm GetAllDataByExpression với điều kiện filter (nếu có)
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter, // Áp dụng filter nếu có, null sẽ lấy tất cả sản phẩm
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName, // Sắp xếp theo SupplierName
                    isAscending: true, // Sắp xếp tăng dần
                    includes: new Expression<Func<Product, object>>[]
                    {
                a => a.Supplier, // Bao gồm Supplier
                a => a.Category  // Bao gồm Category
                    }
                );

                // Gán kết quả vào result
                result.Result = pagedResult;
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
