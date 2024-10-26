using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Domain.Models.CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        private IRepository<ProductVoucher> _productVoucherRepository;
        private IRepository<ProductSpecification> _productSpecificationRepository;
        private IRepository<Supplier> _supplierRepository;
        private IRepository<OrderDetail> _orderDetailRepository;
        private IRepository<Order> _orderRepository;
        private IUnitOfWork _unitOfWork;


        public ProductService(
            IRepository<Product> productRepository,
            IRepository<ProductImage> productImageRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Supplier> supplierRepository,
            IRepository<Order> orderRepository,
            IRepository<ProductVoucher> productVoucherRepository,
            IRepository<ProductSpecification> productSpecificationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _supplierRepository = supplierRepository;
            _orderDetailRepository = orderDetailRepository;
            _productVoucherRepository = productVoucherRepository;
            _productSpecificationRepository = productSpecificationRepository;
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
                if (!Guid.TryParse(productResponse.SupplierID, out var supplierGuid))
                {
                    result = BuildAppActionResultError(result, $"SupplierID không tồn tại!");
                    return result;
                }
                var supplierExist = await _supplierRepository.GetAllDataByExpression(
                    a => a.SupplierID == supplierGuid,
                    1,
                    10,
                    orderBy: a => a.SupplierName,
                    isAscending: true,
                    null
                );
                if (supplierExist == null)
                {
                    result = BuildAppActionResultError(result, $"SupplierID không tồn tại!");
                    return result;
                }
                var productNameExist = await _productRepository.GetByExpression(
                    a => a.ProductName.Equals(productResponse.ProductName)  && a.SupplierID.Equals(Guid.Parse(productResponse.SupplierID)),
                    null
                );
                if (productNameExist != null)
                {
                    result = BuildAppActionResultError(result, $"Tên sản phẩm đã tồn tại trong shop!");
                    return result;
                }

               
                var productSerialExist = await _productRepository.GetAllDataByExpression(
                    a => a.SerialNumber.Equals(productResponse.SerialNumber),
                    1,
                    10,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );
                if (productSerialExist.Items.Count > 0)
                {
                    result = BuildAppActionResultError(result, $"Product serial number đã tồn tại , Product serial number không được trùng!");
                    return result;
                }

                Product product = new Product()
                {
                    ProductID = Guid.NewGuid(),
                    SerialNumber = productResponse.SerialNumber,
                    SupplierID = Guid.Parse(productResponse.SupplierID),
                    CategoryID = Guid.Parse(productResponse.CategoryID),
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

                if (productResponse.File != null)
                {
                    var pathName = SD.FirebasePathName.PRODUCTS_PREFIX + $"{product.ProductID}{Guid.NewGuid()}.jpg";
                    var upload = await firebaseService.UploadFileToFirebase(productResponse.File, pathName);
                    var imgUrl = upload.Result.ToString();

                    ProductImage productImage = new ProductImage
                    {
                        ProductImagesID = Guid.NewGuid(),
                        ProductID = product.ProductID,
                        Image = imgUrl
                    };

                    await _productImageRepository.Insert(productImage);
                }

                await listProduct.Insert(product);
                await _unitOfWork.SaveChangesAsync();

                result.Result = productResponse;
                result.IsSuccess = true;
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

                Product productExist = await productRepository.GetById(Guid.Parse(productResponse.ProductID));

                if (productExist == null)
                {
                    result = BuildAppActionResultError(result, $"Sản phẩm không tồn tại!");
                    return result;
                }

                var productNameExist = await _productRepository.GetAllDataByExpression(
                    a => a.ProductName.Equals(productResponse.ProductName) && (a.SupplierID ==productExist.SupplierID) &&(!a.ProductName.Equals(productExist.ProductName)),
                    1,
                    10,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                if (productNameExist.Items.Count > 0 )
                {
                    result = BuildAppActionResultError(result, $"Tên Sản phẩm đã tồn tại shop");
                    return result;

                }

                productExist.SerialNumber = productResponse.SerialNumber;
                productExist.CategoryID = Guid.Parse(productResponse.CategoryID);
                productExist.ProductName = productResponse.ProductName;
                productExist.ProductDescription = productResponse.ProductDescription;
                if (productResponse.PriceBuy != null)
                {
                    productExist.PriceBuy = productResponse.PriceBuy;
                }
                if (productResponse.PriceRent != null)
                {
                    productExist.PriceRent = productResponse.PriceRent;
                }
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
                var pagedResult = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    includes: new Expression<Func<Product, object>>[]
                    {
                a => a.Supplier,
                a => a.Category
                    }
                );

                foreach (var item in pagedResult.Items)
                {
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductResponse productResponse = new ProductResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items
                    };
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

                var product = await _productRepository.GetById(productId);
                if (product == null)
                {
                    result = BuildAppActionResultError(result, "Product not found.");
                    return result;
                }

                var productImage = await _productImageRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(product.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(product.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                foreach (var item in productVoucher.Items)
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
                var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(product.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                foreach (var item in productSpecification.Items)
                {

                    ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                    {
                        ProductSpecificationID = item.ProductSpecificationID.ToString(),
                        Specification = item.Specification,
                        Details = item.Details
                    };
                    listProductSpecification.Add(productSpecificationResponse);
                }
                ProductByIdResponse productResponse = new ProductByIdResponse
                {
                    ProductID = product.ProductID.ToString(),
                    SerialNumber = product.SerialNumber,
                    SupplierID = product.SupplierID?.ToString(),
                    CategoryID = product.CategoryID?.ToString(),
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    PriceBuy = product.PriceBuy,
                    PriceRent = product.PriceRent,
                    Brand = product.Brand,
                    Quality = product.Quality,
                    Status = product.Status,
                    Rating = product.Rating,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    listImage = productImage.Items,
                    listVoucher = listProductVoucher,
                    listProductSpecification = listProductSpecification
                    
                };

                result.Result = productResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        
        public async Task<AppActionResult> GetProductByName([FromQuery]string? productNameFilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;

                if (!string.IsNullOrEmpty(productNameFilter))
                {
                    filter = a => a.ProductName.Contains(productNameFilter);
                }

                var pagedResult = await _productRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
                foreach (var item in pagedResult.Items)
                {
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(item.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {

                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {

                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification

                    };
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

        public async Task<AppActionResult> GetProductByCategoryName([FromQuery] string? categoryFilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;

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

                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
                foreach (var item in pagedResult.Items)
                {
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(item.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {

                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {

                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification

                    };
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
                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
                foreach (var item in pagedResult.Items)
                {
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(item.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {

                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {

                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification

                    };
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

                if (orderDetails.Items.Any())
                {

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

        public async Task<AppActionResult> GetProductBySupplierId(string filter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filterExpression = null;

                if (!string.IsNullOrEmpty(filter))
                {
                    if (Guid.TryParse(filter, out Guid supplierId))
                    {
                        filterExpression = a => a.SupplierID == supplierId;
                    }
                    else
                    {
                        result = BuildAppActionResultError(result, "Invalid supplier ID format.");
                        return result;
                    }
                }

                var pagedResult = await _productRepository.GetAllDataByExpression(
                    filterExpression,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );
                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
                foreach (var item in pagedResult.Items)
                {
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(item.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {

                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {

                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification

                    };
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

        public async Task<AppActionResult> GetProductByRent( int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = a => a.Status == ProductStatusEnum.Rented;

                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
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
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(item.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {

                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {

                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification

                    };
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

        public async Task<AppActionResult> GetProductBySold(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = a => a.Status == ProductStatusEnum.Sold;

                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
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
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(item.ProductID),
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {

                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {

                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification

                    };
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
        public async Task<AppActionResult> GetProductByRentSold(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                // Update the filter to include both AvailableSell and AvailableRent statuses
                Expression<Func<Product, bool>>? filter = a =>
                    a.Status == ProductStatusEnum.AvailableSell ||
                    a.Status == ProductStatusEnum.AvailableRent;

                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
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
                    // Fetch product vouchers
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {
                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    // Fetch product specifications
                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {
                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }

                    // Fetch product images
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification
                    };
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

        public async Task<AppActionResult> GetProductAvaibleRentAndSell(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                // Update the filter to include both AvailableSell and AvailableRent statuses
                Expression<Func<Product, bool>>? filter = a =>
                    a.Status == ProductStatusEnum.AvailableSell ||
                    a.Status == ProductStatusEnum.AvailableRent;

                List<ProductByIdResponse> listProduct = new List<ProductByIdResponse>();
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
                    // Fetch product vouchers
                    var productVoucher = await _productVoucherRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductVoucherResponse> listProductVoucher = new List<ProductVoucherResponse>();

                    foreach (var a in productVoucher.Items)
                    {
                        ProductVoucherResponse productVoucherResponse = new ProductVoucherResponse
                        {
                            ProductVoucherID = a.ProductVoucherID.ToString(),
                            VourcherID = a.VourcherID.ToString(),
                            CreatedAt = a.CreatedAt,
                            UpdatedAt = a.UpdatedAt,
                        };
                        listProductVoucher.Add(productVoucherResponse);
                    }

                    // Fetch product specifications
                    var productSpecification = await _productSpecificationRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    List<ProductSpecificationResponse> listProductSpecification = new List<ProductSpecificationResponse>();

                    foreach (var a in productSpecification.Items)
                    {
                        ProductSpecificationResponse productSpecificationResponse = new ProductSpecificationResponse
                        {
                            ProductSpecificationID = a.ProductSpecificationID.ToString(),
                            Specification = a.Specification,
                            Details = a.Details
                        };
                        listProductSpecification.Add(productSpecificationResponse);
                    }

                    // Fetch product images
                    var productImage = await _productImageRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductByIdResponse productResponse = new ProductByIdResponse
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PriceBuy = item.PriceBuy,
                        PriceRent = item.PriceRent,
                        Brand = item.Brand,
                        Quality = item.Quality,
                        Status = item.Status,
                        Rating = item.Rating,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        listImage = productImage.Items,
                        listVoucher = listProductVoucher,
                        listProductSpecification = listProductSpecification
                    };
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

    }

}

