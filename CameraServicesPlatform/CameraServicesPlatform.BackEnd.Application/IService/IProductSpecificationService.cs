using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IProductSpecificationService
    {
        Task<AppActionResult> CreateProductSpecification(ProductSpecificationResponseDto productSpecificationResponse);
        Task<AppActionResult> DeleteProductSpecification(string productSpecificationId);
        Task<AppActionResult> GetAllProductSpecification(int pageIndex, int pageSize);
        Task<AppActionResult> GetProductSpecificationById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateProductSpecification(ProductSpecificationUpdateDto productSpecificationResponse);
    }
}
