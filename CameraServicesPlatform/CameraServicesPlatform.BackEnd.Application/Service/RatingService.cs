using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RatingService(
            IRepository<Rating> ratingRepository,
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Account> accountRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _ratingRepository = ratingRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AppActionResult> CreateRating(RatingRequest request)
        {
            var result = new AppActionResult();
            try
            {
               
                if (!Guid.TryParse(request.ProductID, out Guid RatingProductID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                if (request.RatingValue > 5)
                {
                    result = BuildAppActionResultError(result, "giá trị đánh không được lớn hơn 5");
                    return result;
                }
                var account = await _accountRepository.GetByExpression(x => x.Id == request.AccountID);

                var hasOrder = await _orderRepository.GetByExpression(x => x.Id == account.Id);

                if (hasOrder == null)
                {
                    result = BuildAppActionResultError(result, "Không thể đánh giá sản phẩm mà bạn chưa đặt hàng");
                    return result;
                }

                var hasOrderDetail = await _orderDetailRepository.GetByExpression(x => x.ProductID == RatingProductID);

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

                var ratingResponse = _mapper.Map<RatingResponse>(rating);
                ratingResponse.RatingID = rating.RatingID.ToString();
                ratingResponse.ProductID = rating.ProductID.ToString();
                ratingResponse.AccountID = rating.AccountID.ToString();

                result.IsSuccess = true;
                result.Result = ratingResponse;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> GetRatingById(string ratingId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ratingId, out Guid RatingID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }

                var rating = await _ratingRepository.GetById(RatingID);
                if (rating == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy đánh giá");
                    return result;
                }

                var ratingResponse = _mapper.Map<RatingResponse>(rating);
                ratingResponse.RatingID = rating.RatingID.ToString();
                ratingResponse.ProductID = rating.ProductID.ToString();
                ratingResponse.AccountID = rating.AccountID.ToString();

                result.IsSuccess = true;
                result.Result = ratingResponse;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> GetRatingsByProduct(string productId, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(productId, out Guid RatingProductID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                if (RatingProductID == Guid.Empty)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Không tìm thấy sản phẩm");
                    return result;
                }

                var pagedResult = await _ratingRepository.GetAllDataByExpression(
                    x => x.ProductID == RatingProductID,
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

        public async Task<AppActionResult> UpdateRating(string ratingId, RatingRequest request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ratingId, out Guid RatingID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var rating = await _ratingRepository.GetByExpression(x => x.RatingID == RatingID);

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

                var ratingResponse = _mapper.Map<RatingResponse>(rating);
                ratingResponse.RatingID = rating.RatingID.ToString();
                ratingResponse.ProductID = rating.ProductID.ToString();
                ratingResponse.AccountID = rating.AccountID.ToString();

                result.IsSuccess = true;
                result.Result = ratingResponse;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> DeleteRating(string ratingId)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(ratingId, out Guid RatingID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var rating = await _ratingRepository.GetByExpression(x => x.RatingID == RatingID);

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
                var convertedResult = pagedResult.Items.Select(rating => new
                {
                    RatingID = rating.RatingID.ToString(),
                    ProductID = rating.ProductID.ToString(),
                    AccountID=rating.AccountID.ToString(),
                    rating.RatingValue,
                    rating.ReviewComment,
                    rating.CreatedAt              
                }).ToList();
                result.Result = convertedResult;
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
