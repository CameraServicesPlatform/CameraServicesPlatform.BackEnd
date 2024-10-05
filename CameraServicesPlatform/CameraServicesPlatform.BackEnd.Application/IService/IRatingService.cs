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
        Task<AppActionResult> UpdateRating(Guid ratingId, RatingRequest request);
        Task<AppActionResult> DeleteRating(Guid ratingId);
        Task<AppActionResult> GetRatingsByProduct(Guid productId, int pageIndex, int pageSize);
    }
}
