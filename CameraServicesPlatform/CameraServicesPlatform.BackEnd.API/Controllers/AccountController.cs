using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;


[Route("account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(
        IAccountService accountService
    )
    {
        _accountService = accountService;
    }

    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] SignUpRequestDTO signUpRequest, [FromQuery] bool isGoogle = false)
    {
        var result = await _accountService.CreateAccount(signUpRequest, isGoogle);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("get-all-account")]
    public async Task<AppActionResult> GetAllAccount(int pageIndex = 1, int pageSize = 10)
    {
        return await _accountService.GetAllAccount(pageIndex, pageSize);
    }

    [HttpGet("get-accounts-by-role-name/{roleName}/{pageIndex:int}/{pageSize:int}")]
    public async Task<AppActionResult> GetAccountsByRoleName(string roleName, int pageIndex = 1, int pageSize = 10)
    {
        return await _accountService.GetAccountsByRoleName(roleName, pageIndex, pageSize);
    }

    [HttpGet("get-accounts-by-role-id/{roleId}/{pageIndex:int}/{pageSize:int}")]
    public async Task<AppActionResult> GetAccountsByRoleId(string roleId, int pageIndex = 1, int pageSize = 10)
    {
        return await _accountService.GetAccountsByRoleId(roleId, pageIndex, pageSize);
    }

    [HttpPut("update-account")]
    public async Task<AppActionResult> UpdateAccount(UpdateAccountRequestDTO request)
    {
        return await _accountService.UpdateAccount(request);
    }

    [HttpPost("get-account-by-userId/{id}")]
    public async Task<AppActionResult> GetAccountByUserId(string id)
    {
        return await _accountService.GetAccountByUserId(id);
    }


    [HttpPost("login")]
    public async Task<AppActionResult> Login(LoginRequestDTO request)
    {
        return await _accountService.Login(request);
    }

    [HttpPut("change-password")]
    public async Task<AppActionResult> ChangePassword(ChangePasswordDTO DTO)
    {
        return await _accountService.ChangePassword(DTO);
    }

    [HttpPost("get-new-token/{userId}")]
    public async Task<AppActionResult> GetNewToken([FromBody] string refreshToken, string userId)
    {
        return await _accountService.GetNewToken(refreshToken, userId);
    }

    [HttpPut("forgot-password")]
    public async Task<AppActionResult> ForgotPassword(ForgotPasswordDTO DTO)
    {
        return await _accountService.ForgotPassword(DTO);
    }

    [HttpPut("active-account/{email}/{verifyCode}")]
    public async Task<AppActionResult> ActiveAccount(string email, string verifyCode)
    {
        return await _accountService.ActiveAccount(email, verifyCode);
    }

    [HttpPost("send-email-forgot-password/{email}")]
    public async Task<AppActionResult> SendEmailForgotPassword(string email)
    {
        return await _accountService.SendEmailForgotPassword(email);
    }

    [HttpPost("send-email-for-activeCode/{email}")]
    public async Task<AppActionResult> SendEmailForActiveCode(string email)
    {
        return await _accountService.SendEmailForActiveCode(email);
    }

    [HttpPost("google-callback")]
    public async Task<AppActionResult> GoogleCallBack([FromBody] string accessTokenFromGoogle)
    {
        return await _accountService.GoogleCallBack(accessTokenFromGoogle);
    }


    [HttpPost("generate-otp")]
    public async Task<AppActionResult> GenerateOTP([FromBody] string phoneNumber)
    {
        return await _accountService.GenerateOTP(phoneNumber);
    }

}