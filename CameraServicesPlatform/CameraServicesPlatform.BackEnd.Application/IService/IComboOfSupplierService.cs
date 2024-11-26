using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IComboOfSupplierService
    {
        Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto Response);
        Task<AppActionResult> GetAllComboOfSupplier(int pageIndex, int pageSize);
        Task<AppActionResult> GetComboOfSupplierByComboId(string id, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateComboOfSupplier(ComboOfSupplierUpdateDto Response);
    }
}
