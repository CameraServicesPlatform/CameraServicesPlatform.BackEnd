using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(
        ISupplierService supplierService
        )
        {
            _supplierService = supplierService;
        }

        [HttpGet("get-all-supplier")]
        public async Task<AppActionResult> GetAllSupplier(int pageIndex = 1, int pageSize = 100)
        {
            return await _supplierService.GetAllSupplier(pageIndex, pageSize);
        }

        [HttpGet("get-supplier-by-id")]
        public async Task<AppActionResult> GetSupplierById(string id, int pageIndex = 1, int pageSize = 100)
        {
            return await _supplierService.GetSupplierById(id, pageIndex, pageSize);
        }

        [HttpGet("get-supplier-by-name")]
        public async Task<AppActionResult> GetSupplierByName([FromQuery]string? filter, int pageIndex = 1, int pageSize = 100)
        {
            return await _supplierService.GetSupplierByName(filter, pageIndex, pageSize);
        }


        [HttpPost("create-supplier")]
        public async Task<AppActionResult> CreateSupplier(SupplierResponseDto supplierResponse)
        {
            return await _supplierService.CreateSupplier(supplierResponse);
        }

        

        [HttpPut("update-supplier")]
        public async Task<AppActionResult> UpdateSupplier(UpdateSupplierRequestDTO supplierRequest)
        {
            return await _supplierService.UpdateSupplier(supplierRequest);
        }

        [HttpPut("block-supplier")]
        public async Task<AppActionResult> BlockSupplier(SupplierUpdateResponseDto supplierResponse)
        {
            return await _supplierService.BlockSupplier(supplierResponse);
        }

        [HttpDelete("delete-supplier")]
        public async Task<AppActionResult> DeleteSupplier(string supplierId)
        {
            return await _supplierService.DeleteSupplier(supplierId);
        }
    }
}
