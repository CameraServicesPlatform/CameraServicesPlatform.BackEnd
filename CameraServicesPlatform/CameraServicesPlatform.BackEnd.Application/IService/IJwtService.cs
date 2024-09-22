using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;

namespace CameraServicesPlatform.BackEnd.Application.IService;

public interface IJwtService
{
    string GenerateRefreshToken();

    Task<string> GenerateAccessToken(LoginRequestDTO loginRequest);

    Task<TokenDTO> GetNewToken(string refreshToken, string accountId);
}