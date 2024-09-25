using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderBuy(CreateOrderBuyRequest request);

    }
}
