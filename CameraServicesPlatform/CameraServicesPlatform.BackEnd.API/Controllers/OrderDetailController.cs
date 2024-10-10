using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("get-order-details/{orderId}")]
        public async Task<AppActionResult> GetOrderDetailsByOrderId(string orderId, int pageIndex, int pageSize)
        {
            return await _orderDetailService.GetOrderDetailsByOrderId(orderId, pageIndex, pageSize);
        }
    }
}
