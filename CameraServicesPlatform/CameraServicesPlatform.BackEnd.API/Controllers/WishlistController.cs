using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("wishlist")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpPost("create-wishlist")]
        public async Task<IActionResult> CreateReturnDetail([FromBody] CreateWishlistRequestDTO request)
        {
            try
            {
                var response = await _wishlistService.CreateWishlist(request);
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

        [HttpPut("update-wish-list-by-id")]
        public async Task<IActionResult> UpdateWishlist(string wishlistID, [FromBody] WishlistRequestDTO request)
        {
            try
            {
                var response = await _wishlistService.UpdateWishlist(wishlistID, request);
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

        [HttpDelete("delete-wish-list-detail-by-id")]
        public async Task<IActionResult> DeleteWishlist(string wishlistId)
        {
            try
            {
                var response = await _wishlistService.DeleteWishlist(wishlistId);
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

        [HttpGet("get-wish-list-by-id")]
        public async Task<IActionResult> GetWishlistById(string wishlistId)
        {
            try
            {
                var response = await _wishlistService.GetWishlistById(wishlistId);
                if (!response.IsSuccess)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-wish-list-by-member-id")]
        public async Task<IActionResult> GetWishlistByMemberID(string AccountID, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var response = await _wishlistService.GetWishlistByMemberID(AccountID, pageIndex, pageSize);
                if (!response.IsSuccess)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-wish-list")]
        public async Task<AppActionResult> GetAllWishlist(int pageIndex = 1, int pageSize = 10)
        {
            return await _wishlistService.GetAllWishlist(pageIndex, pageSize);
        }
    }
}
