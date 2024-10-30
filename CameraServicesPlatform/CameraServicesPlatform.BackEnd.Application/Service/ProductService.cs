using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Enum  ;
using CameraServicesPlatform.BackEnd.Domain.Enum.Account;
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
        private IRepository<Account> _accountRepository;
        private IRepository<RentalPrice> _rentalPriceRepository;
        private IRepository<ProductVoucher> _productVoucherRepository;
        private IRepository<Vourcher> _voucherRepository;
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
            IRepository<RentalPrice> rentalPriceRepository,
            IRepository<Vourcher> voucherRepository,
            IRepository<Account> accountRepository,
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
            _rentalPriceRepository = rentalPriceRepository;
            _orderDetailRepository = orderDetailRepository;
            _voucherRepository = voucherRepository;
            _accountRepository = accountRepository;
            _productVoucherRepository = productVoucherRepository;
            _productSpecificationRepository = productSpecificationRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

public async Task<AppActionResult> CreateProductBuy(ProductResponseDto productResponse)
{
    AppActionResult result = new AppActionResult();
    try
    {
        var listProduct = Resolve<IRepository<Product>>();

        // Validate SupplierID
        if (!Guid.TryParse(productResponse.SupplierID, out var supplierGuid))
        {
            result = BuildAppActionResultError(result, $"SupplierID không hợp lệ!");
            return result;
        }

        // Check if Supplier exists
        var supplierExist = await _supplierRepository.GetAllDataByExpression(
            a => a.SupplierID == supplierGuid,
            1,
            10,
            orderBy: a => a.SupplierName,
            isAscending: true,
            null
        );
        if (supplierExist == null || supplierExist.Items.Count == 0)
        {
            result = BuildAppActionResultError(result, $"SupplierID không tồn tại!");
            return result;
        }

        // Check if product name already exists for the supplier
        var productNameExist = await _productRepository.GetByExpression(
            a => a.ProductName.Equals(productResponse.ProductName) && a.SupplierID.Equals(supplierGuid),
            null
        );
        if (productNameExist != null)
        {
            result = BuildAppActionResultError(result, $"Tên sản phẩm đã tồn tại trong shop!");
            return result;
        }

        // Check if Serial Number already exists
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
            result = BuildAppActionResultError(result, $"Product serial number đã tồn tại, Product serial number không được trùng!");
            return result;
        }

        // Parse CategoryID and validate it
        if (!Guid.TryParse(productResponse.CategoryID, out var categoryGuid))
        {
            result = BuildAppActionResultError(result, $"CategoryID không hợp lệ!");
            return result;
        }

        // Create new Product
        Product product = new Product()
        {
            ProductID = Guid.NewGuid(),
            SerialNumber = productResponse.SerialNumber,
            SupplierID = supplierGuid,
            CategoryID = categoryGuid,
            ProductName = productResponse.ProductName,
            ProductDescription = productResponse.ProductDescription,
            PriceBuy = productResponse.PriceBuy,
            PriceRent = productResponse.PriceRent,
            Brand = productResponse.Brand,
            Status = productResponse.Status,
            Quality = "moi",  // You might want to replace this with a dynamic value.
            Rating = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Firebase Image Upload
        var firebaseService = Resolve<IFirebaseService>();
        if (productResponse.File != null)
        {
            var pathName = SD.FirebasePathName.PRODUCTS_PREFIX + $"{product.ProductID}_{Guid.NewGuid()}.jpg";
            var uploadResult = await firebaseService.UploadFileToFirebase(productResponse.File, pathName);
            
            if (!string.IsNullOrEmpty(uploadResult?.Result.ToString()))
            {
                var imgUrl = uploadResult.Result.ToString();

                // Save Product Image
                ProductImage productImage = new ProductImage
                {
                    ProductImagesID = Guid.NewGuid(),
                    ProductID = product.ProductID,
                    Image = imgUrl
                };
                await _productImageRepository.Insert(productImage);
            }
            else
            {
                result = BuildAppActionResultError(result, "Lỗi khi upload hình ảnh.");
                return result;
            }
        }

        await listProduct.Insert(product);

        if (productResponse.listProductSpecification != null && productResponse.listProductSpecification.Count > 0)
        {
             foreach (var spec in productResponse.listProductSpecification)
             {
                  int index = spec.IndexOf(':');
                  string specification = spec.Substring(0, index);
                  string detail = spec.Substring(index+1);
                  ProductSpecification productSpecification = new ProductSpecification
                  {
                      ProductSpecificationID = Guid.NewGuid(),
                      ProductID = product.ProductID,
                      Specification = specification,
                      Details = detail
                  };
                  await _productSpecificationRepository.Insert(productSpecification);
             }
        }

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

        public async Task<AppActionResult> CreateProductRent(ProductRequestRentDto productResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var listProduct = Resolve<IRepository<Product>>();

                // Validate SupplierID
                if (!Guid.TryParse(productResponse.SupplierID, out var supplierGuid))
                {
                    result = BuildAppActionResultError(result, $"SupplierID không hợp lệ!");
                    return result;
                }

                // Check if Supplier exists
                var supplierExist = await _supplierRepository.GetAllDataByExpression(
                    a => a.SupplierID == supplierGuid,
                    1,
                    10,
                    orderBy: a => a.SupplierName,
                    isAscending: true,
                    null
                );
                if (supplierExist == null || supplierExist.Items.Count == 0)
                {
                    result = BuildAppActionResultError(result, $"SupplierID không tồn tại!");
                    return result;
                }

                // Check if product name already exists for the supplier
                var productNameExist = await _productRepository.GetByExpression(
                    a => a.ProductName.Equals(productResponse.ProductName) && a.SupplierID.Equals(supplierGuid),
                    null
                );
                if (productNameExist != null)
                {
                    result = BuildAppActionResultError(result, $"Tên sản phẩm đã tồn tại trong shop!");
                    return result;
                }

                // Check if Serial Number already exists
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
                    result = BuildAppActionResultError(result, $"Product serial number đã tồn tại, Product serial number không được trùng!");
                    return result;
                }

                // Parse CategoryID and validate it
                if (!Guid.TryParse(productResponse.CategoryID, out var categoryGuid))
                {
                    result = BuildAppActionResultError(result, $"CategoryID không hợp lệ!");
                    return result;
                }

                // Create new Product
                Product product = new Product()
                {
                    ProductID = Guid.NewGuid(),
                    SerialNumber = productResponse.SerialNumber,
                    SupplierID = supplierGuid,
                    CategoryID = categoryGuid,
                    ProductName = productResponse.ProductName,
                    ProductDescription = productResponse.ProductDescription,
                    Brand = productResponse.Brand,
                    Status = ProductStatusEnum.AvailableRent,
                    Quality = productResponse.Quality,  // You might want to replace this with a dynamic value.
                    Rating = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                RentalPrice newRentalPrice = new RentalPrice
                {
                    RentalPriceID = Guid.NewGuid(),
                    ProductID = product.ProductID,
                    PricePerHour = productResponse.PricePerHour,
                    PricePerDay = productResponse.PricePerDay,
                    PricePerWeek = productResponse.PricePerWeek,
                    PricePerMonth = productResponse.PricePerMonth,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _rentalPriceRepository.Insert(newRentalPrice);
                // Firebase Image Upload
                var firebaseService = Resolve<IFirebaseService>();
                if (productResponse.File != null)
                {
                    var pathName = SD.FirebasePathName.PRODUCTS_PREFIX + $"{product.ProductID}_{Guid.NewGuid()}.jpg";
                    var uploadResult = await firebaseService.UploadFileToFirebase(productResponse.File, pathName);

                    if (!string.IsNullOrEmpty(uploadResult?.Result.ToString()))
                    {
                        var imgUrl = uploadResult.Result.ToString();

                        // Save Product Image
                        ProductImage productImage = new ProductImage
                        {
                            ProductImagesID = Guid.NewGuid(),
                            ProductID = product.ProductID,
                            Image = imgUrl
                        };
                        await _productImageRepository.Insert(productImage);
                    }
                    else
                    {
                        result = BuildAppActionResultError(result, "Lỗi khi upload hình ảnh.");
                        return result;
                    }
                }

                await listProduct.Insert(product);

                if (productResponse.listProductSpecification != null && productResponse.listProductSpecification.Count > 0)
                {
                    foreach (var spec in productResponse.listProductSpecification)
                    {
                        int index = spec.IndexOf(':');
                        string specification = spec.Substring(0, index);
                        string detail = spec.Substring(index + 1);
                        ProductSpecification productSpecification = new ProductSpecification
                        {
                            ProductSpecificationID = Guid.NewGuid(),
                            ProductID = product.ProductID,
                            Specification = specification,
                            Details = detail
                        };
                        await _productSpecificationRepository.Insert(productSpecification);
                    }
                }

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
                    null
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
                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    if (rentalPrice.Items.Count() > 0)
                    {
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
                            PricePerHour = rentalPrice.Items[0].PricePerHour,
                            PricePerDay = rentalPrice.Items[0].PricePerDay,
                            PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                            PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    else
                    {
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
                var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(productId),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                if( rentalPrice.Items.Count()>0 )
                {
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
                        PricePerHour = rentalPrice.Items[0].PricePerHour,
                        PricePerDay = rentalPrice.Items[0].PricePerDay,
                        PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                        PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                else
                {
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
                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    if (rentalPrice.Items.Count() > 0)
                    {
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
                            PricePerHour = rentalPrice.Items[0].PricePerHour,
                            PricePerDay = rentalPrice.Items[0].PricePerDay,
                            PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                            PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    else
                    {
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
                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    if (rentalPrice.Items.Count() > 0)
                    {
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
                            PricePerHour = rentalPrice.Items[0].PricePerHour,
                            PricePerDay = rentalPrice.Items[0].PricePerDay,
                            PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                            PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    else
                    {
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
                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    if (rentalPrice.Items.Count() > 0)
                    {
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
                            PricePerHour = rentalPrice.Items[0].PricePerHour,
                            PricePerDay = rentalPrice.Items[0].PricePerDay,
                            PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                            PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    else
                    {
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

                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    if (rentalPrice.Items.Count() > 0)
                    {
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
                            PricePerHour = rentalPrice.Items[0].PricePerHour,
                            PricePerDay = rentalPrice.Items[0].PricePerDay,
                            PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                            PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    else
                    {
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

                List<ProductResponseRent> listProduct = new List<ProductResponseRent>();
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
                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    ProductResponseRent productResponse = new ProductResponseRent
                    {
                        ProductID = item.ProductID.ToString(),
                        SerialNumber = item.SerialNumber,
                        SupplierID = item.SupplierID?.ToString(),
                        CategoryID = item.CategoryID?.ToString(),
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        PricePerHour = rentalPrice.Items[0].PricePerHour,
                        PricePerDay = rentalPrice.Items[0].PricePerDay,
                        PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                        PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
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
                        PricePerHour = rentalPrice.Items[0].PricePerHour,
                        PricePerDay = rentalPrice.Items[0].PricePerDay,
                        PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                        PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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

                    var rentalPrice = await _rentalPriceRepository.GetAllDataByExpression(
                        a => a.ProductID.Equals(item.ProductID),
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                    );
                    if (rentalPrice.Items.Count() > 0)
                    {
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
                            PricePerHour = rentalPrice.Items[0].PricePerHour,
                            PricePerDay = rentalPrice.Items[0].PricePerDay,
                            PricePerWeek = rentalPrice.Items[0].PricePerWeek,
                            PricePerMonth = rentalPrice.Items[0].PricePerMonth,
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
                    else
                    {
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

        public async Task<AppActionResult> UpdateProductRent(ProductUpdateRentDto productResponse)
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
                    a => a.ProductName.Equals(productResponse.ProductName) && (a.SupplierID == productExist.SupplierID) && (!a.ProductName.Equals(productExist.ProductName)),
                    1,
                    10,
                    orderBy: a => a.Supplier!.SupplierName,
                    isAscending: true,
                    null
                );

                if (productNameExist.Items.Count > 0)
                {
                    result = BuildAppActionResultError(result, $"Tên Sản phẩm đã tồn tại shop");
                    return result;

                }

                productExist.SerialNumber = productResponse.SerialNumber;
                productExist.CategoryID = Guid.Parse(productResponse.CategoryID);
                productExist.ProductName = productResponse.ProductName;
                productExist.ProductDescription = productResponse.ProductDescription;

                productExist.Brand = productResponse.Brand;
                productExist.Quality = productResponse.Quality;
                productExist.Status = productResponse.Status;
                productExist.UpdatedAt = DateTime.UtcNow;
                var rentalPriceExist = await _rentalPriceRepository.GetAllDataByExpression(
                    a => a.ProductID.Equals(productExist.ProductID),
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                rentalPriceExist.Items[0].PricePerHour = productResponse.PricePerHour;
                rentalPriceExist.Items[0].PricePerDay = productResponse.PricePerDay;
                rentalPriceExist.Items[0].PricePerWeek = productResponse.PricePerWeek;
                rentalPriceExist.Items[0].PricePerMonth = productResponse.PricePerMonth;
                await productRepository.Update(productExist);
                await _rentalPriceRepository.Update(rentalPriceExist.Items[0]);
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

        public async Task<AppActionResult> ProposalFollowVourcher(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();

            var vourcher = await _voucherRepository.GetAllDataByExpression(
                 v => v.IsActive && v.ValidFrom <= DateTime.Now && v.ExpirationDate >= DateTime.Now ,
                 1,
                 10,
                 orderBy: a => a.DiscountAmount,
                 isAscending: true,
                 null
             );
            List<ProductVoucher> listProVou = new List<ProductVoucher>();
            List<ProductResponse> listPro = new List<ProductResponse>();
            foreach (var item in vourcher.Items)
            {
                var productVour = await _productVoucherRepository.GetAllDataByExpression(
                 v => v.VourcherID.Equals(item.VourcherID) && v.IsDisable == true,
                 1,
                 10,
                 null,
                 isAscending: true,
                 null
                );
                foreach (var itemPro in productVour.Items)
                {
                    listProVou.Add(itemPro);
                }
            }
            for (int i= listProVou.Count-1; i >= 0; i--)
            {
                var product = await _productRepository.GetAllDataByExpression(
                 v => v.ProductID.Equals(listProVou[i].ProductID),
                 1,
                 10,
                 null,
                 isAscending: true,
                 null
                );
                foreach (var itemPro in product.Items)
                {
                    var listImage = await _productImageRepository.GetAllDataByExpression(
                        v => v.ProductID.Equals(itemPro.ProductID),
                        1,
                        10,
                        null,
                        isAscending: true,
                        null
                        );
                    ProductResponse productResponse = new ProductResponse
                    {
                        ProductID = itemPro.ProductID.ToString(),
                        SerialNumber = itemPro.SerialNumber,
                        SupplierID = itemPro.SupplierID?.ToString(),
                        CategoryID = itemPro.CategoryID?.ToString(),
                        ProductName = itemPro.ProductName,
                        ProductDescription = itemPro.ProductDescription,
                        PriceBuy = itemPro.PriceBuy,
                        PriceRent = itemPro.PriceRent,
                        Brand = itemPro.Brand,
                        Quality = itemPro.Quality,
                        Status = itemPro.Status,
                        Rating = itemPro.Rating,
                        CreatedAt = itemPro.CreatedAt,
                        UpdatedAt = itemPro.UpdatedAt,
                        listImage = listImage.Items
                    };
                    listPro.Add(productResponse);
                }
            }
            result.Result = listPro;
            result.IsSuccess = true;
            return result;
        }

        public async Task<AppActionResult> ProposalFollowJobBuy(string accountId, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            var accountExist = await _accountRepository.GetById(accountId);
            List<ProductResponse> listPro = new List<ProductResponse>();
            Expression<Func<Product, bool>> filter = null;
            
            switch (accountExist.Job)
            {
                case JobStatus.Student:
                    filter = a => a.PriceBuy <= 1000000;
                    break;

                case JobStatus.CasualUser:
                    filter = a => a.PriceBuy >= 1000000 && a.PriceBuy <= 3000000;
                    break;

                case JobStatus.Beginner:
                    filter = a => a.PriceBuy >= 1000000 && a.PriceBuy <= 2000000;
                    break;

                case JobStatus.ContentCreator:
                    filter = a => a.PriceBuy >= 6000000 && a.PriceBuy <= 10000000;
                    break;

                case JobStatus.TravelEnthusiast:
                    filter = a => a.PriceBuy >= 3000000 && a.PriceBuy <= 60000000;
                    break;

                default:
                    filter = a => a.PriceBuy >= 60000000; 
                    break;
            }
            var product = await _productRepository.GetAllDataByExpression(
                 filter,
                 1,
                 10,
                 null,
                 isAscending: true,
                 null
                );
            foreach (var item in product.Items)
            {
                var listImage = await _productImageRepository.GetAllDataByExpression(
                        v => v.ProductID.Equals(item.ProductID),
                        1,
                        10,
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
                    listImage = listImage.Items
                };
                listPro.Add(productResponse);
            }
            result.Result = listPro;
            result.IsSuccess = true;
            return result;
        }
    }

}

