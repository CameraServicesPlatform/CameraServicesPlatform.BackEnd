using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("combo")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        private readonly IComboService _comboService;

        public ComboController(
        IComboService comboService
        )
        {
            _comboService = comboService;
        }
        [HttpGet("get-all-combo")]
        public async Task<AppActionResult> GetAllCombo(int pageIndex = 1, int pageSize = 100)
        {
            return await _comboService.GetAllCombo(pageIndex, pageSize);
        }

        [HttpGet("get-combo-by-id")]
        public async Task<AppActionResult> GetComboById(string id, int pageIndex = 1, int pageSize = 100)
        {
            return await _comboService.GetComboById(id, pageIndex, pageSize);
        }

       

        [HttpPost("create-combo")]
        public async Task<AppActionResult> CreateCombo(ComboCreateDto comboResponse)
        {
            return await _comboService.CreateCombo(comboResponse);
        }

        [HttpPut("update-combo")]
        public async Task<AppActionResult> UpdateCombo(ComboUpdateResponseDto comboResponse)
        {
            return await _comboService.UpdateCombo(comboResponse);
        }
        
    }
}
