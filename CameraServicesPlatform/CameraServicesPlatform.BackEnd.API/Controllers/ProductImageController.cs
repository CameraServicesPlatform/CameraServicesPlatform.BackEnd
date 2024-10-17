using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("productImage")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(
        IProductImageService productImageService
        )
        {
            _productImageService = productImageService ?? throw new ArgumentNullException(nameof(productImageService));
        }

        [HttpGet("get-all-product-image")]
        public async Task<AppActionResult> GetAllProductImage(int pageIndex = 1, int pageSize = 10)
        {
            return await _productImageService.GetAllProductImage(pageIndex, pageSize);
        }

        [HttpPost("create-product-image")]
        public async Task<AppActionResult> CreateProductImage(ProductImageResponseDto productImageResponse)
        {
            return await _productImageService.CreateProductImage(productImageResponse);
        }

        [HttpPut("update-product-image")]
        public async Task<AppActionResult> UpdateProductImage(ProductImageUpdateDto productImageResponse)
        {
            return await _productImageService.UpdateProductImage(productImageResponse);
        }

        [HttpDelete("delete-product-image")]
        public async Task<AppActionResult> DeleteProductImage(string productImageId)
        {
            return await _productImageService.DeleteProductImage(productImageId);
        }

    }
}
