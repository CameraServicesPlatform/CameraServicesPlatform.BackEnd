using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("comboOfSupplier")]
    [ApiController]
    public class ComboOfSupplierController : ControllerBase
    {
        private readonly IComboOfSupplierService _comboOfSupplierService;

        public ComboOfSupplierController(
        IComboOfSupplierService comboOfSupplierService)
        {
            _comboOfSupplierService = comboOfSupplierService;
        }
        [HttpGet("get-all-combo-of-supplier")]
        public async Task<AppActionResult> GetAllComboOfSupplier(int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetAllComboOfSupplier(pageIndex, pageSize);
        }

        [HttpGet("get-combo-of-supplier-by-id")]
        public async Task<AppActionResult> GetComboOfSupplierById(string comboSupplierId, int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierById(comboSupplierId, pageIndex, pageSize);
        }

        [HttpGet("get-combo-of-supplier-by-supplier-id")]
        public async Task<AppActionResult> GetComboOfSupplierBySupplierId(string supplierId, int pageIndex , int pageSize)
        {
            return await _comboOfSupplierService.GetComboOfSupplierBySupplierId(supplierId, pageIndex, pageSize);
        }

        [HttpPost("create-combo-of-supplier")]
        public async Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto request)
        {
            return await _comboOfSupplierService.CreateComboOfSupplier(request, HttpContext);
        }
        

        [HttpGet("get-combo-of-supplier-expired")]
        public async Task<AppActionResult> GetComboOfSupplierExpired (int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierExpired(pageIndex, pageSize);
        }
        [HttpGet("get-combo-near-expired")]
        public async Task<AppActionResult> GetComboOfSupplierNearExpired(int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierNearExpired(pageIndex, pageSize);
        }


        [HttpGet("get-combo-by-supplier-id")]
        public async Task<AppActionResult> GetComboBySupplierId(string supplierId)
        {
            return await _comboOfSupplierService.GetComboBySupplierId(supplierId);
        }

    }
}
