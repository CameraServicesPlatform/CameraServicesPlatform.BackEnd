﻿using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
 
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml.Packaging.Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
 
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using MailKit.Search;


namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class OrderService : GenericBackendService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Product> productRepository,
            IRepository<Contract> contractRepository,
            IRepository<ContractTemplate> contractTemplateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _contractTemplateRepository = contractTemplateRepository;
            _contractRepository = contractRepository;
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

                foreach (var orderDetailRequest in request.OrderDetailRequests)
                {
                    var product = await _productRepository.GetById(orderDetailRequest.ProductID);
                    if (product != null)
                    {
                        product.Status = ProductStatusEnum.Shipping;  
                        _productRepository.Update(product);
                    }
                }
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();
                
                result = _mapper.Map<OrderResponse>(createdOrder);
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công");
            }

            return result;
        }

        public async Task<OrderResponse> CreateOrderRent(CreateOrderRentRequest request)
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

                foreach (var orderDetailRequest in request.OrderDetailRequests)
                {
                    var product = await _productRepository.GetById(orderDetailRequest.ProductID);
                    if (product != null)
                    {
                        product.Status = ProductStatusEnum.Shipping;
                        await _productRepository.Update(product);
                    }
                }
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();

                var checkTemplate = await _contractTemplateRepository.GetById(request.ContractRequest.ContractTemplateId);
                if (checkTemplate == null)
                {
                    throw new Exception("Hãy chọn mẫu hợp đồng!");
                }
                var contract = new Contract
                {
                    OrderID = createdOrder.OrderID,
                    ContractTerms = request.ContractRequest.ContractTerms,
                    PenaltyPolicy = request.ContractRequest.PenaltyPolicy,
                };

                await _contractRepository.Insert(contract);
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();

                result = _mapper.Map<OrderResponse>(createdOrder);
            }
            catch (Exception ex)
            {
                throw new Exception("Không tạo đơn hàng thành công");
            }

            return result;
        }

        public async Task<AppActionResult> GetAllOrder(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderByOrderType(OrderType orderType, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.OrderType == orderType,
                    pageIndex,
                    pageSize
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> GetByOrderId(Guid orderId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var order = await _orderRepository.GetByExpression(
                    filter: o => o.OrderID == orderId,   
                    includeProperties: o => o.OrderDetail
                );
                if (order == null)
                {
                    result = BuildAppActionResultError(result, "Đơn hàng không tồn tại");
                    return result;
                }

                var orderResponse = _mapper.Map<OrderResponse>(order);

                result.Result = orderResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message); 
            }

            return result;
        }

        public async Task<AppActionResult> UpdateOrderStatus(Guid OrderID)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var order = await _orderRepository.GetById(OrderID);
            if (order != null)
            {
                order.OrderStatus = OrderStatus.Completed;
                _orderRepository.Update(order);
                await Task.Delay(100);
                await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CancelOrder(Guid OrderID)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var order = await _orderRepository.GetById(OrderID);
                if (order != null)
                {
                    order.OrderStatus = OrderStatus.Completed;
                    _orderRepository.Update(order);
                    await Task.Delay(100);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderOfSupplier(Guid SupplierID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.SupplierID == SupplierID,
                    pageIndex,
                    pageSize
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetOrderByMemberID(Guid MemberID, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Product, bool>>? filter = null;

                var pagedResult = await _orderRepository.GetAllDataByExpression(
                    x => x.MemberID == MemberID,
                    pageIndex,
                    pageSize
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
    }
}
