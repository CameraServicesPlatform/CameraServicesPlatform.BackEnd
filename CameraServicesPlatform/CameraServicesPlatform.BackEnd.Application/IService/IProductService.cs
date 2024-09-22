using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IProductService
    {
        Task<AppActionResult> CreateProduct(ProductResponseDto productResponse);
        Task<AppActionResult> GetAllProduct(int pageIndex, int pageSize);
        Task<AppActionResult> GetProductById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetProductByName(string filter, int pageIndex, int pageSize);
    }
}
