using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Category;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using Microsoft.AspNetCore.Mvc;


[Route("product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductImageService _productImageService;


    public ProductController(
    IProductImageService productImageService,
    IProductService productService
    )
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _productImageService = productImageService ?? throw new ArgumentNullException(nameof(productImageService));
    }

    [HttpGet("get-all-product")]
    public async Task<AppActionResult> GetAllProduct(int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetAllProduct(pageIndex, pageSize);
    }

    [HttpGet("get-product-by-id")]
    public async Task<AppActionResult> GetProductById( string id, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductById(id, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-rent")]
    public async Task<AppActionResult> GetProductByRent(int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByRent(pageIndex, pageSize);
    }

    [HttpGet("get-product-by-buy")]
    public async Task<AppActionResult> GetProductBySold(int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductBySold(pageIndex, pageSize);
    }

<<<<<<< HEAD
    [HttpGet("get-product-by-rent-sold")]
=======
    [HttpGet("get-product-available-both")]
>>>>>>> 900b683cb48585280d5df12311ed6d3e72b23b42
    public async Task<AppActionResult> GetProductAvaibleRentAndSell(int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductAvaibleRentAndSell(pageIndex, pageSize);
    }

    [HttpGet("get-product-by-name")]
    public async Task<AppActionResult> GetProductByName([FromQuery] string? filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByName(filter, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-supplierId")]
    public async Task<AppActionResult> GetProductBySupplierId(string filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductBySupplierId(filter, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-category-name")]
    public async Task<AppActionResult> GetProductByCategoryName([FromQuery] string? filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByCategoryName(filter, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-category-id")]
    public async Task<AppActionResult> GetProductByCategoryId(string filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByCategoryId(filter, pageIndex, pageSize);
    }

    
    [HttpPost("create-product-buy")]
    public async Task<AppActionResult> CreateProductBuy([FromForm] ProductResponseDto listProduct)
    {
          return await _productService.CreateProductBuy(listProduct);
      
    }

    [HttpPost("create-product-rent")]
    public async Task<AppActionResult> CreateProductRent([FromForm] ProductRequestRentDto listProduct)
    {
        return await _productService.CreateProductRent(listProduct);

    }

    [HttpPut("update-product")]
    public async Task<AppActionResult> UpdateProduct(ProductUpdateResponseDto productResponse)
    {
        return await _productService.UpdateProduct(productResponse);
    }

    [HttpDelete("delete-product")]
    public async Task<AppActionResult> DeleteProduct(string productId)
    {
        return await _productService.DeleteProduct(productId);
    }
}

