﻿using CameraServicesPlatform.BackEnd.Application.IService;
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

        [HttpGet("get-combo-of-supplier-by-combo-supplier-id")]
        public async Task<AppActionResult> GetComboOfSupplierByComboId(string comboSupplierId, int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierByComboId(comboSupplierId, pageIndex, pageSize);
        }

        [HttpPost("create-combo-of-supplier")]
        public async Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto request)
        {
            return await _comboOfSupplierService.CreateComboOfSupplier(request, HttpContext);
        }
        

        [HttpPost("get-combo-of-supplier-expired")]
        public async Task<AppActionResult> GetComboOfSupplierExpired (int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierExpired(pageIndex, pageSize);
        }
        [HttpPost("get-combo-near-expired")]
        public async Task<AppActionResult> GetComboOfSupplierNearExpired(int pageIndex = 1, int pageSize = 100)
        {
            return await _comboOfSupplierService.GetComboOfSupplierNearExpired(pageIndex, pageSize);
        }

        [HttpPut("update-combo-of-supplier")]
        public async Task<AppActionResult> UpdateComboOfSupplier(ComboOfSupplierUpdateDto comboResponse)
        {
            return await _comboOfSupplierService.UpdateComboOfSupplier(comboResponse);
        }

    }
}
