using AutoMapper;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

using Utility = CameraServicesPlatform.BackEnd.Common.Utils.Utility;
//using Firebase.Auth;
using StackExchange.Redis;
//using NPOI.SS.Formula.Functions;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;

namespace CameraServicesPlatform.BackEnd.Application.Service;

public class AccountService : GenericBackendService, IAccountService
{
    private readonly IRepository<Account> _accountRepository;
    private readonly IMapper _mapper;
    private readonly SignInManager<Account> _signInManager;
    private readonly TokenDTO _tokenDto;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Account> _userManager;
    private readonly IEmailService _emailService;
    private readonly IExcelService _excelService;
    private readonly IFileService _fileService;
    public AccountService(
        IRepository<Account> accountRepository,
        IUnitOfWork unitOfWork,
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IEmailService emailService,
        IExcelService excelService,
        IFileService fileService,
        IMapper mapper, 
        IServiceProvider serviceProvider
    ) : base(serviceProvider)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _excelService = excelService;
        _fileService = fileService;
        _tokenDto = new TokenDTO();
        _mapper = mapper;
    }

    public async Task<AppActionResult> Login(LoginRequestDTO loginRequest)
    {
        var result = new AppActionResult();
        try
        {
            var user = await _accountRepository.GetByExpression(u =>
                u!.Email.ToLower() == loginRequest.Email.ToLower() && u.IsDeleted == false);
            if (user == null)
                result = BuildAppActionResultError(result, $" {loginRequest.Email} này không tồn tại trong hệ thống");
            else if (user.IsVerified == false)
                result = BuildAppActionResultError(result, "Tài khoản này chưa được xác thực !");

            var passwordSignIn =
                await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
            if (!passwordSignIn.Succeeded) result = BuildAppActionResultError(result, "Đăng nhâp thất bại");
            if (!BuildAppActionResultIsError(result)) result = await LoginDefault(loginRequest.Email, user);
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> VerifyLoginGoogle(string email, string verifyCode)
    {
        var result = new AppActionResult();
        try
        {
            var user = await _accountRepository.GetByExpression(u =>
                u!.Email.ToLower() == email.ToLower() && u.IsDeleted == false);
            if (user == null)
                result = BuildAppActionResultError(result, $"Email này không tồn tại");
            else if (user.IsVerified == false)
                result = BuildAppActionResultError(result, "Tài khoản này chưa xác thực !");
            else if (user.VerifyCode != verifyCode)
                result = BuildAppActionResultError(result, "Mã xác thực sai!");

            if (!BuildAppActionResultIsError(result))
            {
                result = await LoginDefault(email, user);
                user!.VerifyCode = null;
                await _unitOfWork.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> CreateAccount(SignUpRequestDTO signUpRequest, bool isGoogle)
    {
        var result = new AppActionResult();
        try
        {
            if (await _accountRepository.GetByExpression(r => r!.UserName == signUpRequest.Email) != null)
                result = BuildAppActionResultError(result, "Email hoặc username không tồn tại!");

            if (!BuildAppActionResultIsError(result))
            {
                var emailService = Resolve<IEmailService>();
                var verifyCode = string.Empty;
                if (!isGoogle) verifyCode = Guid.NewGuid().ToString("N").Substring(0, 6);

                var user = new Account
                {
                    Email = signUpRequest.Email,
                    UserName = signUpRequest.Email,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    PhoneNumber = signUpRequest.PhoneNumber,
                    //Gender = signUpRequest.Gender.,
                    VerifyCode = verifyCode,
                    IsVerified = isGoogle ? true : false
                };
                var resultCreateUser = await _userManager.CreateAsync(user, signUpRequest.Password);
                if (resultCreateUser.Succeeded)
                {
                    result.Result = user;
                    if (!isGoogle)
                        emailService!.SendEmail(user.Email, SD.SubjectMail.VERIFY_ACCOUNT,
                            TemplateMappingHelper.GetTemplateOTPEmail(
                                TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE, verifyCode,
                                user.FirstName));
                }
                else
                {
                    result = BuildAppActionResultError(result, $"Tạo tài khoản không thành công");
                }

                //var resultCreateRole = await _userManager.AddToRoleAsync(user, "CUSTOMER");
                //if (!resultCreateRole.Succeeded) result = BuildAppActionResultError(result, $"Cấp quyền khách hàng không thành công");
                //bool customerAdded = await AddCustomerInformation(user);
                //if (!customerAdded)
                //{
                //    result = BuildAppActionResultError(result, $"Tạo thông tin khách hàng không thành công");
                //}
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    //private async Task<bool> AddCustomerInformation(Account user)
    //{
    //    bool isSuccessful = false;
    //    try
    //    {
    //        var customer = new Member
    //        {
    //            AccountID = user.Id,


    //        };
    //        var customerRepository = Resolve<IRepository<Member>>();
    //        await customerRepository!.Insert(customer);
    //        await _unitOfWork.SaveChangesAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        isSuccessful = false;
    //    }
    //    return isSuccessful;
    //}

    public async Task<AppActionResult> UpdateAccount(UpdateAccountRequestDTO accountRequest)
    {
        var result = new AppActionResult();
        try
        {
            var account =
                await _accountRepository.GetByExpression(
                    a => a!.UserName.ToLower() == accountRequest.Email.ToLower());
            if (account == null)
                result = BuildAppActionResultError(result, $"Tài khoản với email {accountRequest.Email} không tồn tại!");
            if (!BuildAppActionResultIsError(result))
            {
                account!.FirstName = accountRequest.FirstName;
                account.LastName = accountRequest.LastName;
                account.PhoneNumber = accountRequest.PhoneNumber;
                result.Result = await _accountRepository.Update(account);
            }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> GetAccountByUserId(string id)
    {
        var result = new AppActionResult();
        try
        {
            var account = await _accountRepository.GetById(id);
            if (account == null) result = BuildAppActionResultError(result, $"Tài khoản với id {id} không tồn tại !");
            if (!BuildAppActionResultIsError(result)) result.Result = account;
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> GetAllAccount(int pageIndex, int pageSize)
    {
        var result = new AppActionResult();
        var list = await _accountRepository.GetAllDataByExpression(null, pageIndex, pageSize, null, false, null);

        var userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
        var roleRepository = Resolve<IRepository<IdentityRole>>();
        var listRole = await roleRepository!.GetAllDataByExpression(null, 1, 100, null, false, null);
        var listMap = _mapper.Map<List<AccountResponse>>(list.Items);
        foreach (var item in listMap)
        {
            var userRole = new List<IdentityRole>();
            var role = await userRoleRepository!.GetAllDataByExpression(a => a.UserId == item.Id, 1, 100, null, false, null);
            foreach (var itemRole in role.Items!)
            {
                var roleUser = listRole.Items!.ToList().FirstOrDefault(a => a.Id == itemRole.RoleId);
                if (roleUser != null) userRole.Add(roleUser);
            }

            item.Role = userRole;
        }

        result.Result =
            new PagedResult<AccountResponse>
            { Items = listMap, TotalPages = list.TotalPages };
        return result;
    }

    public async Task<AppActionResult> ChangePassword(ChangePasswordDTO changePasswordDto)
    {
        var result = new AppActionResult();

        try
        {
            if (await _accountRepository.GetByExpression(c =>
                    c!.Email == changePasswordDto.Email && c.IsDeleted == false) == null)
                result = BuildAppActionResultError(result,
                    $"Tài khoản có email {changePasswordDto.Email} không tồn tại!");
            if (!BuildAppActionResultIsError(result))
            {
                var user = await _accountRepository.GetByExpression(c =>
                    c!.Email == changePasswordDto.Email && c.IsDeleted == false);
                var changePassword = await _userManager.ChangePasswordAsync(user!, changePasswordDto.OldPassword,
                    changePasswordDto.NewPassword);
                if (!changePassword.Succeeded)
                    result = BuildAppActionResultError(result, "Thay đổi mật khẩu thất bại");
            }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> GetNewToken(string refreshToken, string userId)
    {
        var result = new AppActionResult();

        try
        {
            var user = await _accountRepository.GetById(userId);
            if (user == null)
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại");
            else if (user.RefreshToken != refreshToken)
                result = BuildAppActionResultError(result, "Mã làm mới không chính xác");

            if (!BuildAppActionResultIsError(result))
            {
                var jwtService = Resolve<IJwtService>();
                result.Result = await jwtService!.GetNewToken(refreshToken, userId);
            }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> ForgotPassword(ForgotPasswordDTO dto)
    {
        var result = new AppActionResult();

        try
        {
            var user = await _accountRepository.GetByExpression(a =>
                a!.Email == dto.Email && a.IsDeleted == false && a.IsVerified == true);
            if (user == null)
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");
            else if (user.VerifyCode != dto.RecoveryCode)
                result = BuildAppActionResultError(result, "Mã xác thực sai!");

            if (!BuildAppActionResultIsError(result))
            {
                await _userManager.RemovePasswordAsync(user!);
                var addPassword = await _userManager.AddPasswordAsync(user!, dto.NewPassword);
                if (addPassword.Succeeded)
                    user!.VerifyCode = null;
                else
                    result = BuildAppActionResultError(result, "Thay đổi mật khẩu thất bại. Vui lòng thử lại");
            }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> ActiveAccount(string email, string verifyCode)
    {
        var result = new AppActionResult();
        try
        {
            var user = await _accountRepository.GetByExpression(a =>
                a!.Email == email && a.IsDeleted == false && a.IsVerified == false);
            if (user == null)
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại ");
            else if (user.VerifyCode != verifyCode)
                result = BuildAppActionResultError(result, "Mã xác thực sai");

            if (!BuildAppActionResultIsError(result))
            {
                user!.IsVerified = true;
                user.VerifyCode = null;
            }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> SendEmailForgotPassword(string email)
    {
        var result = new AppActionResult();

        try
        {
            var user = await _accountRepository.GetByExpression(a =>
                a!.Email == email && a.IsDeleted == false && a.IsVerified == true);
            if (user == null) result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực");

            if (!BuildAppActionResultIsError(result))
            {
                var emailService = Resolve<IEmailService>();
                var code = await GenerateVerifyCode(user!.Email, true);
                emailService?.SendEmail(email, SD.SubjectMail.PASSCODE_FORGOT_PASSWORD,
                    TemplateMappingHelper.GetTemplateOTPEmail(TemplateMappingHelper.ContentEmailType.FORGOTPASSWORD,
                        code, user.FirstName!));
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> SendEmailForActiveCode(string email)
    {
        var result = new AppActionResult();

        try
        {
            var user = await _accountRepository.GetByExpression(a =>
                a!.Email == email && a.IsDeleted == false && a.IsVerified == false);
            if (user == null) result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa xác thực");

            if (!BuildAppActionResultIsError(result))
            {
                var emailService = Resolve<IEmailService>();
                var code = await GenerateVerifyCode(user!.Email, false);
                emailService!.SendEmail(email, SD.SubjectMail.VERIFY_ACCOUNT,
                    TemplateMappingHelper.GetTemplateOTPEmail(TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE,
                        code, user.FirstName!));
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<string> GenerateVerifyCode(string email, bool isForForgettingPassword)
    {
        var code = string.Empty;

        var user = await _accountRepository.GetByExpression(a =>
            a!.Email == email && a.IsDeleted == false && a.IsVerified == isForForgettingPassword);

        if (user != null)
        {
            code = Guid.NewGuid().ToString("N").Substring(0, 6);
            user.VerifyCode = code;
        }

        await _unitOfWork.SaveChangesAsync();

        return code;
    }

    public async Task<AppActionResult> GoogleCallBack(string accessTokenFromGoogle)
    {
        var result = new AppActionResult();
        try
        {
            var existingFirebaseApp = FirebaseApp.DefaultInstance;
            if (existingFirebaseApp == null)
            {
                var config = Resolve<FirebaseAdminSDK>();
                var credential = GoogleCredential.FromJson(JsonConvert.SerializeObject(new
                {
                    type = config!.Type,
                    project_id = config.Project_id,
                    private_key_id = config.Private_key_id,
                    private_key = config.Private_key,
                    client_email = config.Client_email,
                    client_id = config.Client_id,
                    auth_uri = config.Auth_uri,
                    token_uri = config.Token_uri,
                    auth_provider_x509_cert_url = config.Auth_provider_x509_cert_url,
                    client_x509_cert_url = config.Client_x509_cert_url
                }));
                var firebaseApp = FirebaseApp.Create(new AppOptions
                {
                    Credential = credential
                });
            }

            var verifiedToken = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance
                .VerifyIdTokenAsync(accessTokenFromGoogle);
            var emailClaim = verifiedToken.Claims.FirstOrDefault(c => c.Key == "email");
            var nameClaim = verifiedToken.Claims.FirstOrDefault(c => c.Key == "name");
            var name = nameClaim.Value.ToString();
            var userEmail = emailClaim.Value.ToString();

            if (userEmail != null)
            {
                var user = await _accountRepository.GetByExpression(a => a!.Email == userEmail && a.IsDeleted == false);
                if (user == null)
                {
                    var resultCreate =
                        await CreateAccount(
                            new SignUpRequestDTO
                            {
                                Email = userEmail,
                                FirstName = name!,
                                Gender = true,
                                LastName = string.Empty,
                                Password = "Google123@",
                                PhoneNumber = string.Empty
                            }, true);
                    if (resultCreate.IsSuccess)
                    {
                        var account = (Account)resultCreate.Result!;
                        result = await LoginDefault(userEmail, account);
                    }
                }

                result = await LoginDefault(userEmail, user);
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    private async Task<AppActionResult> LoginDefault(string email, Account? user)
    {
        var result = new AppActionResult();

        var jwtService = Resolve<IJwtService>();
        var utility = Resolve<Utility>();
        var token = await jwtService!.GenerateAccessToken(new LoginRequestDTO { Email = email });

        if (user!.RefreshToken == null)
        {
            user.RefreshToken = jwtService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = utility!.GetCurrentDateInTimeZone().AddDays(1);
        }

        if (user.RefreshTokenExpiryTime <= utility!.GetCurrentDateInTimeZone())
        {
            user.RefreshTokenExpiryTime = utility.GetCurrentDateInTimeZone().AddDays(1);
            user.RefreshToken = jwtService.GenerateRefreshToken();
        }

        _tokenDto.Token = token;
        _tokenDto.RefreshToken = user.RefreshToken;
        result.Result = _tokenDto;
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<AppActionResult> AssignRoleForUserId(string userId, IList<string> roleId)
    {
        var result = new AppActionResult();
        try
        {
            var user = await _accountRepository.GetById(userId);
            var userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            var identityRoleRepository = Resolve<IRepository<IdentityRole>>();
            foreach (var role in roleId)
                if (await identityRoleRepository!.GetById(role) == null)
                    result = BuildAppActionResultError(result, $"Vai trò với id {role} không tồn tại");

            if (!BuildAppActionResultIsError(result))
                foreach (var role in roleId)
                {
                    var roleDb = await identityRoleRepository!.GetById(role);
                    var resultCreateRole = await _userManager.AddToRoleAsync(user, roleDb.NormalizedName);
                    if (!resultCreateRole.Succeeded)
                        result = BuildAppActionResultError(result, $"Cấp quyền với vai trò {role} không thành công");
                }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> RemoveRoleForUserId(string userId, IList<string> roleId)
    {
        var result = new AppActionResult();

        try
        {
            var user = await _accountRepository.GetById(userId);
            var userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            var identityRoleRepository = Resolve<IRepository<IdentityRole>>();
            if (user == null)
                result = BuildAppActionResultError(result, $"Người dùng với {userId} không tồn tại");
            foreach (var role in roleId)
                if (await identityRoleRepository.GetById(role) == null)
                    result = BuildAppActionResultError(result, $"Vai trò với {role} không tồn tại");

            if (!BuildAppActionResultIsError(result))
                foreach (var role in roleId)
                {
                    var roleDb = await identityRoleRepository!.GetById(role);
                    var resultCreateRole = await _userManager.RemoveFromRoleAsync(user!, roleDb.NormalizedName);
                    if (!resultCreateRole.Succeeded)
                        result = BuildAppActionResultError(result, $"Xóa quyền {role} thất bại");
                }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

     
    public async Task<AppActionResult> GetAccountsByRoleName(string roleName, int pageNumber, int pageSize)
    {
        var result = new AppActionResult();

        try
        {
            var roleRepository = Resolve<IRepository<IdentityRole>>();
            var roleDb = await roleRepository!.GetByExpression(r => r.NormalizedName.Equals(roleName.ToLower()));
            if (roleDb != null)
            {
                var userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
                var userRoleDb = await userRoleRepository!.GetAllDataByExpression(u => u.RoleId == roleDb.Id, 0, 0, null, false, null);
                if (userRoleDb.Items != null && userRoleDb.Items.Count > 0)
                {
                    var accountIds = userRoleDb.Items.Select(u => u.UserId).Distinct().ToList();
                    var accountDb = await _accountRepository.GetAllDataByExpression(a => accountIds.Contains(a.Id), pageNumber, pageSize, null, false, null);
                    result.Result = accountDb;
                }
            }
            else
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy vai trò {roleName}");
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> GetAccountsByRoleId(Guid Id, int pageNumber, int pageSize)
    {
        var result = new AppActionResult();

        try
        {
            var roleRepository = Resolve<IRepository<IdentityRole>>();
            var roleDb = await roleRepository!.GetById(Id);
            if (roleDb != null)
            {
                var userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
                var userRoleDb = await userRoleRepository!.GetAllDataByExpression(u => u.RoleId == roleDb.Id, 0, 0, null, false, null);
                if (userRoleDb.Items != null && userRoleDb.Items.Count > 0)
                {
                    var accountIds = userRoleDb.Items.Select(u => u.UserId).Distinct().ToList();
                    var accountDb = await _accountRepository.GetAllDataByExpression(a => accountIds.Contains(a.Id), pageNumber, pageSize, null, false, null);
                    result.Result = accountDb;
                }
            }
            else
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy vai trò với id {Id}");
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }


    public async Task<AppActionResult> GenerateOTP(string phoneNumber)
    {
        AppActionResult result = new AppActionResult();
        var code = Guid.NewGuid().ToString("N").Substring(0, 6);
        //var smsService = Resolve<ISmsService>();
        //var response = await smsService!.SendMessage($"Mã xác thực tại hệ thống Camera-Service-Platform của bạn là {code}",
        //    phoneNumber);

        //if (response.IsSuccess)
        //{
        //    result.Result = code;
        //}
        //else
        //{
        //    foreach (var error in response.Messages)
        //    {
        //        result.Messages.Add(error);
        //    }
        //}


        return result;
    }

}
