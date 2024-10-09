using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;


namespace CameraServicesPlatform.BackEnd.Application.IService;

public interface IAccountService
{
    public Task<AppActionResult> CreateAccountSupplier(CreateSupplierAccountDTO dto, bool isGoogle);

    Task<AppActionResult> Login(LoginRequestDTO loginRequest);

    public Task<AppActionResult> VerifyLoginGoogle(string email, string verifyCode);

    Task<AppActionResult> CreateAccount(SignUpRequestDTO signUpRequest, bool isGoogle);

    Task<AppActionResult> UpdateAccount(UpdateAccountRequestDTO applicationUser);

    Task<AppActionResult> ChangePassword(ChangePasswordDTO changePasswordDto);

    Task<AppActionResult> GetAccountByUserId(string id);

    Task<AppActionResult> GetAllAccount(int pageIndex, int pageSize);

    Task<AppActionResult> GetNewToken(string refreshToken, string userId);

    Task<AppActionResult> ForgotPassword(ForgotPasswordDTO dto);

    Task<AppActionResult> ActiveAccount(string email, string verifyCode);

    Task<AppActionResult> SendEmailForgotPassword(string email);

    Task<string> GenerateVerifyCode(string email, bool isForForgettingPassword);

    Task<AppActionResult> GoogleCallBack(string accessTokenFromGoogle);

    public Task<AppActionResult> SendEmailForActiveCode(string email);

    public Task<AppActionResult> GetAccountsByRoleName(string roleName, int pageNumber, int pageSize);

    public Task<AppActionResult> GetAccountsByRoleId(Guid Id, int pageNumber, int pageSize);

    public Task<AppActionResult> AssignRole(string userId, string roleName);

    public Task<PagedResult<Supplier>> GetSupllier(int pageNumber, int pageSize);
    public Task<PagedResult<Staff>> GetStaff(int pageNumber, int pageSize);





}