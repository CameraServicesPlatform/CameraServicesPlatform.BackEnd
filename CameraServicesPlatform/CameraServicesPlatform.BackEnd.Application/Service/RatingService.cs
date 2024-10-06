using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
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
    public class RatingService: GenericBackendService, IRatingService
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RatingService(
            IRepository<Rating> ratingRepository,
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _ratingRepository = ratingRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AppActionResult> CreateRating(RatingRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (request.RatingValue > 5)
                {
                    result = BuildAppActionResultError(result, "giá trị đánh không được lớn hơn 5");
                    return result;
                }
                var hasOrder = await _orderRepository.GetByExpression(x => x.MemberID == request.AccountID);

                if (hasOrder == null)
                {
                    result = BuildAppActionResultError(result, "Không thể đánh giá sản phẩm mà bạn chưa đặt hàng");
                    return result;
                }

                var hasOrderDetail = await _orderDetailRepository.GetByExpression(x => x.ProductID == request.ProductID);

                if (hasOrderDetail == null)
                {
                    result = BuildAppActionResultError(result, "Không thể đánh giá sản phẩm mà bạn chưa đặt hàng");
                    return result;
                }

                var rating = _mapper.Map<Rating>(request);
                rating.RatingID = Guid.NewGuid(); 
                rating.CreatedAt = DateTime.UtcNow;

                await _ratingRepository.Insert(rating);
                await _unitOfWork.SaveChangesAsync(); 

                result.IsSuccess = true;
                result.Result = _mapper.Map<RatingResponse>(rating);
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> GetRatingById(Guid ratingId)
        {
            var result = new AppActionResult();
            try
            {
                //var rating = await _ratingRepository.GetByExpression(x => x.RatingID == ratingId);
                var rating = await _ratingRepository.GetById(ratingId);
                if (rating == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đánh giá");
                    return result;
                }

                result.IsSuccess = true;
                result.Result = _mapper.Map<RatingResponse>(rating);
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> GetRatingsByProduct(Guid productId, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                if (productId == Guid.Empty)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Không tìm thấy sản phẩm");
                    return result;
                }

                var pagedResult = await _ratingRepository.GetAllDataByExpression(
                    x => x.ProductID == productId,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                if (pagedResult.Items.Count == 0)
                {
                    result.IsSuccess = true;
                    result = BuildAppActionResultError(result, "Không tìm thấy đánh giá cho sản phẩm này");
                    result.Result = new
                    {
                        AverageRating = 0,
                        ReviewComments = new List<string>() 
                    };
                    return result;
                }

                var averageRating = pagedResult.Items.Average(r => r.RatingValue);
                averageRating = Math.Min(averageRating, 5);

                var reviewComments = pagedResult.Items.Select(r => r.ReviewComment).ToList();

                result.IsSuccess = true;
                result.Result = new
                {
                    AverageRating = averageRating,
                    ReviewComments = reviewComments
                };
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateRating(Guid ratingId, RatingRequest request)
        {
            var result = new AppActionResult();
            try
            {
                var rating = await _ratingRepository.GetByExpression(x => x.RatingID == ratingId);

                if (rating == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đánh giá");
                    return result;
                }

                if (request.RatingValue > 5)
                {
                    result = BuildAppActionResultError(result, "giá trị đánh không được lớn hơn 5");
                    return result;
                }

                _mapper.Map(request, rating); 
                rating.CreatedAt = DateTime.UtcNow; 

                _ratingRepository.Update(rating);
                await _unitOfWork.SaveChangesAsync(); 

                result.IsSuccess = true;
                result.Result = _mapper.Map<RatingResponse>(rating); 
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> DeleteRating(Guid ratingId)
        {
            var result = new AppActionResult();
            try
            {
                var rating = await _ratingRepository.GetByExpression(x => x.RatingID == ratingId);

                if (rating == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đánh giá");
                    return result;
                }

                await _ratingRepository.DeleteById(ratingId);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Xóa phản hồi thành công");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetAllRating(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Rating, bool>>? filter = null;

                var pagedResult = await _ratingRepository.GetAllDataByExpression(
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
    }
}
