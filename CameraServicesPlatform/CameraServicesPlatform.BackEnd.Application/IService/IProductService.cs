using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IProductService
    {
        Task<AppActionResult> CreateProduct([FromForm] ProductResponseDto productResponse);
        Task<AppActionResult> DeleteProduct(string productId);
        Task<AppActionResult> GetAllProduct(int pageIndex, int pageSize);
        Task<AppActionResult> GetProductById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductByName([FromQuery] string? filter, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductByCategoryName([FromQuery] string? filter, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductByRent(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateProduct(ProductUpdateResponseDto productResponse);
        Task<AppActionResult> GetProductByCategoryId(string filter, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductBySupplierId(string filter, int pageIndex, int pageSize);
    }

}
