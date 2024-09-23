using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml.Packaging.Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderService : GenericBackendService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Account> accountRepository,
            IRepository<Supplier> supplierRepository,
            IRepository<Product> productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponse> CreateOrderBuy(CreateOrderBuyRequest request)
        {
            var result = new OrderResponse();
            try
            {
                var order = _mapper.Map<Order>(request);
                order.OrderDate = DateTime.Now;
                order.OrderStatus = 0; 

                await _orderRepository.Insert(order);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();

                var createdOrder = await _orderRepository
                                        .GetByExpression(x => x.MemberID == request.MemberID && x.OrderDate == order.OrderDate);

                if (createdOrder == null)
                {
                    throw new Exception("Không tìm thấy đơn hàng bạn vừa đặt. Hãy tạo lại đơn hàng của bạn");
                }

                var orderDetails = _mapper.Map<List<OrderDetail>>(request.OrderDetailRequests);

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = createdOrder.OrderID;
                }

                await _orderDetailRepository.InsertRange(orderDetails);
                await Task.Delay(200);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công");
            }

            return result;
        }
    }
}
