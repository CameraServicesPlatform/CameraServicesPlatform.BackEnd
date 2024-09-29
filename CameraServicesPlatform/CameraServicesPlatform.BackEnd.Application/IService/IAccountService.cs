using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;


namespace CameraServicesPlatform.BackEnd.Application.IService;

public interface IAccountService
{
    Task<AppActionResult> CreateAccount(SignUpRequestDTO signUpRequest, bool isGoogle);

    //check
    Task<AppActionResult> GetAllAccount(int pageIndex, int pageSize);

    //no check 
    Task<AppActionResult> Login(LoginRequestDTO loginRequest);

    public Task<AppActionResult> VerifyLoginGoogle(string email, string verifyCode);



    Task<AppActionResult> UpdateAccount(UpdateAccountRequestDTO applicationUser);

    Task<AppActionResult> ChangePassword(ChangePasswordDTO changePasswordDto);

    Task<AppActionResult> GetAccountByUserId(string id);



    Task<AppActionResult> GetNewToken(string refreshToken, string userId);

    Task<AppActionResult> ForgotPassword(ForgotPasswordDTO dto);

    Task<AppActionResult> ActiveAccount(string email, string verifyCode);

    Task<AppActionResult> SendEmailForgotPassword(string email);

    Task<string> GenerateVerifyCode(string email, bool isForForgettingPassword);

    Task<AppActionResult> GoogleCallBack(string accessTokenFromGoogle);

    public Task<AppActionResult> SendEmailForActiveCode(string email);

    public Task<AppActionResult> GetAccountsByRoleName(string roleName, int pageNumber, int pageSize);
    public Task<AppActionResult> GetAccountsByRoleId(string Id, int pageNumber, int pageSize);
    public Task<AppActionResult> GenerateOTP(string phoneNumber);


}