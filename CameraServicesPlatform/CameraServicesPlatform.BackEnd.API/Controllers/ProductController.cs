using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;


[Route("product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
    IProductService productService
    )
    {
        _productService = productService;
    }

    [HttpGet("get-all-product")]
    public async Task<AppActionResult> GetAllProduct(int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetAllProduct(pageIndex, pageSize);
    }

    [HttpGet("get-product-by-id")]
    public async Task<AppActionResult> GetProductById(string id, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductById(id, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-name")]
    public async Task<AppActionResult> GetProductByName(string filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByName(filter, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-category-name")]
    public async Task<AppActionResult> GetProductByCategoryName(string filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByCategoryName(filter, pageIndex, pageSize);
    }

    [HttpGet("get-product-by-category-id")]
    public async Task<AppActionResult> GetProductByCategoryId(string filter, int pageIndex = 1, int pageSize = 10)
    {
        return await _productService.GetProductByCategoryId(filter, pageIndex, pageSize);
    }

    [HttpPost("create-product")]
    public async Task<AppActionResult> CreateProduct(ProductResponseDto productResponse)
    {
        return await _productService.CreateProduct(productResponse);
    }

    [HttpPost("update-product")]
    public async Task<AppActionResult> UpdateProduct(ProductUpdateResponseDto productResponse)
    {
        return await _productService.UpdateProduct(productResponse);
    }

    [HttpPost("delete-product")]
    public async Task<AppActionResult> DeleteProduct(string productId)
    {
        return await _productService.DeleteProduct(productId);
    }
}

