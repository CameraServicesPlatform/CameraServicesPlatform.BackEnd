﻿using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
 using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using Microsoft.AspNetCore.Http;


namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IOrderService
    {
        Task<AppActionResult> CreateOrderBuy(CreateOrderBuyRequest request);
        Task<AppActionResult> CreateOrderRent(CreateOrderRentRequest request);
        Task<AppActionResult> CreateOrderWithPayment(CreateOrderBuyRequest request, HttpContext context);
        Task<AppActionResult> GetOrderByOrderType(OrderType orderType, int pageIndex, int pageSize);
        Task<AppActionResult> GetOrderOfSupplier(string SupplierID, int pageIndex, int pageSize);
        Task<AppActionResult> GetOrderStatusOfSupplier(string SupplierID, OrderStatus status, int pageIndex, int pageSize);

        Task<AppActionResult> GetOrderByAccountID(string AccoountID, int pageIndex, int pageSize);
        Task<AppActionResult> CountProductRentals(string productId, int pageIndex, int pageSize);
        Task<AppActionResult> PurchaseOrder(string orderId, HttpContext context);

        Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize);
        Task<AppActionResult> GetAllOrderRent(int pageIndex, int pageSize);
        Task<AppActionResult> GetAllOrderBuy(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateOrderStatusCompletedBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusShippedBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusPaymentBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusApprovedBySupplier(string OrderID);

        Task<AppActionResult> CancelOrder(CancelOrderRequest cancelOrderRequest);
        Task<AppActionResult> AcceptCancelOrder(string OrderID);

        Task<AppActionResult> GetOrderByOrderStatus(OrderStatus orderStatus, int pageIndex, int pageSize);
        Task<AppActionResult> GetOrderByOrderID(string OrderID);

        Task<AppActionResult> CreateOrderRentWithPayment(CreateOrderRentRequest request, HttpContext context);
        Task<AppActionResult> UpdateOrderStatusPlaced(string OrderID);

        Task<AppActionResult> AddImageProductAfter(ImageProductAfterDTO dto);
        Task<AppActionResult> AddImageProductBefore(ImageProductBeforeDTO dto);

        Task<AppActionResult> UpdateOrderPendingRefund(string OrderID);
        Task<AppActionResult> UpdateOrderRefund(string OrderID);
        Task<AppActionResult> UpdateOrderDepositReturn(string OrderID);
        Task<AppActionResult> UpdateOrderFinalCompleted(string OrderID);

        Task<AppActionResult> GetImageProductAfter(string orderId);
        Task<AppActionResult> GetImageProductBefore(string orderId);

        Task<AppActionResult> GetOrderOrderStatusByAccountID(string AccountID, OrderStatus orderStatus, int pageIndex, int pageSize);

        Task<AppActionResult> GetOrderOfAccountByOrderID(string OrderId, int pageIndex, int pageSize);

    }
}
