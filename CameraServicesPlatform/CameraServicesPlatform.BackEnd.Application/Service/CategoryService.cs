using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using PdfSharp.Pdf.Filters;
using PdfSharp;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class CategoryService : GenericBackendService, ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IRepository<Product> _repositoryProduct;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoryService(
            IRepository<Category> categoryRepository,
            IRepository<Product> repositoryProduct,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = categoryRepository;
            _repositoryProduct = repositoryProduct;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateCategory(CategoryResponseDto categoryResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var listCategory = Resolve<IRepository<Category>>();
                var pagedResult = await _repository.GetByExpression(
                    null,
                    a => a.CategoryName == categoryResponse.CategoryName
                );
                if( pagedResult.CategoryID != null )
                {
                    result.IsSuccess = false;
                    result.Messages[0] = "Category name exist";
                    result = BuildAppActionResultError(result, result.Messages[0]);
                    return result;
                }
                Category category = new Category()
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = categoryResponse.CategoryName,
                    CategoryDescription = categoryResponse.CategoryDescription,
                    StatusCategory = true
                };

                await listCategory.Insert(category);
                await _unitOfWork.SaveChangesAsync();

                result.Result = category;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }



            return result;
        }

        public async Task<AppActionResult> GetAllCategory(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<Category, bool>>? filter = a => a.StatusCategory == true;
                List<CategoryDto> listCategory = new List<CategoryDto>();

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.CategoryName,
                    isAscending: true,
                    null
                );
                foreach (var item in pagedResult.Items)
                {

                    CategoryDto newCategory = new CategoryDto
                    {
                        CategoryID = item.CategoryID.ToString(),
                        CategoryName = item.CategoryName,
                        CategoryDescription = item.CategoryDescription,
                    };
                    listCategory.Add(newCategory);
                }
                result.Result = listCategory;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }


        public async Task<AppActionResult> GetCategoryById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Category, bool>>? filter = null;
                if (!Guid.TryParse(id, out Guid categoryId))
                {
                    result = BuildAppActionResultError(result, "Invalid product ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.CategoryID == categoryId && a.StatusCategory == true,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.CategoryName,
                    isAscending: true,
                    null
                );
                CategoryDto newCategory = new CategoryDto
                {
                    CategoryID = pagedResult.Items[0].CategoryID.ToString(),
                    CategoryName = pagedResult.Items[0].CategoryName,
                    CategoryDescription = pagedResult.Items[0].CategoryDescription,
                };
                result.Result = newCategory;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetCategoryByName(string categoryNameFilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Category, bool>>? filter = null;

                if (!string.IsNullOrEmpty(categoryNameFilter))
                {
                    filter = a => a.CategoryName.Contains(categoryNameFilter) && a.StatusCategory == true;
                }
                List<CategoryDto> listCategory = new List<CategoryDto>();

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.CategoryName,
                    isAscending: true,
                    null
                );
                foreach (var item in pagedResult.Items)
                {

                    CategoryDto newCategory = new CategoryDto
                    {
                        CategoryID = item.CategoryID.ToString(),
                        CategoryName = item.CategoryName,
                        CategoryDescription = item.CategoryDescription,
                    };
                    listCategory.Add(newCategory);
                }
                result.Result = listCategory;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateCategory(CategoryUpdateResponseDto categoryResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var categoryRepository = Resolve<IRepository<Category>>();

                Category categoryExist = await categoryRepository.GetById(categoryResponse.CategoryID);

                if (categoryExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                categoryExist.CategoryName = categoryResponse.CategoryName;
                categoryExist.CategoryDescription = categoryResponse.CategoryDescription;

                CategoryDto categoryUpdate = new CategoryDto
                {
                    CategoryID = categoryExist.CategoryID.ToString(),
                    CategoryName = categoryExist.CategoryName,
                    CategoryDescription = categoryExist.CategoryDescription,
                };

                await categoryRepository.Update(categoryExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = categoryUpdate;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> DeleteCategory(string categoryId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var categoryRepository = Resolve<IRepository<Category>>();
                Guid.TryParse(categoryId, out Guid id);
                Category categoryExist = await categoryRepository.GetById(id);
                var productExist = await _repositoryProduct.GetAllDataByExpression(
                    a => a.CategoryID == id,
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                if(productExist.Items.Count() > 0)
                {
                    categoryExist.StatusCategory = false;
                    await categoryRepository.Update(categoryExist);
                    await _unitOfWork.SaveChangesAsync();
                    result.Result = "Category deleted successfully.";
                    return result;
                }
                await categoryRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Category deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }        
    }
}
