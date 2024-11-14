using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    /*[Route("historyTransaction")]
    [ApiController]
    public class HistoryTransactionController : ControllerBase
    {
        private readonly IHistoryTransactionService _historyTransactionService;

        public HistoryTransactionController(
        IHistoryTransactionService historyTransactionService)
        {
            _historyTransactionService = historyTransactionService;
        }

        [HttpGet("get-all-supplier")]
        public async Task<AppActionResult> GetAllHistoryTransaction(int pageIndex = 1, int pageSize = 10)
        {
            return await _historyTransactionService.GetAllHistoryTransaction(pageIndex, pageSize);
        }

        [HttpGet("get-supplier-by-id")]
        public async Task<AppActionResult> GetHistoryTransactionById(string id, int pageIndex = 1, int pageSize = 10)
        {
            return await _historyTransactionService.GetHistoryTransactionById(id, pageIndex, pageSize);
        }

        
    }*/
}
