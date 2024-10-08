﻿using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

using Utility = CameraServicesPlatform.BackEnd.Common.Utils.Utility;

namespace CameraServicesPlatform.BackEnd.Application.Service;

public class JwtService : GenericBackendService, IJwtService
{
    private readonly JWTConfiguration _jwtConfiguration;
    private readonly BackEndLogger _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Account> _userManager;

    public JwtService(
        IUnitOfWork unitOfWork,
        UserManager<Account> userManager,
        IServiceProvider serviceProvider,
        BackEndLogger logger
    )
        : base(serviceProvider)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _logger = logger;
        _jwtConfiguration = Resolve<JWTConfiguration>()!;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<string> GenerateAccessToken(LoginRequestDTO loginRequest)
    {
        try
        {
            var accountRepository = Resolve<IRepository<Account>>();
            var utility = Resolve<Utility>();

            var user = await accountRepository!.GetByExpression(u =>
                u!.Email.ToLower() == loginRequest.Email.ToLower());

            if (user == null)
            {
                _logger.LogError("User not found for email: {Email}", loginRequest.Email);
                throw new Exception("Invalid credentials."); // Adjust exception as needed
            }

            var roles = await _userManager.GetRolesAsync(user);
            if (roles != null && roles.Any())
            {
                var claims = new List<Claim>
            {
                new(ClaimTypes.Email, loginRequest.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("AccountId", user.Id.ToString())
            };

                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.ToUpper())));

                var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key!));
                var issuer = _jwtConfiguration.Issuer.FirstOrDefault() ?? throw new InvalidOperationException("Issuer is not configured.");
                var token = new JwtSecurityToken(
                    issuer,
                    _jwtConfiguration.Audience,
                    expires: utility!.GetCurrentDateInTimeZone().AddDays(30),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                _logger.LogError("No roles found for user: {Email}", loginRequest.Email);
                throw new Exception("User has no assigned roles.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error generating access token for user: {loginRequest.Email}. Exception: {ex.Message}", this);
            throw; // Rethrow or return a specific error response
        }
    }

    public async Task<TokenDTO> GetNewToken(string refreshToken, string accountId)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var accessTokenNew = "";
            var refreshTokenNew = "";
            try
            {
                var accountRepository = Resolve<IRepository<Account>>();
                var utility = Resolve<Utility>();

                var user = await accountRepository!.GetByExpression(u => u!.Id.ToLower() == accountId);

                if (user != null && user.RefreshToken == refreshToken)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Email, user.Email),
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new("AccountId", user.Id)
                    };
                    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.ToUpper())));
                    var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key!));
                    var issuer = _jwtConfiguration.Issuer.FirstOrDefault() ?? throw new InvalidOperationException("Issuer is not configured.");
                    var token = new JwtSecurityToken(
                        issuer,
                        _jwtConfiguration.Audience,
                        expires: utility!.GetCurrentDateInTimeZone().AddDays(30),
                        claims: claims,
                        signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                    );

                    accessTokenNew = new JwtSecurityTokenHandler().WriteToken(token);
                    if (user.RefreshTokenExpiryTime <= utility.GetCurrentDateInTimeZone())
                    {
                        user.RefreshToken = GenerateRefreshToken();
                        user.RefreshTokenExpiryTime = utility.GetCurrentDateInTimeZone().AddDays(1);
                        refreshTokenNew = user.RefreshToken;
                    }
                    else
                    {
                        refreshTokenNew = refreshToken;
                    }
                }

                await _unitOfWork.SaveChangesAsync();
                scope.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, this);
            }

            return new TokenDTO { Token = accessTokenNew, RefreshToken = refreshTokenNew };
        }
    }
}