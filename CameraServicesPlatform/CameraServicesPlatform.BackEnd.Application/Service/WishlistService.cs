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
using Twilio.TwiML.Voice;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class WishlistService : GenericBackendService, IWishlistService
    {
        private readonly IRepository<Wishlist> _wishListRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public WishlistService(
            IRepository<Wishlist> wishListRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _wishListRepository = wishListRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateWishlist(CreateWishlistRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                var hasM = await _wishListRepository.GetByExpression(x => x.AccountID == request.AccountID);

                if (hasM == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy sản phẩm nào!");
                    return result;
                }

                var wl = _mapper.Map<Wishlist>(request);
                wl.ProductID = Guid.Parse(request.ProductID);
                wl.AccountID = request.AccountID;
              

                await _wishListRepository.Insert(wl);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result.Result = wl;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> DeleteWishlist(string WishlistID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(WishlistID, out Guid WishlistDTID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var WL = await _wishListRepository.GetById(WishlistDTID);
                if (WL == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Danh sách không tồn tại!");
                    return result;
                }

                await _wishListRepository.DeleteById(WishlistDTID);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result = BuildAppActionResultError(result, "Đã xóa khỏi danh sách!");
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllWishlist(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Wishlist, bool>>? filter = null;

                var Result = await _wishListRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(WL =>
                {
                    var response = _mapper.Map<WishlistResponse>(Result);
                    response.WishlistID = WL.WishlistID.ToString();
                    response.ProductID = WL.ProductID.ToString();
                    response.AccountID = WL.AccountID;

                    return response;
                }).ToList();
                var pagedResult = new PagedResult<WishlistResponse>
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

        public async Task<AppActionResult> GetWishlistById(string WishlistID)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(WishlistID, out Guid WishlistDTID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var wl = await _wishListRepository.GetById(WishlistDTID);
                if (wl == null)
                {
                    result = BuildAppActionResultError(result, "Không tìm thấy danh sách!");
                    return result;
                }

                var response = _mapper.Map<WishlistResponse>(wl);
                response.WishlistID = wl.WishlistID.ToString();
                response.ProductID = wl.ProductID.ToString();
                response.AccountID = wl.AccountID;

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetWishlistByMemberID(string AccountID, int pageIndex, int pageSize)
        {
            var result = new AppActionResult();
            try
            {

                var Result = await _wishListRepository.GetAllDataByExpression(
                    x => x.AccountID == AccountID,
                    pageNumber: pageIndex,
                    pageSize: pageSize
                );

                var responses = Result.Items.Select(WL =>
                {
                    var response = _mapper.Map<WishlistResponse>(WL);
                    response.WishlistID = WL.WishlistID.ToString();
                    response.ProductID = WL.ProductID.ToString();
                    response.AccountID = WL.AccountID;

                    return response;
                }).ToList();
                var pagedResult = new PagedResult<WishlistResponse>
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

        public async Task<AppActionResult> UpdateWishlist(string WishlistID, WishlistRequestDTO request)
        {
            var result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(WishlistID, out Guid UPWishlistID))
                {
                    result = BuildAppActionResultError(result, "ID không hợp lệ!");
                    return result;
                }
                var existingwl = await _wishListRepository.GetById(UPWishlistID);
                if (existingwl == null)
                {
                    result.IsSuccess = false;
                    result = BuildAppActionResultError(result, "Danh sách không tồn tại!");
                    return result;
                }

                existingwl.ProductID = request.ProductID;               

                await _wishListRepository.Update(existingwl);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<WishlistResponse>(existingwl);
                response.WishlistID = existingwl.WishlistID.ToString();
                response.ProductID = existingwl.ProductID.ToString();
                response.AccountID = existingwl.AccountID;

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
