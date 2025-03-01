﻿using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
 
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
 
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("order")]
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
        [HttpGet("get-all-order-rent")]
        public async Task<AppActionResult> GetAllOrderRent(int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetAllOrderRent(pageIndex, pageSize);
        }
        [HttpGet("get-all-order-buy")]
        public async Task<AppActionResult> GetAllOrderBuy(int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetAllOrderBuy(pageIndex, pageSize);
        }

        [HttpGet("get-order-by-order-type")]
        public async Task<AppActionResult> GetOrderByOrderType(OrderType type, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderByOrderType(type, pageIndex, pageSize);
        }

        [HttpGet("get-order-by-order-status")]
        public async Task<AppActionResult> GetOrderByOrderStatus(OrderStatus orderStatus, int pageIndex, int pageSize)
        {
            return await _orderService.GetOrderByOrderStatus(orderStatus, pageIndex, pageSize);
        }

        [HttpGet("get-order-of-supplierId")]
        public async Task<AppActionResult> GetOrderByOfSupplier(string SupplierId, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderOfSupplier(SupplierId, pageIndex, pageSize);
        }
        [HttpGet("get-order-status-of-supplierId")]
        public async Task<AppActionResult> GetOrderStatusByOfSupplier(string SupplierId, OrderStatus orderStatus, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderStatusOfSupplier(SupplierId, orderStatus, pageIndex, pageSize);
        }
        [HttpGet("get-count-of-product-rent")]
        public async Task<AppActionResult> CountProductRentals(string productId, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.CountProductRentals(productId, pageIndex, pageSize);
        }

        [HttpGet("get-order-by-order-id")]
        public async Task<AppActionResult> GetOrderByOrderID(string orderID)
        {
            return await _orderService.GetOrderByOrderID(orderID);
        }
        [HttpGet("get-image-product-after-by-order-id")]
        public async Task<AppActionResult> GetImageProductAfter(string orderID)
        {
            return await _orderService.GetImageProductAfter(orderID);
        }
        [HttpGet("get-image-product-before-by-order-id")]
        public async Task<AppActionResult> GetImageProductBefore(string orderID)
        {
            return await _orderService.GetImageProductBefore(orderID);
        }
        [HttpGet("get-order-of-account")]
        public async Task<AppActionResult> GetOrderByAccountID(string AccountID, int pageIndex = 1, int pageSize = 10)
        {
            return await _orderService.GetOrderByAccountID(AccountID, pageIndex, pageSize);
        }

        [HttpGet("get-order-of-account-by-order-id")]
        public async Task<AppActionResult> GetOrderOfAccountByOrderID(string OrderId, int pageIndex, int pageSize)
        {
            return await _orderService.GetOrderOfAccountByOrderID(OrderId, pageIndex, pageSize);
        }

        [HttpGet("get-order-order-status-of-account")]
        public async Task<AppActionResult> GetOrderOrderStatusByAccountID(string AccountID, OrderStatus orderStatus, int pageIndex, int pageSize)
        {
            return await _orderService.GetOrderOrderStatusByAccountID(AccountID, orderStatus, pageIndex, pageSize);
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

        [HttpPost("create-order-buy-with-payment")]
        public async Task<IActionResult> CreateOrderWithPayment(CreateOrderBuyRequest request)
        {
            try
            {
                var response = await _orderService.CreateOrderWithPayment(request, HttpContext);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-img-product-after")]
        public async Task<IActionResult> AddImageProductAfter(ImageProductAfterDTO request)
        {
            try
            {
                var response = await _orderService.AddImageProductAfter(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-img-product-before")]
        public async Task<IActionResult> AddImageProductBefore(ImageProductBeforeDTO request)
        {
            try
            {
                var response = await _orderService.AddImageProductBefore(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-order-rent-with-payment")]
        public async Task<IActionResult> CreateOrderRentWithPayment(CreateOrderRentRequest request)
        {
            try
            {
                var response = await _orderService.CreateOrderRentWithPayment(request, HttpContext);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-order-rent")]
        public async Task<IActionResult> CreateOrderRent(CreateOrderRentRequest request)
        {
            try
            {
                var response = await _orderService.CreateOrderRent(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("purchase-order/{orderId}")]
        public async Task<AppActionResult> PurchaseOrder(string orderId)
        {
            return await _orderService.PurchaseOrder(orderId, HttpContext);
        }

        [HttpPut("update-order-status-completed/{orderId}")]
        public async Task<AppActionResult> UpdateOrderStatusCompletedBySupplier(string orderId)
        {
            return await _orderService.UpdateOrderStatusCompletedBySupplier(orderId);
        }

        [HttpPut("update-order-status-Shipped/{orderId}")]
        public async Task<AppActionResult> UpdateOrderStatusShippedBySupplier(string orderId)
        {
            return await _orderService.UpdateOrderStatusShippedBySupplier(orderId);
        }

        [HttpPut("update-order-status-Approved/{orderId}")]
        public async Task<AppActionResult> UpdateOrderStatusApprovedBySupplier(string orderId)
        {
            return await _orderService.UpdateOrderStatusApprovedBySupplier(orderId);
        }

        [HttpPut("update-order-status-placed/{orderId}")]
        public async Task<AppActionResult> UpdateOrderStatusPlaced(string orderId)
        {
            return await _orderService.UpdateOrderStatusPlaced(orderId);
        }

        [HttpPut("update-order-status-pending-refund/{orderId}")]
        public async Task<AppActionResult> UpdateOrderPendingRefund(string orderId)
        {
            return await _orderService.UpdateOrderPendingRefund(orderId);
        }

        [HttpPut("update-order-status-refund/{orderId}")]
        public async Task<AppActionResult> UpdateOrderRefund(string orderId)
        {
            return await _orderService.UpdateOrderRefund(orderId);
        }

        [HttpPut("update-order-status-deposit-refund/{orderId}")]
        public async Task<AppActionResult> UpdateOrderDepositReturn(string orderId)
        {
            return await _orderService.UpdateOrderDepositReturn(orderId);
        }

        [HttpPut("update-order-just-status-completed/{orderId}")]
        public async Task<AppActionResult> UpdateOrderCompleted(string orderId)
        {
            return await _orderService.UpdateOrderFinalCompleted(orderId);
        }

        [HttpPut("update-order-status-payment/{orderId}")]
        public async Task<AppActionResult> UpdateOrderStatusPaymentBySupplier(string orderId)
        {
            return await _orderService.UpdateOrderStatusPaymentBySupplier(orderId);
        }

        [HttpPut("cancel-order")]
        public async Task<AppActionResult> CancelOrder(CancelOrderRequest cancelOrderRequest)
        {
            return await _orderService.CancelOrder(cancelOrderRequest);
        }

        [HttpPut("accept-cancel-order/{orderId}")]
        public async Task<AppActionResult> AcceptCancelOrder(string orderId)
        {
            return await _orderService.AcceptCancelOrder(orderId);
        }
    }
}

