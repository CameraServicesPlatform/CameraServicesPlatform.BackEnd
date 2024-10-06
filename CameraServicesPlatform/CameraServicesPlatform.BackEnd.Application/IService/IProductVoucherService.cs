using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IProductVoucherService
    {
        Task<AppActionResult> CreateProductVoucher(ProductVoucherResponseDto voucherResponse);
        Task<AppActionResult> DeleteProductVoucher(string voucherId);
        Task<AppActionResult> GetAllProductVoucher(int pageIndex, int pageSize);
        Task<AppActionResult> GetProductVoucherById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductVoucherByProductId(string ProductId, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateProductVoucher(ProductVoucherUpdateDto voucherResponse);
    }
}
