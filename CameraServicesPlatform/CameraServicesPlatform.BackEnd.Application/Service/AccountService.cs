using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
//using Firebase.Auth;
//using NPOI.SS.Formula.Functions;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Utility = CameraServicesPlatform.BackEnd.Common.Utils.Utility;

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
    private readonly BackEndLogger _logger;  

    public AccountService(
        IRepository<Account> accountRepository,
        IUnitOfWork unitOfWork,
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IEmailService emailService,
        IExcelService excelService,
        IFileService fileService,
        IMapper mapper,
         BackEndLogger logger,
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
        _logger = logger;
    }

    public async Task<AppActionResult> CreateAccount(SignUpRequestDTO signUpRequest, bool isGoogle)
    {
        var result = new AppActionResult();
        try
        {
            // Check if the email or username already exists
            if (await _accountRepository.GetByExpression(r => r!.UserName == signUpRequest.Email) != null)
                result = BuildAppActionResultError(result, "Email hoặc username đã tồn tại!");

            if (!BuildAppActionResultIsError(result))
            {
                var emailService = Resolve<IEmailService>();
                var verifyCode = string.Empty;
                if (!isGoogle) verifyCode = Guid.NewGuid().ToString("N").Substring(0, 6);

                // Create the new user
                var user = new Account
                {
                    Email = signUpRequest.Email,
                    UserName = signUpRequest.Email,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    PhoneNumber = signUpRequest.PhoneNumber,
                    Gender = signUpRequest.Gender,
                    VerifyCode = verifyCode,
                    IsVerified = isGoogle
                };

                var resultCreateUser = await _userManager.CreateAsync(user, signUpRequest.Password);
                if (resultCreateUser.Succeeded)
                {
                    result.Result = user;

                    // Send verification email if not using Google sign-in
                    if (!isGoogle)
                    {
                        await emailService.SendEmailAsync(user.Email, SD.SubjectMail.VERIFY_ACCOUNT,
                            TemplateMappingHelper.GetTemplateOTPEmail(
                                TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE, verifyCode,
                                user.FirstName));
                    }
                }
                else
                {
                    result = BuildAppActionResultError(result, "Tạo tài khoản không thành công");
                }

                // Add user to 'MEMBER' role
                var resultCreateRole = await _userManager.AddToRoleAsync(user, "MEMBER");
                if (!resultCreateRole.Succeeded)
                    result = BuildAppActionResultError(result, "Cấp quyền thành viên không thành công");

                // Add user to MemberInformation table
                bool customerAdded = await AddMemberInformation(user);
                if (!customerAdded)
                {
                    result = BuildAppActionResultError(result, "Tạo thông tin thành viên không thành công");
                }
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    private async Task<bool> AddMemberInformation(Account user)
    {
        bool isSuccessful = false;
        try
        {
            var member = new Member
            {
                MemberID = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = "",
                Dob = DateTime.MinValue,
                AccountID = user.Id,
                IsAdult = true,
                IsVerfiedPhoneNumber = true,
                IsVerifiedEmail = true,
                Gender = user.Gender,
                Money = 0
            };

            var memberRepository = Resolve<IRepository<Member>>();
            await memberRepository!.Insert(member);
            await _unitOfWork.SaveChangesAsync();

            isSuccessful = true; // Mark success
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to add member information: {ex.Message}", this);
            isSuccessful = false;
        }
        return isSuccessful;
    }

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
                                Gender = Domain.Enum.Gender.Female,
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

    public async Task<AppActionResult> GetAccountsByRoleId(string Id, int pageNumber, int pageSize)
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
        //var response = await smsService!.SendMessage($"Mã xác thực tại hệ thống Cóc Travel của bạn là {code}",
        //phoneNumber);

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
    // checked 
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

    public async Task<AppActionResult> Login(LoginRequestDTO loginRequest)
    {
        var result = new AppActionResult();

        try
        {
            // Lấy thông tin người dùng dựa trên email
            var user = await _accountRepository.GetByExpression(u =>
                u.Email.ToLower() == loginRequest.Email.ToLower() && !u.IsDeleted);

            if (user == null)
            {
                result = BuildAppActionResultError(result, "Không tìm thấy người dùng.");
                return result;
            }

            // Kiểm tra xem tài khoản đã được xác thực chưa
            if (!user.IsVerified)
            {
                result = BuildAppActionResultError(result, "Tài khoản chưa được xác thực.");
                return result;
            }

            // Xác thực mật khẩu bằng SignInManager
            var passwordSignIn = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
            if (!passwordSignIn.Succeeded)
            {
                result = BuildAppActionResultError(result, "Mật khẩu không hợp lệ.");
                return result;
            }

            // Tiến hành các thao tác đăng nhập
            result = await LoginDefault(loginRequest.Email, user);
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

}

