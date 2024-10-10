using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
        ICategoryService categoryService
        )
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-all-category")]
        public async Task<AppActionResult> GetAllCategory(int pageIndex = 1, int pageSize = 10)
        {
            return await _categoryService.GetAllCategory(pageIndex, pageSize);
        }

        [HttpGet("get-category-by-id")]
        public async Task<AppActionResult> GetCategoryById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _categoryService.GetCategoryById(id, pageIndex, pageSize);
        }

        [HttpGet("get-category-by-name")]
        public async Task<AppActionResult> GetCategoryByName(string filter, int pageIndex = 1, int pageSize = 10)
        {
            return await _categoryService.GetCategoryByName(filter, pageIndex, pageSize);
        }

        [HttpPost("create-category")]
        public async Task<AppActionResult> CreateCategory(CategoryResponseDto productResponse)
        {
            return await _categoryService.CreateCategory(productResponse);
        }

        [HttpPut("update-category")]
        public async Task<AppActionResult> UpdateCategory(CategoryUpdateResponseDto categoryResponse)
        {
            return await _categoryService.UpdateCategory(categoryResponse);
        }

        [HttpDelete("delete-category")]
        public async Task<AppActionResult> DeleteCategory(string categoryId)
        {
            return await _categoryService.DeleteCategory(categoryId);
        }
    }
}
