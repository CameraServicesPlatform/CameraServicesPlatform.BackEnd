using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderService : GenericBackendService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<Product> _productRepository;
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
            _accountRepository = accountRepository;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
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
                    throw new Exception("Order not found after creation.");
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
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
