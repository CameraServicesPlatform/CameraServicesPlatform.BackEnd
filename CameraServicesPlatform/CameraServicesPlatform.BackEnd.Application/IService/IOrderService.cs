﻿using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
 using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using Microsoft.AspNetCore.Http;


namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderBuy(CreateOrderBuyRequest request);
        Task<OrderResponse> CreateOrderRent(CreateOrderRentRequest request);
        Task<OrderResponse> CreateOrderWithPayment(CreateOrderBuyRequest request, HttpContext context);
        Task<AppActionResult> GetOrderByOrderType(OrderType orderType, int pageIndex, int pageSize);
        Task<AppActionResult> GetOrderOfSupplier(string SupplierID, int pageIndex, int pageSize);

        Task<AppActionResult> GetOrderByAccountID(string AccoountID, int pageIndex, int pageSize);
        Task<AppActionResult> CountProductRentals(string productId, int pageIndex, int pageSize);

        Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateOrderStatusCompletedBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusShippedBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusApprovedBySupplier(string OrderID);

        Task<AppActionResult> CancelOrder(string OrderID);



    }
}
