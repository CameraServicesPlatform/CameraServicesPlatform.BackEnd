using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("voucher")]
    [ApiController]
    public class HistoryTransactionController : ControllerBase
    {
        private readonly IHistoryTransactionService _historyTransactionService;
        public HistoryTransactionController( IHistoryTransactionService historyTransactionService)
        {
            _historyTransactionService = historyTransactionService;
        }
        [HttpGet("get-all-history-transaction")]
        public async Task<AppActionResult> GetAllHistoryTransaction(int pageIndex = 1, int pageSize = 10)
        {
            return await _historyTransactionService.GetAllHistoryTransaction(pageIndex, pageSize);
        }
    }
}
