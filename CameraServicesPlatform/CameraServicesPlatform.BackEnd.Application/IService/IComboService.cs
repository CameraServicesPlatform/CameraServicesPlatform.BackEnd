using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IComboService
    {
        Task<AppActionResult> CreateCombo(ComboCreateDto response);
        Task<AppActionResult> GetAllCombo(int pageIndex, int pageSize);
        Task<AppActionResult> GetComboById(string id, int pageIndex, int pageSize);
        Task<AppActionResult> UpdateCombo(ComboUpdateResponseDto response);
    }
}
