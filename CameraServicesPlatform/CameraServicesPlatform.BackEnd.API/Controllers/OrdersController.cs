using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Packaging.Ionic.Zip;

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
    }
}
