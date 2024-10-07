using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IWishlistService
    {
        Task<AppActionResult> CreateWishlist(CreateWishlistRequestDTO request);
        Task<AppActionResult> UpdateWishlist(string WishlistID, WishlistRequestDTO request);
        Task<AppActionResult> GetWishlistByMemberID(string MemberID, int pageIndex, int pageSize);
        Task<AppActionResult> GetAllWishlist(int pageIndex, int pageSize);
        Task<AppActionResult> GetWishlistById(string WishlistID);
        Task<AppActionResult> DeleteWishlist(string WishlistID);
    }
}
