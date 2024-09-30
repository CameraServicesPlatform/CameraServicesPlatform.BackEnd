using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class CategoryService : GenericBackendService, ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoryService(
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateCategory(CategoryResponseDto categoryResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var listCategory = Resolve<IRepository<Category>>();

                Category category = new Category()
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = categoryResponse.CategoryName,
                    CategoryDescription = categoryResponse.CategoryDescription
                    
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
                // Expression filter is initialized as null, meaning no filtering will occur.
                Expression<Func<Category, bool>>? filter = null;

                // Fetch paged results using the filter (if any), ordering, and includes (empty in this case)
                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.CategoryName,
                    isAscending: true,
                    null
                );

                // Set success result
                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions and return the error result
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
                    a => a.CategoryID == categoryId,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.CategoryName,
                    isAscending: true,
                    null
                );

                result.Result = pagedResult;
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
                    filter = a => a.CategoryName.Contains(categoryNameFilter);
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.CategoryName,
                    isAscending: true,
                    null
                );

                result.Result = pagedResult;
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

                await categoryRepository.Update(categoryExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = categoryExist;
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
