using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderDetailService : GenericBackendService, IOrderDetailService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(
            IRepository<OrderDetail> orderDetailRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppActionResult> GetOrderDetailsByOrderId(Guid orderId, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                // Giả sử phương thức trả về PagedResult<OrderDetail>
                var orderDetailsPagedResult = await _orderDetailRepository.GetAllDataByExpression(
                    x => x.OrderID == orderId,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                // Kiểm tra null và có item nào không
                if (orderDetailsPagedResult == null || !orderDetailsPagedResult.Items.Any())
                {
                    result = BuildAppActionResultError(result, "Không có chi tiết đơn hàng của đơn hàng này");
                    return result;
                }

                // Truy cập danh sách chi tiết đơn hàng
                var orderDetailResponses = new List<OrderDetailResponse>();
                foreach (var od in orderDetailsPagedResult.Items) // Hoặc orderDetailsPagedResult.Results tùy thuộc vào định nghĩa
                {
                    var response = _mapper.Map<OrderDetailResponse>(od);
                    orderDetailResponses.Add(response);
                }

                result.IsSuccess = true;
                result.Result = orderDetailResponses;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
    }
}
