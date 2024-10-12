using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Data;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ProductService : GenericBackendService, IProductService
    {
        private readonly IMapper _mapper;
        private IRepository<Product> _productRepository;
        private IRepository<ProductImage> _productImageRepository;
        private IRepository<ProductResponse> _productResponseRepository;

        private IRepository<OrderDetail> _orderDetailRepository;
        private IRepository<Order> _orderRepository;

        private IUnitOfWork _unitOfWork;


        public ProductService(
            IRepository<Product> productRepository,
            IRepository<ProductImage> productImageRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Order> orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<ProductResponse> productResponseRepository,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
            _productResponseRepository = productResponseRepository ?? throw new ArgumentNullException(nameof(productResponseRepository));

            _orderRepository = orderRepository; 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateProduct(ProductResponseDto productResponse)
        {
            AppActionResult result = new AppActionResult();
            try
               {
                var listProduct = Resolve<IRepository<Product>>();
                var productNameExist = await _productRepository.GetByExpression(
                    a => a.ProductName.Equals(productResponse.ProductName) && a.SupplierID.Equals(productResponse.SupplierID),
                    null
                );
                if(productNameExist != null )
                {
                    result.IsSuccess = false;
                    result.Result = "Name product existed into supplier";
                    return result;
                }

                var productSerialExist = await _productRepository.GetByExpression(
                    a => a.SerialNumber.Equals(productResponse.SerialNumber) && a.SupplierID.Equals(productResponse.SupplierID),
                    null
                );
                if (productNameExist != null)
                {
                    result.IsSuccess = false;
                    result.Result = "Product serial number existed into supplier, serial number cann't duplicate";
                    return result;
                }

                Product product = new Product()
                {
                    ProductID = Guid.NewGuid(),
                    SerialNumber = productResponse.SerialNumber,
                    SupplierID = Guid.Parse(productResponse.SupplierID),
                    CategoryID =  Guid.Parse(productResponse.CategoryID),
                    ProductName = productResponse.ProductName,
                    ProductDescription = productResponse.ProductDescription,
                    PriceBuy = productResponse.PriceBuy,
                    PriceRent = productResponse.PriceRent,
                    Brand = productResponse.Brand,
                    Quality = "moi",
                    Status = productResponse.Status,
                    Rating = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                var firebaseService = Resolve<IFirebaseService>();
                if(productResponse.File != null)
                {
                    var pathName = SD.FirebasePathName.SUPPLIER_PREFIX + $"{product.ProductID}{Guid.NewGuid()}.jpg";
                    var upload = await firebaseService!.UploadFileToFirebase(productResponse.File, pathName);
                    var Img = upload!.Result!.ToString()!;

                    await listProduct.Insert(product);
                    await _unitOfWork.SaveChangesAsync();

                    result.Result = productResponse;
                    result.IsSuccess = true;
                }
                else
                {
                    await listProduct.Insert(product);
                    await _unitOfWork.SaveChangesAsync();

                    result.Result = productResponse;
                    result.IsSuccess = true;
                }
                
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }



            return result;
        }

        public async Task<AppActionResult> UpdateProduct(ProductUpdateResponseDto productResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var productRepository = Resolve<IRepository<Product>>();

                Product productExist = await productRepository.GetById(productResponse.ProductID);

                if (productExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                var productNameExist = await _productRepository.GetByExpression(
                    a => a.ProductName.Equals(productResponse.ProductName) && a.SupplierID.Equals(productResponse.SupplierID),
                    null
                );
                if (productNameExist != null)
                {
                    result.IsSuccess = false;
                    result.Result = "Name product existed into supplier";
                    return result;
                }

                productExist.SerialNumber = productResponse.SerialNumber;
                productExist.SupplierID = Guid.Parse( productResponse.SupplierID);
                productExist.CategoryID =Guid.Parse( productResponse.CategoryID);
                productExist.ProductName = productResponse.ProductName;
                productExist.ProductDescription = productResponse.ProductDescription;
                productExist.PriceBuy = productResponse.PriceBuy;
                productExist.PriceRent = productResponse.PriceRent;
                productExist.Brand = productResponse.Brand;
                productExist.Quality = productResponse.Quality;
                productExist.Status = productResponse.Status;
                productExist.UpdatedAt = DateTime.Now;

                await productRepository.Update(productExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = productExist;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }


        public async Task<AppActionResult> GetAllProduct(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;
                List<ProductResponse> listProduct = new List<ProductResponse>();

                // Fetch paged result from repository
                var pagedResult = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier != null ? a.Supplier.SupplierName : string.Empty, // Handle null Supplier
                    isAscending: true,
                    null
                );

                foreach (var item in pagedResult.Items)
                {
                    if (item == null)
                    {
 
                        continue; 
                    }

                    var productImage = await _productImageRepository.GetByExpression(
                    a => a.ProductID == item.ProductID,
                    null
                    );
                    List<string> image = new List<string>();
                    if(productImage!= null)
                    {
                        image.Add(productImage.Image);
                    }

                    ProductResponse productResponse = NewProsuctResponse(item, image);
 

                    listProduct.Add(productResponse);
                }

                result.Result = listProduct;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

 
        public ProductResponse NewProsuctResponse(Product productExist, List<string> image )
        {
            ProductResponse productResponse = new ProductResponse
            {
                ProductID = productExist.ProductID.ToString(),
                SerialNumber = productExist.SerialNumber,
                SupplierID = productExist.SupplierID != null ? productExist.SupplierID.ToString() : null, // Handle null SupplierID
                CategoryID = productExist.CategoryID != null ? productExist.CategoryID.ToString() : null, // Handle null CategoryID
                ProductName = productExist.ProductName,
                ProductDescription = productExist.ProductDescription,
                PriceRent = productExist.PriceRent,
                PriceBuy = productExist.PriceBuy,
                Brand = productExist.Brand,
                Quality = productExist.Quality,
                Status = productExist.Status,
                Rating = productExist.Rating,
                CreatedAt = productExist.CreatedAt,
                UpdatedAt = productExist.UpdatedAt,
                Image = image

            };
            return productResponse;
        }
 
        public async Task<AppActionResult> GetProductById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid productId))
                {
                    result = BuildAppActionResultError(result, "Invalid product ID format.");
                    return result;
                }

                var productExist = await _productRepository.GetById(productId);
                if(productExist != null)
                {

                    ProductImage productImageExist = await _productImageRepository.GetByExpression(
                        a=> a.ProductID == productExist.ProductID,
                        null
                        );
                    List<string> image = new List<string>();
                    image.Add(productImageExist.Image.ToString());

                    ProductResponse productResponse = NewProsuctResponse(productExist, image);

                    result.Result = productResponse;
                    result.IsSuccess = true;
                }
                else
                {
                    result.Result = "Product not exist";
                    result.IsSuccess = false;
                }
                
                
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }


        public async Task<AppActionResult> GetProductByName(string? productNameFilter , int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = a => true;
                List<ProductResponse> listProduct = new List<ProductResponse>();

                if (!string.IsNullOrEmpty(productNameFilter))
                {
                    filter = a => a.ProductName.Contains(productNameFilter);
                }

                var listProductFilter = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                foreach (var item in listProductFilter.Items)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    var productImage = await _productImageRepository.GetByExpression(
                    a => a.ProductID == item.ProductID,
                    null
                    );
                    List<string> image = new List<string>();
                    if (productImage != null)
                    {
                        image.Add(productImage.Image);
                    }

                    ProductResponse productResponse = NewProsuctResponse(item, image);


                    listProduct.Add(productResponse);
                }
                result.Result = listProduct;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductBySupplierId(string? supplierId, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = a => true;
                List<ProductResponse> listProduct = new List<ProductResponse>();


                if (!string.IsNullOrEmpty(supplierId))
                {
                    filter = a => a.SupplierID == Guid.Parse(supplierId);
                }

                var listProductFilter = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                foreach (var item in listProductFilter.Items)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    var productImage = await _productImageRepository.GetByExpression(
                    a => a.ProductID == item.ProductID,
                    null
                    );
                    List<string> image = new List<string>();
                    if (productImage != null)
                    {
                        image.Add(productImage.Image);
                    }

                    ProductResponse productResponse = NewProsuctResponse(item, image);


                    listProduct.Add(productResponse);
                }
                result.Result = listProduct;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductByCategoryName(string? categoryFilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;
                List<ProductResponse> listProduct = new List<ProductResponse>();


                if (!string.IsNullOrEmpty(categoryFilter))
                {
                    filter = a => a.Category.CategoryName == categoryFilter;
                }

                var pagedResult = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                foreach (var item in pagedResult.Items)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    var productImage = await _productImageRepository.GetByExpression(
                    a => a.ProductID == item.ProductID,
                    null
                    );
                    List<string> image = new List<string>();
                    if (productImage != null)
                    {
                        image.Add(productImage.Image);
                    }

                    ProductResponse productResponse = NewProsuctResponse(item, image);

                    listProduct.Add(productResponse);
                }
                result.Result = listProduct;
                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetProductByCategoryId(string? categoryFilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;
                List<ProductResponse> listProduct = new List<ProductResponse>();

                Guid.TryParse(categoryFilter, out Guid categoryNameFilter);

                if (!string.IsNullOrEmpty(categoryFilter))
                {
                    filter = a => a.CategoryID == categoryNameFilter;
                }

                var pagedResult = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                foreach (var item in pagedResult.Items)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    var productImage = await _productImageRepository.GetByExpression(
                    a => a.ProductID == item.ProductID,
                    null
                    );
                    List<string> image = new List<string>();
                    if (productImage != null)
                    {
                        image.Add(productImage.Image);
                    }

                    ProductResponse productResponse = NewProsuctResponse(item, image);


                    listProduct.Add(productResponse);
                }
                result.Result = listProduct;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> DeleteProduct(string productId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(productId, out Guid id))
                {
                    result.IsSuccess = false;
                    result.Result = "Invalid product ID.";
                    return result;
                }

                var productRepository = Resolve<IRepository<Product>>();

                var orderDetails = await _orderDetailRepository.GetAllDataByExpression(
                    a => a.ProductID == id &&
                         (a.Order.OrderStatus == OrderStatus.Pending || a.Order.OrderStatus == OrderStatus.Approved),
                    1,
                    10,
                    null,
                    isAscending: true,
                    includes: new Expression<Func<OrderDetail, object>>[] { a => a.Order }
                );

                if (orderDetails.Items.Any()) { 
                
                    result.IsSuccess = false;
                    result.Result = "Product is part of a pending or approved order and cannot be deleted.";
                }
                 else
                {
                    var product = await _productRepository.GetById(id);
                    if (product != null)
                    {
                        product.Status = ProductStatusEnum.discontinuedProduct;

                        productRepository.Update(product); 
                        await _unitOfWork.SaveChangesAsync();

                        result.IsSuccess = true;
                        result.Result = "Product deleted successfully.";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Result = "Product not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

    }
}
