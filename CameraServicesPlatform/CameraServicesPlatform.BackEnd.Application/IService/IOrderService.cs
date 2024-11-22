using CameraServicesPlatform.BackEnd.Common.DTO.Request;
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

        Task<AppActionResult> GetOrderByAccountID(string AccoountID, int pageIndex, int pageSize);
        Task<AppActionResult> CountProductRentals(string productId, int pageIndex, int pageSize);
        Task<AppActionResult> PurchaseOrder(string orderId, HttpContext context);

        Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateOrderStatusCompletedBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusShippedBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusPaymentBySupplier(string OrderID);
        Task<AppActionResult> UpdateOrderStatusApprovedBySupplier(string OrderID);

        Task<AppActionResult> CancelOrder(string OrderID);
        Task<AppActionResult> AcceptCancelOrder(string OrderID);

        Task<AppActionResult> GetOrderByOrderStatus(OrderStatus orderStatus, int pageIndex, int pageSize);
        Task<AppActionResult> GetOrderByOrderID(string OrderID);

        Task<AppActionResult> CreateOrderRentWithPayment(CreateOrderRentRequest request, HttpContext context);
        Task<AppActionResult> UpdateOrderStatusPlaced(string OrderID);

        Task<AppActionResult> AddImageProductAfter(ImageProductAfterDTO dto);
        Task<AppActionResult> AddImageProductBefore(ImageProductBeforeDTO dto);


    }
}
