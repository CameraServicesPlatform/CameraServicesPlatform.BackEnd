using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IVoucherService
    {
     
        Task<AppActionResult> CreateVoucher(VoucherResponseDto voucherResponse);
        Task<AppActionResult> GetAllVoucher(int pageIndex, int pageSize);
        Task<AppActionResult> GetVoucherById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetVoucherBySupplierId(string supplierId, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateVoucher(VoucherUpdateResponseDto voucherResponse);
    }
}
