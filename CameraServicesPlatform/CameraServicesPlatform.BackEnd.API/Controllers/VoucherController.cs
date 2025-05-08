using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("voucher")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(
        IVoucherService voucherService
        )
        {
            _voucherService = voucherService;
        }

        [HttpGet("get-all-voucher")]
        public async Task<AppActionResult> GetAllVoucher(int pageIndex = 1, int pageSize = 100)
        {
            return await _voucherService.GetAllVoucher(pageIndex, pageSize);
        }

        [HttpGet("get-voucher-by-id")]
        public async Task<AppActionResult> GetVoucherById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _voucherService.GetVoucherById(id, pageIndex, pageSize);
        }

        [HttpGet("get-voucher-by-supplier-id")]
        public async Task<AppActionResult> GetVoucherBySupplierId(string supplierId, int pageIndex = 1, int pageSize = 100)
        {
            return await _voucherService.GetVoucherBySupplierId(supplierId, pageIndex, pageSize);
        }


        [HttpPost("create-voucher")]
        public async Task<AppActionResult> CreateVoucher(VoucherResponseDto voucherResponse)
        {
            return await _voucherService.CreateVoucher(voucherResponse);
        }

        [HttpPut("update-voucher")]
        public async Task<AppActionResult> UpdateVoucher(VoucherUpdateResponseDto voucherResponse)
        {
            return await _voucherService.UpdateVoucher(voucherResponse);
        }

        
    }
}
