using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IRatingService
    {
        Task<AppActionResult> CreateRating(RatingRequest request);
        Task<AppActionResult> UpdateRating(string ratingId, RatingRequest request);
        Task<AppActionResult> DeleteRating(string ratingId);
        Task<AppActionResult> GetRatingsByProduct(string productId, int pageIndex, int pageSize);
        Task<AppActionResult> GetAllRating(int pageIndex, int pageSize);
        Task<AppActionResult> GetRatingById(string ratingId);
        Task<AppActionResult> GetRatingsByProductAndAccountID(string productId, string accountId, int pageIndex, int pageSize);
        Task<AppActionResult> GetRatingsByAccountID(string accountId, int pageIndex, int pageSize);

    }
}
