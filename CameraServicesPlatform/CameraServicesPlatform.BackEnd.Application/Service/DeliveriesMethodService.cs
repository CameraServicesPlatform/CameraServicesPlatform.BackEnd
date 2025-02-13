using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class DeliveriesMethodService : GenericBackendService, IDeliveriesMethodService
    {
        private readonly IRepository<DeliveriesMethod> _deliveriesMethodRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeliveriesMethodService(
            IRepository<DeliveriesMethod> deliveriesMethodRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _deliveriesMethodRepository = deliveriesMethodRepository;
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

        public async Task<AppActionResult> GetAllDeliveriesMethod(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<DeliveriesMethod, bool>>? filter = null;
                List<DeliveriesMethodResponse> listDeliveriesMethod = new List<DeliveriesMethodResponse>();
                var pagedResult = await _deliveriesMethodRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                foreach (var item in pagedResult.Items)
                {

                    DeliveriesMethodResponse deliveriesMethodResponse = new DeliveriesMethodResponse
                    {
                        DeliveriesMethodID = item.DeliveriesMethodID.ToString(),
                        DeliveriesMethodName = item.DeliveriesMethodName,
                        OrderID = item.OrderID.ToString(),
                        Description = item.Description,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                    };
                    listDeliveriesMethod.Add(deliveriesMethodResponse);
                }

                result.Result = listDeliveriesMethod;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
    

        public async Task<AppActionResult> GetDeliveriesMethodById(string deliveriesMethodId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(deliveriesMethodId, out Guid Id))
                {
                    result = BuildAppActionResultError(result, "Invalid deliver method ID format.");
                    return result;
                }

                var pagedResult = await _deliveriesMethodRepository.GetAllDataByExpression(
                    a => a.DeliveriesMethodID == Id,
                    1,
                    10,
                    null,
                    isAscending: true,
                    null
                );
                DeliveriesMethodResponse DeliveriesMethodResponse = new DeliveriesMethodResponse
                {
                    DeliveriesMethodID = pagedResult.Items[0].DeliveriesMethodID.ToString(),
                    DeliveriesMethodName = pagedResult.Items[0].DeliveriesMethodName,
                    OrderID = pagedResult.Items[0].OrderID.ToString(),
                    Description = pagedResult.Items[0].Description,
                    CreatedAt = pagedResult.Items[0].CreatedAt,
                    UpdatedAt = pagedResult.Items[0].UpdatedAt
                };
                result.Result = DeliveriesMethodResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CreateDeliveriesMethod(DeliveriesMethodRequest request)
        {
            var result = new AppActionResult();
            try
            {

                if (!Guid.TryParse(request.OrderID, out Guid CROrderID))
                {
                    result = BuildAppActionResultError(result, "Invalid deliver method ID format.");
                    return result;
                }

                var deliveriesMethod = new DeliveriesMethod
                {
                    OrderID = CROrderID,
                    DeliveriesMethodName = request.DeliveriesMethodName,
                    Description = request.Description,
                    CreatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                    UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow),
                };

                await _deliveriesMethodRepository.Insert(deliveriesMethod);
                await _unitOfWork.SaveChangesAsync();

                DeliveriesMethodResponse DeliveriesMethodResponse = new DeliveriesMethodResponse
                {
                    DeliveriesMethodID = deliveriesMethod.DeliveriesMethodID.ToString(),
                    DeliveriesMethodName = deliveriesMethod.DeliveriesMethodName,
                    OrderID = deliveriesMethod.OrderID.ToString(),
                    Description = deliveriesMethod.Description,
                    CreatedAt = deliveriesMethod.CreatedAt,
                    UpdatedAt = deliveriesMethod.UpdatedAt
                };
                result.Result = DeliveriesMethodResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> UpdateDeliveriesMethod(DeliveriesMethodUpdateRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(request.DeliveriesMethodID, out Guid UDDeliveriesMethodID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existing = await _deliveriesMethodRepository.GetByExpression(x => x.DeliveriesMethodID == UDDeliveriesMethodID);
                if (existing == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Deliveries Method không tồn tại!");
                    return result;
                }

                existing.DeliveriesMethodName = request.DeliveriesMethodName;
                existing.Description = request.Description;
                existing.UpdatedAt = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                await _deliveriesMethodRepository.Update(existing);
                await _unitOfWork.SaveChangesAsync();


                DeliveriesMethodResponse DeliveriesMethodResponse = new DeliveriesMethodResponse
                {
                    DeliveriesMethodID = existing.DeliveriesMethodID.ToString(),
                    DeliveriesMethodName = existing.DeliveriesMethodName,
                    OrderID = existing.OrderID.ToString(),
                    Description = existing.Description,
                    CreatedAt = existing.CreatedAt,
                    UpdatedAt = existing.UpdatedAt
                };
                result.Result = DeliveriesMethodResponse;
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

