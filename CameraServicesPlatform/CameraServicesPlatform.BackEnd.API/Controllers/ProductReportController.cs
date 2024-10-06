using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("productReport")]
    [ApiController]
    public class ProductReportController : ControllerBase
    {
        private readonly IProductReportService _productReportService;

        public ProductReportController(
        IProductReportService productReportService
        )
        {
            _productReportService = productReportService;
        }

        [HttpGet("get-all-product-report")]
        public async Task<AppActionResult> GetAllProductReport(int pageIndex = 1, int pageSize = 10)
        {
            return await _productReportService.GetAllProductReport(pageIndex, pageSize);
        }

        [HttpGet("get-product-report-by-id")]
        public async Task<AppActionResult> GetProductReportById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _productReportService.GetProductReportById(id, pageIndex, pageSize);
        }

        [HttpGet("get-product-report-by-supplierId")]
        public async Task<AppActionResult> GetProductReportBySupplierId(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _productReportService.GetProductReportBySupplierId(id, pageIndex, pageSize);
        }


        [HttpPost("create-product-report")]
        public async Task<AppActionResult> CreateProductReport(ProductReportResponseDto productReportResponse)
        {
            return await _productReportService.CreateProductReport(productReportResponse);
        }

        [HttpPut("update-product-report")]
        public async Task<AppActionResult> UpdateProductReport(ProductReportUpdateDto productReportResponse)
        {
            return await _productReportService.UpdateProductReport(productReportResponse);
        }

        [HttpDelete("delete-product-report")]
        public async Task<AppActionResult> DeleteProductReport(string productReportId)
        {
            return await _productReportService.DeleteProductReport(productReportId);
        }
    }
}

