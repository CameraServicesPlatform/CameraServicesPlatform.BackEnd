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

    [HttpPost("login")]
    public async Task<AppActionResult> Login(LoginRequestDTO request)
    {
        return await _accountService.Login(request);
    }
    [HttpPost("create-account")]
    public async Task<AppActionResult> CreateAccount(SignUpRequestDTO request)
    {
        return await _accountService.CreateAccount(request, false);
    }
    [HttpPost("register/supplier")]
    public async Task<AppActionResult> RegisterSupplier(CreateSupplierAccountDTO dto)
    {
        return await _accountService.CreateAccountSupplier(dto, false);
    }
    [HttpPost("check-active-by-staff-send-email")]
    public async Task<AppActionResult> CheckActiveByStaff(string AccountID, bool isGoogle)
    {
        return await _accountService.CheckActiveByStaff(AccountID, isGoogle);
    }

    [HttpPost("create-staff")]
    public async Task<AppActionResult> CreateStaff(CreateStaffDTO request)
    {
        return await _accountService.AddStaff(request);
    }

    [HttpPost("get-account-by-userId/{id}")]
    public async Task<AppActionResult> GetAccountByUserId(string id)
    {
        return await _accountService.GetAccountByUserId(id);
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

    [HttpPost("assign-role")]
    public async Task<AppActionResult> AssignRole(string userId, string roleName)
    {
        return await _accountService.AssignRole(userId, roleName);
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
    [HttpPost("assign-user-into-staff")]
    public async Task<IActionResult> AssignUserIntoStaff(string userId, string staffId)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(staffId))
        {
            return BadRequest("User ID and Staff ID cannot be null or empty.");
        }

        AppActionResult result = await _accountService.AssignUserIntoStaff(userId, staffId);

        return result == null ? StatusCode(500, "An error occurred while processing your request.") : (IActionResult)Ok(result);
    }


    [HttpGet("get-supplier-id-by-account-id/{accountId}")]
    public async Task<AppActionResult> GetSupplierIDByAccountID(string accountId)
    {
        return await _accountService.GetSupplierIDByAccountID(accountId);
    }

    [HttpPut("update-account")]
    public async Task<AppActionResult> UpdateAccount(UpdateAccountRequestDTO request)
    {
        return await _accountService.UpdateAccount(request);
    }
    [HttpPost("get-new-token/{userId}")]
    public async Task<AppActionResult> GetNewToken([FromBody] string refreshToken, string userId)
    {
        return await _accountService.GetNewToken(refreshToken, userId);
    }

    [HttpPut("change-password")]
    public async Task<AppActionResult> ChangePassword(ChangePasswordDTO dto)
    {
        return await _accountService.ChangePassword(dto);
    }


    [HttpPut("forgot-password")]
    public async Task<AppActionResult> ForgotPassword(ForgotPasswordDTO dto)
    {
        return await _accountService.ForgotPassword(dto);
    }

    [HttpPut("active-account/{email}/{verifyCode}")]
    public async Task<AppActionResult> ActiveAccount(string email, string verifyCode)
    {
        return await _accountService.ActiveAccount(email, verifyCode);
    }

    [HttpPost("remove-role")]
    public async Task<IActionResult> RemoveRoleForUserId(string userId, [FromBody] IList<string> roleIds)
    {
        if (string.IsNullOrEmpty(userId) || roleIds == null || roleIds.Count == 0)
        {
            return BadRequest("User ID and Role IDs cannot be null or empty.");
        }

        AppActionResult result = await _accountService.RemoveRoleForUserId(userId, roleIds);

        if (result == null)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }

        return Ok(result);
    }


}