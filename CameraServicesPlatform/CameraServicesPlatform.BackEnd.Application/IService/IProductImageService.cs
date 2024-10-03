using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IProductImageService
    {
        Task<AppActionResult> CreateProductImage(ProductImageResponseDto productImageResponse);
        Task<AppActionResult> DeleteProductImage(string productImageId);
        Task<AppActionResult> GetAllProductImage(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateProductImage(ProductImageUpdateDto productImageResponse);
    }
}
