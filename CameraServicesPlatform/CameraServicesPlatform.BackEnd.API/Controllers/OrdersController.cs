using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
 
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using Microsoft.AspNetCore.Http;
 
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("get-all-order")]
        public async Task<AppActionResult> GetAllOrder(int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetAllOrder(pageIndex, pageSize);
        }

        [HttpGet("get-order-by-order-type")]
        public async Task<AppActionResult> GetOrderByOrderType(OrderType type, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderByOrderType(type, pageIndex, pageSize);
        }

        [HttpGet("get-order-of-supplierId")]
        public async Task<AppActionResult> GetOrderByOfSupplier(string SupplierId, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderOfSupplier(SupplierId, pageIndex, pageSize);
        }

        [HttpGet("get-order-of-member")]
        public async Task<AppActionResult> GetOrderByMemberId(string MemberId, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderByMemberID(MemberId, pageIndex, pageSize);
        }

        [HttpPost("create-order-buy")]
        public async Task<IActionResult> CreateOrder(CreateOrderBuyRequest request)
        {
            try
            {
                var response = await _orderService.CreateOrderBuy(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-order-status-completed/{orderId}")]
        public async Task<AppActionResult> UpdateOrderStatusCompleted(string orderId)
        {
            return await _orderService.UpdateOrderStatus(orderId);
        }

        [HttpPut("cancel-order/{orderId}")]
        public async Task<AppActionResult> CancelOrder(string orderId)
        {
            return await _orderService.CancelOrder(orderId);
        }
    }
}
