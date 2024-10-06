using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("create-rating")]
        public async Task<IActionResult> CreateRating([FromBody] RatingRequest request)
        {
            try
            {
                var response = await _ratingService.CreateRating(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-rating/{ratingId}")]
        public async Task<IActionResult> UpdateRating(Guid ratingId, [FromBody] RatingRequest request)
        {
            try
            {
                var response = await _ratingService.UpdateRating(ratingId, request);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-rating-by-id")]
        public async Task<IActionResult> DeleteRating(Guid ratingId)
        {
            try
            {
                var response = await _ratingService.DeleteRating(ratingId);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-ratings-by-product-id")]
        public async Task<AppActionResult> GetRatingsByProduct(Guid productId, int pageIndex = 1, int pageSize = 10)
        {
            return await _ratingService.GetRatingsByProduct(productId, pageIndex, pageSize);
        }

        [HttpGet("get-ratings-by-rating-id")]
        public async Task<AppActionResult> GetRatingsByRatingId(Guid ratingId)
        {
            return await _ratingService.GetRatingById(ratingId);
        }

        [HttpGet("get-all-ratings")]
        public async Task<AppActionResult> GetAllRatings( int pageIndex = 1, int pageSize = 10)
        {
            return await _ratingService.GetAllRating(pageIndex, pageSize);
        }
    }
}

