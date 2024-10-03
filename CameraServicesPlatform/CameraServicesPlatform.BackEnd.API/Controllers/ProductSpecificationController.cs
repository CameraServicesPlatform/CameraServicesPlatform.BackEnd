using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("productSpecification")]
    [ApiController]
    public class ProductSpecificationController : ControllerBase
    {
        private readonly IProductSpecificationService _productSpecificationService;

        public ProductSpecificationController(
        IProductSpecificationService productSpecificationService
        )
        {
            _productSpecificationService = productSpecificationService;
        }

        [HttpGet("get-all-product-specification")]
        public async Task<AppActionResult> GetAllProductSpecification(int pageIndex = 1, int pageSize = 10)
        {
            return await _productSpecificationService.GetAllProductSpecification(pageIndex, pageSize);
        }

        [HttpGet("get-product-specification-by-id")]
        public async Task<AppActionResult> GetProductSpecificationById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _productSpecificationService.GetProductSpecificationById(id, pageIndex, pageSize);
        }


        [HttpPost("create-product-specification")]
        public async Task<AppActionResult> CreateProductSpecification(ProductSpecificationResponseDto productSpecificationResponse)
        {
            return await _productSpecificationService.CreateProductSpecification(productSpecificationResponse);
        }

        [HttpPost("update-product-specification")]
        public async Task<AppActionResult> UpdateProductSpecification(ProductSpecificationUpdateDto productSpecificationResponse)
        {
            return await _productSpecificationService.UpdateProductSpecification(productSpecificationResponse);
        }

        [HttpPost("delete-product-specification")]
        public async Task<AppActionResult> DeleteProductSpecification(string productSpecificationId)
        {
            return await _productSpecificationService.DeleteProductSpecification(productSpecificationId);
        }
    }
}
