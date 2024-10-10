using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ReturnDetailService : GenericBackendService, IReturnDetailService
    {
        private readonly IRepository<ReturnDetail> _returnDetailRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ReturnDetailService(
            IRepository<ReturnDetail> returnDetailRepository,
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _returnDetailRepository = returnDetailRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateReturnDetail(ReturnDetailRequest request)
        {
            var result = new AppActionResult();
            try
            {
                var hasOrder = await _orderRepository.GetByExpression(x => x.OrderID == request.OrderID);

                if (hasOrder == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy có đơn hàng nào!");
                    return result;
                }

                var returnDetail = _mapper.Map<ReturnDetail>(request);
                returnDetail.PenaltyApplied = request.PenaltyApplied;
                returnDetail.OrderID = request.OrderID;
                returnDetail.Condition = request.Condition;
                returnDetail.ReturnDate = DateTime.UtcNow;

                await _returnDetailRepository.Insert(returnDetail);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result.Result = returnDetail;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> DeleteReturnDetail(string ReturnID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ReturnID, out Guid ReturnODID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var returnD = await _returnDetailRepository.GetById(ReturnODID);
                if (returnD == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Hoàng trả không tồn tại!");
                    return result;
                }

                await _returnDetailRepository.DeleteById(ReturnODID);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Hoàng trả đã được xóa!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllReturnDetail(int pageIndex, int pageSize)
        {

            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<ReturnDetail, bool>>? filter = null;

                var Result = await _returnDetailRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(RD =>
                {
                    var response = _mapper.Map<ReturnDetailResponse>(Result);
                    response.ReturnID = RD.ReturnID.ToString();
                    response.OrderID = RD.OrderID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<ReturnDetailResponse>
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

        public async Task<AppActionResult> GetReturnDetailById(string ReturnID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ReturnID, out Guid ReturnDetailID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var returnDetail = await _returnDetailRepository.GetById(ReturnDetailID);
                if (returnDetail == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đơn trả!");
                    return result;
                }

                var response = _mapper.Map<ReturnDetailResponse>(returnDetail);
                response.ReturnID = returnDetail.ReturnID.ToString();
                response.OrderID = returnDetail.OrderID.ToString();
                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetReturnDetailByOrderID(string OrderID, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(OrderID, out Guid ReturnOrderID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                if (ReturnOrderID == Guid.Empty)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Không tìm thấy đơn hàng!");
                    return result;
                }

                var Result = await _returnDetailRepository.GetAllDataByExpression(
                    x => x.OrderID == ReturnOrderID,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(RD =>
                {
                    var response = _mapper.Map<ReturnDetailResponse>(Result);
                    response.ReturnID = RD.ReturnID.ToString();
                    response.OrderID = RD.OrderID.ToString();
                    return response;
                }).ToList();
                var pagedResult = new PagedResult<ReturnDetailResponse>
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

        public async Task<AppActionResult> UpdateReturnDetail(string ReturnID, ReturnDetailRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ReturnID, out Guid ReturnODID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingRT = await _returnDetailRepository.GetById(ReturnODID);
                if (existingRT == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Hoàn trả không tồn tại!");
                    return result;
                }

                existingRT.ReturnDate = request.ReturnDate;
                existingRT.Condition = request.Condition;
                existingRT.PenaltyApplied = request.PenaltyApplied;
                existingRT.CreatedAt = DateTime.UtcNow;


                await _returnDetailRepository.Update(existingRT);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<ReturnDetailResponse>(existingRT);
                response.ReturnID = existingRT.ReturnID.ToString();
                response.OrderID = existingRT.OrderID.ToString();
                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }
    }
}
