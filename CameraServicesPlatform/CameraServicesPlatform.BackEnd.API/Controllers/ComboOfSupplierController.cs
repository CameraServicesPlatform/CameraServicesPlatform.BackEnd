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
        public async Task<AppActionResult> GetAllComboOfSupplier(int pageIndex = 1, int pageSize = 10)
        {
            return await _comboOfSupplierService.GetAllComboOfSupplier(pageIndex, pageSize);
        }

        [HttpGet("get-combo-by-combo-id")]
        public async Task<AppActionResult> GetComboOfSupplierByComboId(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _comboOfSupplierService.GetComboOfSupplierByComboId(id, pageIndex, pageSize);
        }

        [HttpPost("create-combo")]
        public async Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto comboResponse)
        {
            return await _comboOfSupplierService.CreateComboOfSupplier(comboResponse, HttpContext);
        }
        

        [HttpPost("get-combo-expired")]
        public async Task<AppActionResult> GetComboOfSupplierExpired (ComboOfSupplierCreateDto comboResponse)
        {
            return await _comboOfSupplierService.CreateComboOfSupplier(comboResponse, HttpContext);
        }

        [HttpPut("update-combo")]
        public async Task<AppActionResult> UpdateComboOfSupplier(ComboOfSupplierUpdateDto comboResponse)
        {
            return await _comboOfSupplierService.UpdateComboOfSupplier(comboResponse);
        }

    }
}
