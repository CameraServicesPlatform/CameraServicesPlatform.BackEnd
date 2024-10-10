using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
 using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
 

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderBuy(CreateOrderBuyRequest request);
        Task<AppActionResult> GetOrderByOrderType(OrderType orderType, int pageIndex, int pageSize);
        Task<AppActionResult> GetOrderOfSupplier(string SupplierID, int pageIndex, int pageSize);

        Task<AppActionResult> GetOrderByMemberID(string MemberID, int pageIndex, int pageSize);
        Task<AppActionResult> CountProductRentals(string productId, int pageIndex, int pageSize);

        Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize);
        Task<AppActionResult> UpdateOrderStatus(string OrderID);
        Task<AppActionResult> CancelOrder(string OrderID);



    }
}
