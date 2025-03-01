﻿using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("rating")]
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
        public async Task<IActionResult> UpdateRating(string ratingId, [FromBody] RatingRequest request)
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

        [HttpPut("delete-rating-by-id")]
        public async Task<IActionResult> DeleteRating(string ratingId)
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
        public async Task<AppActionResult> GetRatingsByProduct(string productId, int pageIndex, int pageSize)
        {
            return await _ratingService.GetRatingsByProduct(productId, pageIndex, pageSize);
        }

        [HttpGet("get-ratings-by-rating-id")]
        public async Task<AppActionResult> GetRatingsByRatingId(string ratingId)
        {
            return await _ratingService.GetRatingById(ratingId);
        }

        [HttpGet("get-all-ratings")]
        public async Task<AppActionResult> GetAllRatings( int pageIndex , int pageSize)
        {
            return await _ratingService.GetAllRating(pageIndex, pageSize);
        }

        [HttpGet("get-ratings-by-account-id")]
        public async Task<AppActionResult> GetRatingsByAccountID(string accountId, int pageIndex, int pageSize)
        {
            return await _ratingService.GetRatingsByAccountID(accountId, pageIndex, pageSize);
        }

        [HttpGet("get-ratings-by-product-and-account-id")]
        public async Task<AppActionResult> GetRatingsByProductAndAccountID(string productId, string accountId, int pageIndex, int pageSize)
        {
            return await _ratingService.GetRatingsByProductAndAccountID(productId, accountId, pageIndex, pageSize);
        }
    }
}

