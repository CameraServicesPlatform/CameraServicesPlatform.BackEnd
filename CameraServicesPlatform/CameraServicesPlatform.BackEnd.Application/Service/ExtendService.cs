

using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Domain.Models.CameraServicesPlatform.BackEnd.Domain.Models;
using PdfSharp;
using System.Linq.Expressions;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ExtendService : GenericBackendService, IExtendService
    {
        private readonly IRepository<Extend> _extendRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ProductVoucher> _productVoucherRepository;
        private readonly IRepository<Vourcher> _voucherRepository;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<ContractTemplate> _contractTemplateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ExtendService(
            IRepository<Extend> extendRepository,
            IRepository<Order> orderRepository,
            IRepository<ProductVoucher> productVoucherRepository,
            IRepository<Account> accountRepository,
            IRepository<Payment> paymentRepository,
            IRepository<Transaction> transactionRepository,
            IRepository<Supplier> supplierRepository,
            IRepository<Vourcher> voucherRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Product> productRepository,
            IRepository<Contract> contractRepository,
            IRepository<ContractTemplate> contractTemplateRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _productVoucherRepository = productVoucherRepository;
            _voucherRepository = voucherRepository;
            _accountRepository = accountRepository;
            _extendRepository = extendRepository;
            _transactionRepository = transactionRepository;
            _paymentRepository = paymentRepository;
            _supplierRepository = supplierRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _contractTemplateRepository = contractTemplateRepository;
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public static class DateTimeHelper
        {
            private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Convert UTC DateTime to Vietnam Time
            public static DateTime ToVietnamTime(DateTime utcDateTime)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, VietnamTimeZone);
            }
        }
        public async Task<AppActionResult> CreateExtend(CreateExtendRequest request)
        {
            var result = new AppActionResult();
            try
            {
                var hasOrder = await _orderRepository.GetByExpression(x => x.OrderID == Guid.Parse(request.OrderID));

                if (hasOrder == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy có đơn hàng nào!");
                    return result;
                }
              
                var extend = _mapper.Map<Extend>(request);
                extend.RentalExtendStartDate = DateTimeHelper.ToVietnamTime(request.RentalExtendStartDate ?? DateTime.UtcNow);
                extend.TotalAmount = request.TotalAmount;
                extend.IsDisable = false;
                switch (extend.DurationUnit)
                {
                    case RentalDurationUnit.Hour:
                        extend.RentalExtendEndDate = extend.RentalExtendStartDate?.AddHours(extend.DurationValue);
                        break;
                    case RentalDurationUnit.Day:
                        extend.RentalExtendEndDate = extend.RentalExtendStartDate?.AddDays(extend.DurationValue);
                        break;
                    case RentalDurationUnit.Week:
                        extend.RentalExtendEndDate = extend.RentalExtendStartDate?.AddDays(extend.DurationValue * 7);
                        break;
                    case RentalDurationUnit.Month:
                        extend.RentalExtendEndDate = extend.RentalExtendStartDate?.AddMonths(extend.DurationValue);
                        break;
                    default:
                        throw new InvalidOperationException("DurationUnit is not supported.");
                }

                switch (extend.DurationUnit)
                {
                    case RentalDurationUnit.Hour:
                        extend.ExtendReturnDate = extend.RentalExtendStartDate?.AddHours(extend.DurationValue);
                        break;
                    case RentalDurationUnit.Day:
                        extend.ExtendReturnDate = extend.RentalExtendStartDate?.AddDays(extend.DurationValue);
                        break;
                    case RentalDurationUnit.Week:
                        extend.ExtendReturnDate = extend.RentalExtendStartDate?.AddDays(extend.DurationValue * 7);
                        break;
                    case RentalDurationUnit.Month:
                        extend.ExtendReturnDate = extend.RentalExtendStartDate?.AddMonths(extend.DurationValue);
                        break;
                    default:
                        throw new InvalidOperationException("DurationUnit is not supported.");
                }

                hasOrder.OrderStatus = OrderStatus.Extend;
                hasOrder.IsExtend = true;
                await _orderRepository.Update(hasOrder);
                await _unitOfWork.SaveChangesAsync();

                await Task.Delay(100);

                await _extendRepository.Insert(extend);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result.Result = extend;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllExtend(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Extend, bool>>? filter = null;

                var Result = await _extendRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(RD =>
                {
                    var response = _mapper.Map<ExtendResponse>(RD);
                    response.ExtendId = RD.ExtendId.ToString();
                    response.OrderID = RD.OrderID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<ExtendResponse>
                {
                    Items = responses
                };

                result.IsSuccess = true;
                result.Result = pagedResult;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetExtendById(string ExtendID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ExtendID, out Guid GExtendID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var extend = await _extendRepository.GetById(GExtendID);
                if (extend == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy gia hạng!");
                    return result;
                }

                var response = _mapper.Map<ExtendResponse>(extend);
                response.ExtendId = extend.ExtendId.ToString();
                response.OrderID = extend.OrderID.ToString();
                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllExtendByOrderId(string OrderID, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(OrderID, out Guid GOrderID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
               
                var Result = await _extendRepository.GetAllDataByExpression(
                    x => x.OrderID == GOrderID,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(RD =>
                {
                    var response = _mapper.Map<ExtendResponse>(Result);
                    response.ExtendId = RD.ExtendId.ToString();
                    response.OrderID = RD.OrderID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<ExtendResponse>
                {
                    Items = responses
                };

                result.IsSuccess = true;
                result.Result = pagedResult;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
    }
}
