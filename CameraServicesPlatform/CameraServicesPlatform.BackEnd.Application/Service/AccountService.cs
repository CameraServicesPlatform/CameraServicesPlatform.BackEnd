using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
//using Firebase.Auth;
//using NPOI.SS.Formula.Functions;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service.Extension;
using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Utility = CameraServicesPlatform.BackEnd.Common.Utils.Utility;
 

namespace CameraServicesPlatform.BackEnd.Application.Service;


public class AccountService : GenericBackendService, IAccountService
{
    private readonly IRepository<Account> _accountRepository;
    private readonly IRepository<Supplier> _supplierRepository;
    private readonly IRepository<Staff> _staffRepository;
     private readonly IMapper _mapper;
    private readonly SignInManager<Account> _signInManager;
    private readonly TokenDTO _tokenDto;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Microsoft.AspNetCore.Identity.UserManager<Account> _userManager;
    private readonly IEmailService _emailService;
    private readonly IExcelService _excelService;
    private readonly IFileService _fileService;
    private readonly BackEndLogger _logger;
    private readonly IFirebaseService _firebaseService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly CameraServicesPlatformDbContext _context;

    public AccountService(
        IRepository<Account> accountRepository,
        IRepository<Supplier> supplierRepository,
        IRepository<Staff> staffRepository,
         IUnitOfWork unitOfWork,
        Microsoft.AspNetCore.Identity.UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IEmailService emailService,
        IExcelService excelService,
        IFileService fileService,
        IMapper mapper,
         BackEndLogger logger,
         IServiceProvider serviceProvider,
        IFirebaseService firebaseService,
        RoleManager<IdentityRole> roleManager,
        CameraServicesPlatformDbContext context

     ) : base(serviceProvider)
    {
        _accountRepository = accountRepository;
        _supplierRepository = supplierRepository;
        _staffRepository = staffRepository;
         _unitOfWork = unitOfWork;
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _excelService = excelService;
        _fileService = fileService;
        _tokenDto = new TokenDTO();
        _mapper = mapper;
        _logger = logger;
        _firebaseService = firebaseService;
        _roleManager = roleManager;
        _context = context;
    }
    public async Task<AppActionResult> AssignUserIntoSupplier(string userId, string supplierId)
    {
        var result = new AppActionResult();
        var supplierRepository = Resolve<IRepository<Supplier>>();  
        try
        {
            var accountDb = await _accountRepository.GetById(userId);
            if (accountDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy tài khoản với id {userId}");
                return result;
            }

            var supplierDb = await supplierRepository.GetById(supplierId);  
            if (supplierDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy nhà cung cấp với id {supplierId}"); 
                return result;
            }

            accountDb.SupplierID = supplierDb.SupplierID.ToString();  
            await _unitOfWork.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }
        return result;
    }
    private async Task<IdentityRole> GetIdentityRoleByName(string roleName)
    {
        return await _roleManager.FindByNameAsync(roleName);
    }
    public async Task<AppActionResult> GetAccountByUserId(string id)
    {

        var result = new AppActionResult();
        try
        {

            var account = await _accountRepository.GetById(id);
            if (account == null)
            {
                result = BuildAppActionResultError(result, $"Tài khoản với id {id} không tồn tại !");
                return result;
            }

            if (account.SupplierID != null)
            {
                 // Fetch supplier data using supplier repository
                var supplierGuid = Guid.Parse(account.SupplierID);
                var supplierDb = await _supplierRepository.GetByExpression(p => p.SupplierID == supplierGuid);
                if (supplierDb == null)
                {
                    result = BuildAppActionResultError(result, $"Nhà cung cấp với {account.SupplierID} không tồn tại");
                    return result;
                }
                account.Supplier = supplierDb;
            }
            else if (account.StaffID != null)
            {
                // Fetch staff data using staff repository
                var staffGuid = Guid.Parse(account.StaffID);
                var staffDb = await _staffRepository.GetByExpression(p => p.StaffID == staffGuid);
                if (staffDb == null)
                {
                    result = BuildAppActionResultError(result, $"Nhân Viên với {account.StaffID} không tồn tại");
                    return result;
                }

                account.Staff = staffDb;
            }

            result.Result = account;
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }


    public async Task<AppActionResult> AssignRole(string userId, string roleName)
    {
        AppActionResult result = new AppActionResult();
        try
        {
            var accountDb = await _accountRepository.GetById(userId);
            if (accountDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy tài khoản với id {userId}");
                return result;
            }
            var roleRepository = Resolve<IRepository<IdentityRole>>();

            var roleDb = await  GetIdentityRoleByName(roleName);
            if (roleDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy phân quyền với tên {roleName}");
                return result;
            }

            var userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            var roleListDb = await  GetRoleListByAccountId(userId);
            if (roleListDb.Count() != 0)
            {
                if (roleListDb.Contains(roleDb.Id))
                {
                    result = BuildAppActionResultError(result, $"Tài khoản với id {userId} đã có phân quyền {roleName}");
                    return result;
                }
            }

            bool isSuccessful = await  AssignRoleUser(userId, roleDb.Id);
            if (!isSuccessful)
            {
                result = BuildAppActionResultError(result, $"Thêm phân quyền không thành công, vui lòng thử lại sau");
                return result;
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }
        return result;
    }
    private async Task<List<string>> GetRoleListByAccountId(string accountId)
    {
        return await _context.Set<IdentityUserRole<string>>()
            .Where(ur => ur.UserId == accountId)
            .Select(ur => ur.RoleId)
            .ToListAsync();
    }
    private async Task<List<string>> GetRoleNameListById(List<string> roleIds)
    {
        // Fetch role names from the database based on the provided role IDs
        return await _context.Set<IdentityRole>()
            .Where(r => roleIds.Contains(r.Id))
            .Select(r => r.Name)
            .ToListAsync();
    }
    private async Task<bool> AssignRoleUser(string userId, string roleId)
    {
        var userRole = new IdentityUserRole<string>
        {
            UserId = userId,
            RoleId = roleId
        };

        await _context.UserRoles.AddAsync(userRole);
        return await _context.SaveChangesAsync() > 0;
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

        var roleListDb = await GetRoleListByAccountId(user.Id);

        // Call the newly defined method
        var roleNameList = await GetRoleNameListById(roleListDb);

        if (roleNameList.Contains("ADMIN"))
        {
            _tokenDto.MainRole = "ADMIN";
        }
        else if (roleNameList.Contains("STAFF"))
        {
            _tokenDto.MainRole = "STAFF";
        }
        else if (roleNameList.Count > 0)
        {
            _tokenDto.MainRole = roleNameList.FirstOrDefault(n => !n.Equals("MEMBER"));
        }
        else
        {
            _tokenDto.MainRole = "MEMBER";
        }

        result.Result = _tokenDto;
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<PagedResult<Supplier>> GetSupllier(int pageNumber, int pageSize)
    {
        PagedResult<Supplier> result = null;
        try
        {
            result = new PagedResult<Supplier>();
            result = await _supplierRepository.GetAllDataByExpression(
                filter: null,
                pageNumber: pageNumber,
                pageSize: pageSize
            );
        }
        catch (Exception ex)
        {
            result = null;
        }
        return result;
    }

    public async Task<PagedResult<Staff>> GetStaff(int pageNumber, int pageSize)
    {
        PagedResult<Staff> result = null;
        try
        {
            result = new PagedResult<Staff>();
            result = await _staffRepository.GetAllDataByExpression(
               filter: null,
               pageNumber: pageNumber,
               pageSize: pageSize
           );
        }
        catch (Exception ex)
        {
            result = null;
        }
        return result;
    }
    public async Task<bool> AssignStaffRole(List<Account> staffAccountList)
    {
        bool isSuccess = true;
        try
        {
            // Get the "staff" role
            var roleName = "staff";
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                // Optionally create the role if it does not exist
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded)
                {
                    // Handle role creation failure
                    isSuccess = false;
                    return isSuccess;
                }
            }

            // Assign role to each account
            foreach (var account in staffAccountList)
            {
                var accountDb = await _accountRepository.GetByExpression(a => a.PhoneNumber == account.PhoneNumber);
                if (accountDb != null)
                {
                    var result = await _userManager.AddToRoleAsync(accountDb, roleName);
                    if (!result.Succeeded)
                    {
                        isSuccess = false; // If one assignment fails, set success to false
                        break;
                    }
                }
                else
                {
                    isSuccess = false; // Account not found
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception with a message
            _logger.LogError("An error occurred while assigning staff roles.", ex);
        }
           


        return isSuccess;
    }

public async Task<AppActionResult> AddStaff(CreateStaffDTO dto)
    {
        AppActionResult result = new AppActionResult();
        try
        {
            // Validate the DTO if necessary
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.PhoneNumber))
            {
                result = BuildAppActionResultError(result, "Email and Phone Number are required.");
                return result;
            }

            // Create a new Account instance from the DTO
            var staffAccount = _mapper.Map<Account>(dto);
            staffAccount.Id = Guid.NewGuid().ToString();
            staffAccount.UserName = dto.Email; // Using Email as UserName
            staffAccount.IsDeleted = false;
            staffAccount.IsVerified = true;
            staffAccount.VerifyCode = null;

            // Upload the image and assign the URL to the Account
            string pathName = SD.FirebasePathName.STAFF_PREFIX + staffAccount.Id; // Update prefix to STAF_PREFIX
            var url = await _firebaseService.UploadFileToFirebase(dto.Img, pathName);
            if (url.IsSuccess)
            {
                staffAccount.Img = (string)url.Result;
            }
            else
            {
                result = BuildAppActionResultError(result, "Failed to upload staff image. Please try again.");
                return result;
            }

            // Create the user in Identity
            var resultCreateUser = await _userManager.CreateAsync(staffAccount, SD.DefaultAccountInformation.PASSWORD);
            if (!resultCreateUser.Succeeded)
            {
                result = BuildAppActionResultError(result, $"Account creation for staff {dto.Name} failed: {string.Join(", ", resultCreateUser.Errors.Select(e => e.Description))}");
                return result;
            }

            // Assign roles if necessary
            bool isSuccessful = await AssignStaffRole(new List<Account> { staffAccount }); // Update method to assign staff role
            if (isSuccessful)
            {
                // Insert the Staff entity into the database
                var staff = _mapper.Map<Staff>(dto);
                staff.AccountID = staffAccount.Id; // Link Staff with the created Account
                await _staffRepository.Insert(staff);
                await _unitOfWork.SaveChangesAsync();

                // Send account creation email for staff
                SendAccountCreationEmailForStaff(new List<Account> { staffAccount }); // Update method for staff email
                result.Result = staffAccount; // Set the result to the created staff account
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }
        return result;
    }
    public void SendAccountCreationEmailForStaff(List<Account> tourGuideAccountList)
    {
        try
        {
            foreach (var account in tourGuideAccountList)
            {
                _emailService?.SendEmail(account.Email, $"Account information for sponsor {account.FirstName} {account.LastName} at Camera-Service-Platform",
                   TemplateMappingHelper.GetTemplateOTPEmail(TemplateMappingHelper.ContentEmailType.STAFF_ACCOUNT_CREATION,
                       $"Username: {account.Email} \nPassword: {SD.DefaultAccountInformation.PASSWORD}\n Vui lòng không chia sẻ thông tin tài khoản của bạn với bất kì ai", $"{account.FirstName} {account.LastName}"));
            }
        }
        catch (Exception ex)
        {
        }
    }
    
    public async Task<AppActionResult> Login(LoginRequestDTO loginRequest)
    {
        var result = new AppActionResult();
        try
        {
            var user = await _accountRepository.GetAccountByEmail(loginRequest.Email, false, null);
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
            var user = await _accountRepository.GetAccountByEmail(email, false, null);
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
            if (await _accountRepository.GetAccountByEmail(signUpRequest.Email, null, null) != null)
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
                    Gender = signUpRequest.Gender,
                    VerifyCode = verifyCode,
                    IsVerified = isGoogle ? true : false
                };
                var resultCreateUser = await _userManager.CreateAsync(user, signUpRequest.Password);
                if (resultCreateUser.Succeeded)
                {
                    result.Result = user;
                    if (!isGoogle)
                    {
                        emailService!.SendEmail(user.Email, SD.SubjectMail.VERIFY_ACCOUNT,
                            TemplateMappingHelper.GetTemplateOTPEmail(
                                TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE, verifyCode,
                                user.FirstName));
                    }
                    else
                    {
                        emailService!.SendEmail(user.Email, SD.SubjectMail.WELCOME,
                            $"Welcome {user.FirstName}, thank you for signing up with Google!");
                    }
                }
                else
                {
                    result = BuildAppActionResultError(result, $"Tạo tài khoản không thành công");
                }

                var resultCreateRole = await _userManager.AddToRoleAsync(user, "MEMBER");
                if (!resultCreateRole.Succeeded) result = BuildAppActionResultError(result, $"Cấp quyền THÀNH VIÊN không thành công");
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }


    public async Task<AppActionResult> UpdateAccount(UpdateAccountRequestDTO accountRequest)
    {
        var result = new AppActionResult();
        try
        {
            var account =
                await _accountRepository.GetAccountByEmail(accountRequest.Email, null, null);
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

            if (userRole.Where(u => u.Name.Equals("ADMIN")).FirstOrDefault() != null)
            {
                item.MainRole = "ADMIN";
            }
            else if (userRole.Where(u => u.Name.Equals("SUPPLIER")).FirstOrDefault() != null)
            {
                item.MainRole = "SUPPLIER";
            }
            else if (userRole.Where(u => u.Name.Equals("STAFF")).FirstOrDefault() != null)
            {
                item.MainRole = "STAFF";
            }
            else if (userRole.Count > 0)
            {
                item.MainRole = userRole.FirstOrDefault(n => !n.Equals("MEMBER")).Name;
            }
            else
            {
                item.MainRole = "MEMBER";
            }
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
            var user = await _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user == null || (user != null && user.IsDeleted))
                result = BuildAppActionResultError(result,
                    $"Tài khoản có email {changePasswordDto.Email} không tồn tại!");
            if (!BuildAppActionResultIsError(result))
            {
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
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || (user != null && user.IsDeleted))
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
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || (user != null && user.IsDeleted))
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");
            else if (user.VerifyCode != verifyCode)
                result = BuildAppActionResultError(result, "Mã xác thực sai!");

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
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || (user != null && user.IsDeleted))
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");

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
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || (user != null && user.IsDeleted))
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");

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

        var user = await _userManager.FindByEmailAsync(email);
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
                                Gender = Domain.Enum.Gender.Male,
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
 
    private string EncryptData(string data, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            aes.IV = new byte[16]; // Assuming a zero IV for simplicity
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var ms = new System.IO.MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var sw = new System.IO.StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
     
    private string DecryptData(string encryptedData, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = new byte[16];
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;// Assuming a zero IV for simplicity
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream(Convert.FromBase64String(encryptedData)))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }

    


}
