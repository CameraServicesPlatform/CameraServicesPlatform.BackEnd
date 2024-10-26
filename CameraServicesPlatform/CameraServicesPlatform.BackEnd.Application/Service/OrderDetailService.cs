using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<AppActionResult> GetOrderDetailsByOrderId(string orderId, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {

                if (!Guid.TryParse(orderId, out Guid OrderId))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var orderDetailsPagedResult = await _orderDetailRepository.GetAllDataByExpression(
                    x => x.OrderID == OrderId,
                    pageNumber: pageIndex,
                    pageSize: pageSize,
                    includes: new Expression<Func<OrderDetail, object>>[] { o => o.Product }
                );

                if (orderDetailsPagedResult == null || !orderDetailsPagedResult.Items.Any())
                {
                    result = BuildAppActionResultError(result, "Không có chi tiết đơn hàng của đơn hàng này");
                    return result;
                }

                //var orderDetailResponses = new List<OrderDetailResponse>();
                //foreach (var od in orderDetailsPagedResult.Items)
                //{
                //    var response = _mapper.Map<OrderDetailResponse>(od);
                //    response.OrderID = od.OrderID.ToString();
                //    response.ProductID = od.ProductID.ToString();
                //    response.OrderDetailsID = od.OrderDetailsID.ToString();
                //}
                var convertedResult = orderDetailsPagedResult.Items.Select(orderd => new
                {
                    OrderID = orderd.OrderID.ToString(),
                    ProductID = orderd.ProductID.ToString(),
                    OrderDetailsID = orderd.OrderDetailsID.ToString(),
                    ProductName = orderd.Product.ProductName,
                    orderd.Discount,
                    orderd.RentalPeriod,
                    orderd.ProductPrice,
                    orderd.ProductPriceTotal,
                    orderd.ProductQuality,
                    orderd.Product,

                }).ToList();

                result.IsSuccess = true;
                result.Result = convertedResult;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
    }
}
