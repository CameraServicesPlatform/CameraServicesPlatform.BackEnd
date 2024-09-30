using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface ICategoryService
    {
        Task<AppActionResult> CreateCategory(CategoryResponseDto productResponse);
        Task<AppActionResult> GetAllCategory(int pageIndex, int pageSize);
        Task<AppActionResult> GetCategoryById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> GetCategoryByName(string filter, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateCategory(CategoryUpdateResponseDto productResponse);
        Task<AppActionResult> DeleteCategory(string productId);

    }
}
