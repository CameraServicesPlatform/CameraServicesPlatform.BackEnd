using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
 using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
 

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderBuy(CreateOrderBuyRequest request);
        Task<AppActionResult> GetOrderByOrderType(OrderType orderType, int pageIndex, int pageSize);
        Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateOrderStatus(Guid OrderID);
        Task<AppActionResult> CancelOrder(Guid OrderID);



    }
}
