using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("productVoucher")]
    [ApiController]
    public class ProductVoucherController : ControllerBase
    {
        private readonly IProductVoucherService _productVoucherService;

        public ProductVoucherController(
        IProductVoucherService productVoucherService
        )
        {
            _productVoucherService = productVoucherService;
        }

        [HttpGet("get-all-product-voucher")]
        public async Task<AppActionResult> GetAllProductVoucher(int pageIndex = 1, int pageSize = 10)
        {
            return await _productVoucherService.GetAllProductVoucher(pageIndex, pageSize);
        }

        [HttpGet("get-product-voucher-by-id")]
        public async Task<AppActionResult> GetProductVoucherById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _productVoucherService.GetProductVoucherById(id, pageIndex, pageSize);
        }

        [HttpGet("get-product-voucher-by-product-id")]
        public async Task<AppActionResult> GetProductVoucherByProductId(string ProductId, int pageIndex = 1, int pageSize = 10)
        {
            return await _productVoucherService.GetProductVoucherByProductId(ProductId, pageIndex, pageSize);
        }

        [HttpGet("get-product-voucher-by-supplier-id")]
        public async Task<AppActionResult> GetProductVoucherBySupplierId(string SupplierId, int pageIndex, int pageSize)
        {
            return await _productVoucherService.GetProductVoucherBySupplierId(SupplierId, pageIndex, pageSize);
        }


        [HttpPost("create-product-voucher")]
        public async Task<AppActionResult> CreateProductVoucher(ProductVoucherResponseDto voucherResponse)
        {
            return await _productVoucherService.CreateProductVoucher(voucherResponse);
        }

        [HttpPut("update-product-voucher")]
        public async Task<AppActionResult> UpdateProductVoucher(ProductVoucherUpdateDto voucherResponse)
        {
            return await _productVoucherService.UpdateProductVoucher(voucherResponse);
        }

        [HttpDelete("delete-product-voucher")]
        public async Task<AppActionResult> DeleteProductVoucher(string voucherId)
        {
            return await _productVoucherService.DeleteProductVoucher(voucherId);
        }
    }
}
