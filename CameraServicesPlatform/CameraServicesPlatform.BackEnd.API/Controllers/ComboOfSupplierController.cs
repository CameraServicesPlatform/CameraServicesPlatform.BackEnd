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
        [HttpGet("get-all-combo")]
        public async Task<AppActionResult> GetAllComboOfSupplier(int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetAllComboOfSupplier(pageIndex, pageSize);
        }

        [HttpGet("get-combo-by-combo-id")]
        public async Task<AppActionResult> GetComboOfSupplierByComboId(string id, int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierByComboId(id, pageIndex, pageSize);
        }

        [HttpPost("create-combo")]
        public async Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto request)
        {
            return await _comboOfSupplierService.CreateComboOfSupplier(request, HttpContext);
        }
        

        [HttpPost("get-combo-expired")]
        public async Task<AppActionResult> GetComboOfSupplierExpired (int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierExpired(pageIndex, pageSize);
        }
        [HttpPost("get-combo-near-expired")]
        public async Task<AppActionResult> GetComboOfSupplierNearExpired(int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierNearExpired(pageIndex, pageSize);
        }

        

    }
}
