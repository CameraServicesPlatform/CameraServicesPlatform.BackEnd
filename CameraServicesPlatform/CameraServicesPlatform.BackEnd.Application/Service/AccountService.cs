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
using CameraServicesPlatform.BackEnd.Domain.Data;
 using CameraServicesPlatform.BackEnd.Domain.Models;
using Firebase.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Cryptography;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static QRCoder.PayloadGenerator;
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

    public async Task<AppActionResult> GetSupplierIDByAccountID(string accountId)
    {
        Supplier? supplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.AccountID == accountId);

        return supplier == null
            ? new AppActionResult
            {
                IsSuccess = false,
                Messages = ["Supplier not found."]
            }
            : new AppActionResult
            {
                IsSuccess = true,
                Result = supplier.SupplierID
            };
    }

    public async Task<AppActionResult> GetStafIDByAccountID(string accountId)
    {
        Staff? staff = await _context.Staffs
            .FirstOrDefaultAsync(s => s.AccountID == accountId);

        return staff == null
            ? new AppActionResult
            {
                IsSuccess = false,
                Messages = ["Staff not found."]
            }
            : new AppActionResult
            {
                IsSuccess = true,
                Result = staff.StaffID
            };
    }
    public async Task<AppActionResult> CreateAccountSupplier(CreateSupplierAccountDTO dto, bool isGoogle)
    {
        IFirebaseService? firebaseService = Resolve<IFirebaseService>();
        AppActionResult result = new();

        try
        {
            // Kiểm tra xem email đã tồn tại chưa
            if (await _accountRepository.GetAccountByEmail(dto.Email, null, null) != null)
            {
                return BuildAppActionResultError(result, "Email đã tồn tại!");
            }

            if (dto.BackOfCitizenIdentificationCard == null || dto.FrontOfCitizenIdentificationCard == null)
            {
                return BuildAppActionResultError(result, "Bạn phải nhập ảnh hai mặt của căn cước công dân!");
            }
            IEmailService? emailService = Resolve<IEmailService>();
            string verifyCode = string.Empty;

            // Tạo mã xác minh
            if (!isGoogle)
            {
                verifyCode = Guid.NewGuid().ToString("N")[..6];
            }

            // Mapping DTO sang Account
            Account account = _mapper.Map<Account>(dto);
            account.VerifyCode = verifyCode;
            account.IsVerified = isGoogle;
            
            IdentityResult createAccountResult;

            // Upload ảnh căn cước công dân lên Firebase nếu có
            string? frontCardImageUrl = null;
            string? backCardImageUrl = null;

            if (dto.FrontOfCitizenIdentificationCard != null)
            {
                string frontPathName = SD.FirebasePathName.ACCOUNT_CITIZEN_IDENTIFICATION_CARD + $"{Guid.NewGuid()}_front.jpg";
                AppActionResult frontUpload = await firebaseService.UploadFileToFirebase(dto.FrontOfCitizenIdentificationCard, frontPathName);
                frontCardImageUrl = frontUpload?.Result?.ToString();
            }

            if (dto.BackOfCitizenIdentificationCard != null)
            {
                string backPathName = SD.FirebasePathName.ACCOUNT_CITIZEN_IDENTIFICATION_CARD + $"{Guid.NewGuid()}_back.jpg";
                AppActionResult backUpload = await firebaseService.UploadFileToFirebase(dto.BackOfCitizenIdentificationCard, backPathName);
                backCardImageUrl = backUpload?.Result?.ToString();
            }

            // Cập nhật đường dẫn ảnh vào Account nếu cần
            account.FrontOfCitizenIdentificationCard = frontCardImageUrl;
            account.BackOfCitizenIdentificationCard = backCardImageUrl;
            

            if (!isGoogle)
            {
                // Tạo tài khoản với mật khẩu cho các đăng ký chuẩn
                createAccountResult = await _userManager.CreateAsync(account, dto.Password);
                if (createAccountResult.Succeeded)
                {
                    // Gửi email xác minh
                    //emailService.SendEmail(account.Email, SD.SubjectMail.VERIFY_ACCOUNT,
                    //    TemplateMappingHelper.GetTemplateOTPEmail(
                    //        TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE,
                    //        verifyCode,
                    //        account.FirstName));

                    // Gán quyền SUPPLIER
                    IdentityResult roleResult = await _userManager.AddToRoleAsync(account, "SUPPLIER");
                    if (!roleResult.Succeeded)
                    {
                        string roleErrors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                        return BuildAppActionResultError(result, $"Cấp quyền SUPPLIER không thành công: {roleErrors}");
                    }

                    // Thêm nhà cung cấp vào kho
                    Supplier supplier = _mapper.Map<Supplier>(dto);
                    supplier.AccountID = account.Id;
                    supplier.CreatedAt = DateTime.UtcNow;
                    supplier.UpdatedAt = DateTime.UtcNow;
                    supplier.IsDisable = true;

                    _ = await _supplierRepository.Insert(supplier);
                    await Task.Delay(100);
                    await _unitOfWork.SaveChangeAsync();

 
                     await Task.Delay(100);
                    await _unitOfWork.SaveChangeAsync();
                    // Gán thông tin tài khoản và nhà cung cấp vào kết quả
                    result.Result = new
                    {
                        Account = account,
                        Supplier = supplier,
                     };
                }
                else
                {
                    string errors = string.Join(", ", createAccountResult.Errors.Select(e => e.Description));
                    return BuildAppActionResultError(result, $"Tạo tài khoản không thành công: {errors}");
                }
            }
            else
            {
                // Tạo tài khoản không có mật khẩu cho các đăng ký qua Google
                createAccountResult = await _userManager.CreateAsync(account);
                if (createAccountResult.Succeeded)
                {
                    //emailService.SendEmail(account.Email, SD.SubjectMail.VERIFY_ACCOUNT,
                    //    TemplateMappingHelper.GetTemplateOTPEmail(
                    //        TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE,
                    //        verifyCode,
                    //        account.FirstName) +
                    //    $"\n\nWelcome {account.FirstName}, thank you for signing up with Google!");

                    // Gán quyền SUPPLIER
                    IdentityResult roleResult = await _userManager.AddToRoleAsync(account, "SUPPLIER");
                    if (!roleResult.Succeeded)
                    {
                        string roleErrors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                        return BuildAppActionResultError(result, $"Cấp quyền SUPPLIER không thành công: {roleErrors}");
                    }

                    // Thêm nhà cung cấp vào kho
                    Supplier supplier = _mapper.Map<Supplier>(dto);
                    supplier.AccountID = account.Id;
                    supplier.CreatedAt = DateTime.UtcNow;
                    supplier.UpdatedAt = DateTime.UtcNow;
                    supplier.IsDisable = true;
                    _ = await _supplierRepository.Insert(supplier);
                    await _unitOfWork.SaveChangeAsync();

                    // Gán thông tin tài khoản và nhà cung cấp vào kết quả
                    result.Result = new
                    {
                        Account = account,
                        Supplier = supplier
                    };
                }
                else
                {
                    string errors = string.Join(", ", createAccountResult.Errors.Select(e => e.Description));
                    return BuildAppActionResultError(result, $"Tạo tài khoản không thành công: {errors}");
                }
            }
        }
        catch (DbUpdateException dbEx)
        {
            string innerException = dbEx.InnerException?.Message ?? "No inner exception available.";
            _logger.LogError("Error occurred while saving entity changes: {InnerException}: ${dbEx},", innerException);
            return BuildAppActionResultError(result, $"Đã xảy ra lỗi: {innerException}");
        }
        catch (Exception ex)
        {
            _logger.LogError("An unexpected error occurred.", ex);
            return BuildAppActionResultError(result, $"Đã xảy ra lỗi: {ex.Message}");
        }

        return result; 
    }
    private async Task SendVerificationEmail(string email, string verifyCode, string firstName, bool isGoogle)
    {
        IEmailService? emailService = Resolve<IEmailService>();

        if (!isGoogle)
        {
            emailService.SendEmail(email, SD.SubjectMail.VERIFY_ACCOUNT,
                TemplateMappingHelper.GetTemplateOTPEmail(
                    TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE,
                    verifyCode,
                    firstName));
        }
        else
        {
            emailService.SendEmail(email, SD.SubjectMail.VERIFY_ACCOUNT,
                TemplateMappingHelper.GetTemplateOTPEmail(
                    TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE,
                    verifyCode,
                    firstName) +
                $"\n\nWelcome {firstName}, thank you for signing up with Google!");
        }
    }

    public async Task<AppActionResult> CheckActiveByStaff(string AccountID, bool isGoogle)
    {
        AppActionResult result = new();

        try
        {
            Account? account = await _accountRepository.GetById(AccountID);
            if (account == null)
            {
                return BuildAppActionResultError(result, "Không tìm thấy tài khoản.");
            }

            string verifyCode = string.Empty;

            if (!isGoogle)
            {
                verifyCode = Guid.NewGuid().ToString("N")[..6];
                account.VerifyCode = verifyCode;
                account.IsVerified = false;
            }
            else
            {
                account.IsVerified = true;
            }

            await SendVerificationEmail(account.Email, verifyCode, account.FirstName, isGoogle);

            _accountRepository.Update(account);
            await _unitOfWork.SaveChangeAsync();

            result.Result = new
            {
                Account = account
            };
        }
        catch (Exception ex)
        {
            _logger.LogError("An unexpected error occurred.", ex);
            return BuildAppActionResultError(result, $"Đã xảy ra lỗi: {ex.Message}");
        }

        return result;
    }

    public async Task<AppActionResult> CreateAccount(SignUpRequestDTO signUpRequest, bool isGoogle)
    {
        IFirebaseService? firebaseService = Resolve<IFirebaseService>();
        AppActionResult result = new();
        try
        {
            if (await _accountRepository.GetAccountByEmail(signUpRequest.Email, null, null) != null)
            {
                result = BuildAppActionResultError(result, "Email hoặc username không tồn tại!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                IEmailService? emailService = Resolve<IEmailService>();
                string verifyCode = string.Empty;
                if (!isGoogle)
                {
                    verifyCode = Guid.NewGuid().ToString("N")[..6];
                }

                Account user = new()
                {
                    Email = signUpRequest.Email,
                    UserName = signUpRequest.Email,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    PhoneNumber = signUpRequest.PhoneNumber,
                    Gender = signUpRequest.Gender,
                    VerifyCode = verifyCode,
                    IsVerified = isGoogle,
                    BankName = signUpRequest.BankName,
                    AccountNumber = signUpRequest.AccountNumber,
                    AccountHolder = signUpRequest.AccountHolder,
                };

                // Upload ảnh căn cước công dân lên Firebase nếu có
                string? frontCardImageUrl = null;
                string? backCardImageUrl = null;
                string accountImgUrl = null;

                if (signUpRequest.FrontOfCitizenIdentificationCard != null)
                {
                    string frontPathName = SD.FirebasePathName.ACCOUNT_CITIZEN_IDENTIFICATION_CARD + $"{Guid.NewGuid()}_front.jpg";
                    AppActionResult frontUpload = await firebaseService.UploadFileToFirebase(signUpRequest.FrontOfCitizenIdentificationCard, frontPathName);
                    frontCardImageUrl = frontUpload?.Result?.ToString();
                }

                if (signUpRequest.BackOfCitizenIdentificationCard != null)
                {
                    string backPathName = SD.FirebasePathName.ACCOUNT_CITIZEN_IDENTIFICATION_CARD + $"{Guid.NewGuid()}_back.jpg";
                    AppActionResult backUpload = await firebaseService.UploadFileToFirebase(signUpRequest.BackOfCitizenIdentificationCard, backPathName);
                    backCardImageUrl = backUpload?.Result?.ToString();
                }

                if (signUpRequest.Img != null)
                {
                    string PathName = SD.FirebasePathName.ACCOUNT_PREFIX + $"{Guid.NewGuid()}.jpg";
                    AppActionResult backUpload = await firebaseService.UploadFileToFirebase(signUpRequest.Img, PathName);
                    accountImgUrl = backUpload?.Result?.ToString();
                }
                // Gán URL ảnh căn cước vào tài khoản
                user.FrontOfCitizenIdentificationCard = frontCardImageUrl;
                user.BackOfCitizenIdentificationCard = backCardImageUrl;
                user.Img = accountImgUrl;

                IdentityResult resultCreateUser = await _userManager.CreateAsync(user, signUpRequest.Password);
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
                       await SendEmailGoogleLogin(user.Email, user.FirstName);
        //                emailService!.SendEmail(user.Email, SD.SubjectMail.VERIFY_ACCOUNT,
        //TemplateMappingHelper.GetTemplateOTPEmail(
        //    TemplateMappingHelper.ContentEmailType.VERIFICATION_CODE, verifyCode,
        //    user.FirstName) +
        //$"\n\nWelcome {user.FirstName}, thank you for signing up with Google!");
                    }
                }
                else
                {
                    result = BuildAppActionResultError(result, $"Tạo tài khoản không thành công");
                }

                IdentityResult resultCreateRole = await _userManager.AddToRoleAsync(user, "MEMBER");
                if (!resultCreateRole.Succeeded)
                {
                    result = BuildAppActionResultError(result, $"Cấp quyền THÀNH VIÊN không thành công");
                }
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    private async Task SendEmailGoogleLogin(string email, string firstName)
    {
        IEmailService? emailService = Resolve<IEmailService>();

        var emailMessage =
            $"Kính chào {firstName},<br /><br />" +
            $"Bạn vừa đăng nhập vào hệ thống của chúng tôi bằng tài khoản google với email là: {email}.<br /><br />" +
            "<br />Chúc bạn có những trải nghiệm tuyệt vời.<br /><br />" +
            "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
            "Trân trọng,<br />" +
            "Đội ngũ Camera service platform";

        emailService.SendEmail(
           email,
           SD.SubjectMail.WELCOME,
           emailMessage
       );
    }

    public async Task<AppActionResult> AssignUserIntoStaff(string userId, string staffId)
    {
        AppActionResult result = new();
        IRepository<Staff>? staffRepository = Resolve<IRepository<Staff>>();
        try
        {
            Account accountDb = await _accountRepository.GetById(userId);
            if (accountDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy tài khoản với id {userId}");
                return result;
            }

            Staff staffdb = await staffRepository.GetById(staffId);
            if (staffdb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy nhà cung cấp với id {staffId}");
                return result;
            }

            accountDb.StaffID = staffdb.StaffID.ToString();
            await _unitOfWork.SaveChangeAsync();

        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }
        return result;
    }

    public async Task<PagedResult<Staff>> GetStaff(int pageNumber, int pageSize)
    {
        PagedResult<Staff>? result;
        try
        {
            result = new PagedResult<Staff>();
            result = await _staffRepository.GetAllDataByExpression(
               filter: null,
               pageNumber: pageNumber,
               pageSize: pageSize
           );
        }
        catch (Exception)
        {
            result = null;
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
            // Fetch the account
            var account = await _accountRepository.GetById(id);
            if (account == null)
            {
                return BuildAppActionResultError(result, $"Tài khoản với id {id} không tồn tại !");
            }

            // Fetch related Supplier or Staff if they exist
            if (!string.IsNullOrEmpty(account.SupplierID))
            {
                if (Guid.TryParse(account.SupplierID, out var supplierGuid))
                {
                    var supplierDb = await _supplierRepository.GetByExpression(p => p.SupplierID == supplierGuid);
                    if (supplierDb == null)
                    {
                        return BuildAppActionResultError(result, $"Nhà cung cấp với ID {account.SupplierID} không tồn tại");
                    }
                    account.Supplier = supplierDb;
                }
                else
                {
                    return BuildAppActionResultError(result, $"ID nhà cung cấp không hợp lệ: {account.SupplierID}");
                }
            }
            else if (!string.IsNullOrEmpty(account.StaffID))
            {
                if (Guid.TryParse(account.StaffID, out var staffGuid))
                {
                    var staffDb = await _staffRepository.GetByExpression(p => p.StaffID == staffGuid);
                    if (staffDb == null)
                    {
                        return BuildAppActionResultError(result, $"Nhân viên với ID {account.StaffID} không tồn tại");
                    }
                    account.Staff = staffDb;
                }
                else
                {
                    return BuildAppActionResultError(result, $"ID nhân viên không hợp lệ: {account.StaffID}");
                }
            }

            result.Result = account;
        }
        catch (Exception ex)
        {
            return BuildAppActionResultError(result, $"Lỗi xảy ra: {ex.Message}");
        }

        return result;
    }

    public async Task<AppActionResult> AssignRole(string userId, string roleName)
    {
        AppActionResult result = new();
        try
        {
            Account accountDb = await _accountRepository.GetById(userId);
            if (accountDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy tài khoản với id {userId}");
                return result;
            }
            IRepository<IdentityRole>? roleRepository = Resolve<IRepository<IdentityRole>>();

            IdentityRole roleDb = await GetIdentityRoleByName(roleName);
            if (roleDb == null)
            {
                result = BuildAppActionResultError(result, $"Không tìm thấy phân quyền với tên {roleName}");
                return result;
            }

            IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            List<string> roleListDb = await GetRoleListByAccountId(userId);
            if (roleListDb.Count() != 0)
            {
                if (roleListDb.Contains(roleDb.Id))
                {
                    result = BuildAppActionResultError(result, $"Tài khoản với id {userId} đã có phân quyền {roleName}");
                    return result;
                }
            }

            bool isSuccessful = await AssignRoleUser(userId, roleDb.Id);
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
    public async Task<List<string>> GetRoleListByAccountId(string accountId)
    {
        return await _context.Set<IdentityUserRole<string>>()
            .Where(ur => ur.UserId == accountId)
            .Select(ur => ur.RoleId)
            .ToListAsync();
    }
    public async Task<List<string>> GetRoleNameListById(List<string> roleIds)
    {
        // Fetch role names from the database based on the provided role IDs
        return await _context.Set<IdentityRole>()
            .Where(r => roleIds.Contains(r.Id))
            .Select(r => r.Name)
            .ToListAsync();
    }
    private async Task<bool> AssignRoleUser(string userId, string roleId)
    {
        IdentityUserRole<string> userRole = new()
        {
            UserId = userId,
            RoleId = roleId
        };

        _ = await _context.UserRoles.AddAsync(userRole);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<AppActionResult> LoginDefault(string email, Account? user)
    {
        AppActionResult result = new();

        IJwtService? jwtService = Resolve<IJwtService>();
        Utility? utility = Resolve<Utility>();
        string token = await jwtService!.GenerateAccessToken(new LoginRequestDTO { Email = email });

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

        List<string> roleListDb = await GetRoleListByAccountId(user.Id);

        // Call the newly defined method
        List<string> roleNameList = await GetRoleNameListById(roleListDb);

        if (roleNameList.Contains("ADMIN"))
        {
            _tokenDto.MainRole = "ADMIN";
        }
        else
        {
            _tokenDto.MainRole = roleNameList.Contains("STAFF")
                ? "STAFF"
                : roleNameList.Count > 0 ? roleNameList.FirstOrDefault(n => !n.Equals("MEMBER")) : "MEMBER";
        }

        result.Result = _tokenDto;
        _ = await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<PagedResult<Supplier>> GetSupllier(int pageNumber, int pageSize)
    {
        PagedResult<Supplier>? result;
        try
        {
            result = new PagedResult<Supplier>();
            result = await _supplierRepository.GetAllDataByExpression(
                filter: null,
                pageNumber: pageNumber,
                pageSize: pageSize
            );
        }
        catch (Exception)
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
            string roleName = "staff";
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                // Optionally create the role if it does not exist
                IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded)
                {
                    // Handle role creation failure
                    isSuccess = false;
                    return isSuccess;
                }
            }

            // Assign role to each account
            foreach (Account account in staffAccountList)
            {
                var accountDb = await _accountRepository.GetById(account.Id);
                if (accountDb != null)
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(accountDb, roleName);
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
        IFirebaseService? firebaseService = Resolve<IFirebaseService>();
        AppActionResult result = new();
        try
        {
            // Validate the DTO if necessary
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.PhoneNumber))
            {
                result = BuildAppActionResultError(result, "Email and Phone Number are required.");
                return result;
            }

            // Create a new Account instance from the DTO
            Account staffAccount = _mapper.Map<Account>(dto);
            staffAccount.Id = Guid.NewGuid().ToString();
            staffAccount.UserName = dto.Email; // Using Email as UserName
            staffAccount.IsDeleted = false;
            staffAccount.IsVerified = true;
            staffAccount.VerifyCode = null;

            string? ImageUrl = null;

            if (dto.Img != null)
            {
                string frontPathName = SD.FirebasePathName.STAFF_PREFIX + $"{staffAccount.Id}.jpg";
                AppActionResult frontUpload = await firebaseService.UploadFileToFirebase(dto.Img, frontPathName);
                ImageUrl = frontUpload?.Result?.ToString();
            }
            staffAccount.Img = ImageUrl;

            // Upload the image and assign the URL to the Account
            //string pathName = SD.FirebasePathName.STAFF_PREFIX + staffAccount.Id; // Update prefix to STAF_PREFIX
            //AppActionResult url = await _firebaseService.UploadFileToFirebase(dto.Img, pathName);
            //if (url.IsSuccess)
            //{
            //    staffAccount.Img = (string)url.Result;
            //}
            //else
            //{
            //    result = BuildAppActionResultError(result, "Failed to upload staff image. Please try again.");
            //    return result;
            //}

            // Create the user in Identity
            //IdentityResult resultCreateUser = await _userManager.CreateAsync(staffAccount, SD.DefaultAccountInformation.PASSWORD);
            IdentityResult resultCreateUser = await _userManager.CreateAsync(staffAccount, SD.DefaultAccountInformation.PASSWORD);
            if (!resultCreateUser.Succeeded)
            {
                result = BuildAppActionResultError(result, $"Account creation for staff {dto.FirstName} failed: {string.Join(", ", resultCreateUser.Errors.Select(e => e.Description))}");
                return result;
            }

            // Assign roles if necessary
            //bool isSuccessful = await AssignStaffRole([staffAccount]); // Update method to assign staff role
            IdentityResult roleResult = await _userManager.AddToRoleAsync(staffAccount, "STAFF");
            if (roleResult != null)
            {
                // Insert the Staff entity into the database
                Staff staff = _mapper.Map<Staff>(dto);
                staff.AccountID = staffAccount.Id; // Link Staff with the created Account
                _ = await _staffRepository.Insert(staff);
                await _unitOfWork.SaveChangeAsync();

                // Send account creation email for staff
                SendAccountCreationEmailForStaff([staffAccount]); // Update method for staff email
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
            foreach (Account account in tourGuideAccountList)
            {
                _emailService?.SendEmail(account.Email, SD.SubjectMail.WELLCOME_STAFF,
                   TemplateMappingHelper.GetTemplateOTPEmail(TemplateMappingHelper.ContentEmailType.STAFF_ACCOUNT_CREATION,
                       $"Username: {account.Email} \nPassword: {SD.DefaultAccountInformation.PASSWORD}\n Vui lòng không chia sẻ thông tin tài khoản của bạn với bất kì ai", $"{account.FirstName} {account.LastName}"));
            }
        }
        catch (Exception)
        {
        }
    }

    public async Task<AppActionResult> Login(LoginRequestDTO loginRequest)
    {
        AppActionResult result = new();
        try
        {
            Account? user = await _accountRepository.GetAccountByEmail(loginRequest.Email, false, null);
            if (user == null)
            {
                result = BuildAppActionResultError(result, $" {loginRequest.Email} này không tồn tại trong hệ thống");
            }
            else if (user.IsVerified == false)
            {
                result = BuildAppActionResultError(result, "Tài khoản này chưa được xác thực !");
            }

            SignInResult passwordSignIn =
                await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
            if (!passwordSignIn.Succeeded)
            {
                result = BuildAppActionResultError(result, "Đăng nhâp thất bại");
            }

            if (!BuildAppActionResultIsError(result))
            {
                result = await LoginDefault(loginRequest.Email, user);
            }
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> VerifyLoginGoogle(string email, string verifyCode)
    {
        AppActionResult result = new();
        try
        {
            Account? user = await _accountRepository.GetAccountByEmail(email, false, null);
            if (user == null)
            {
                result = BuildAppActionResultError(result, $"Email này không tồn tại");
            }
            else if (user.IsVerified == false)
            {
                result = BuildAppActionResultError(result, "Tài khoản này chưa xác thực !");
            }
            else if (user.VerifyCode != verifyCode)
            {
                result = BuildAppActionResultError(result, "Mã xác thực sai!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                result = await LoginDefault(email, user);
                user!.VerifyCode = null;
                await _unitOfWork.SaveChangeAsync();
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
        var firebaseService = Resolve<IFirebaseService>();
        AppActionResult result = new();
        try
        {
            Account account =
                await _accountRepository.GetAccountByEmail(accountRequest.Email, null, null);
            if (account == null)
            {
                result = BuildAppActionResultError(result, $"Tài khoản với email {accountRequest.Email} không tồn tại!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                account!.FirstName = accountRequest.FirstName;
                account.LastName = accountRequest.LastName;
                account.PhoneNumber = accountRequest.PhoneNumber;
                account.BankName = accountRequest.BankName;
                account.AccountNumber = accountRequest.AccountNumber;
                account.AccountHolder = accountRequest.AccountHolder;
                string imageUrlFrontOfCitizenIdentificationCard = null;
                string imageUrlAccount = null;
                string imageUrlBackOfCitizenIdentificationCard = null;
                if (accountRequest.FrontOfCitizenIdentificationCard != null || accountRequest.Img != null || accountRequest.BackOfCitizenIdentificationCard != null)
                {

                    if (accountRequest.FrontOfCitizenIdentificationCard != null && accountRequest.FrontOfCitizenIdentificationCard.ToString() != account.FrontOfCitizenIdentificationCard)
                    {
                        if (!string.IsNullOrEmpty(account.FrontOfCitizenIdentificationCard))
                        {
                            await firebaseService.DeleteFileFromFirebase(account.FrontOfCitizenIdentificationCard);
                        }

                        var imgPathName = SD.FirebasePathName.ACCOUNT_CITIZEN_IDENTIFICATION_CARD + $"{account.Id}.jpg";
                        var imgUpload = await firebaseService.UploadFileToFirebase(accountRequest.FrontOfCitizenIdentificationCard, imgPathName);
                        imageUrlFrontOfCitizenIdentificationCard = imgUpload?.Result?.ToString();
                    }

                    if (accountRequest.Img != null && accountRequest.Img.ToString() != account.Img)
                    {
                        if (!string.IsNullOrEmpty(account.Img))
                        {
                            await firebaseService.DeleteFileFromFirebase(account.Img);
                        }

                        var imgPathName = SD.FirebasePathName.ACCOUNT_PREFIX + $"{account.Id}.jpg";
                        var imgUpload = await firebaseService.UploadFileToFirebase(accountRequest.Img, imgPathName);
                        imageUrlAccount = imgUpload?.Result?.ToString();
                    }

                    if (accountRequest.BackOfCitizenIdentificationCard != null && accountRequest.BackOfCitizenIdentificationCard.ToString() != account.BackOfCitizenIdentificationCard)
                    {
                        if (!string.IsNullOrEmpty(account.BackOfCitizenIdentificationCard))
                        {
                            await firebaseService.DeleteFileFromFirebase(account.BackOfCitizenIdentificationCard);
                        }

                        var imgPathName = SD.FirebasePathName.ACCOUNT_CITIZEN_IDENTIFICATION_CARD + $"{account.Id}.jpg";
                        var imgUpload = await firebaseService.UploadFileToFirebase(accountRequest.BackOfCitizenIdentificationCard, imgPathName);
                        imageUrlBackOfCitizenIdentificationCard = imgUpload?.Result?.ToString();
                    }

                    account.BackOfCitizenIdentificationCard = imageUrlBackOfCitizenIdentificationCard;
                    account.FrontOfCitizenIdentificationCard = imageUrlFrontOfCitizenIdentificationCard;
                    account.Img = imageUrlAccount;
                }
                account.Gender = accountRequest.Gender;
                account.Hobby = accountRequest.Hobby;
                account.Job = accountRequest.Job;
                result.Result = await _accountRepository.Update(account);
            }

            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }



    public async Task<AppActionResult> ChangePassword(ChangePasswordDTO changePasswordDto)
    {
        AppActionResult result = new();

        try
        {
            Account? user = await _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user == null || (user != null && user.IsDeleted))
            {
                result = BuildAppActionResultError(result,
                    $"Tài khoản có email {changePasswordDto.Email} không tồn tại!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                IdentityResult changePassword = await _userManager.ChangePasswordAsync(user!, changePasswordDto.OldPassword,
                    changePasswordDto.NewPassword);
                if (!changePassword.Succeeded)
                {
                    result = BuildAppActionResultError(result, "Thay đổi mật khẩu thất bại");
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> GetNewToken(string refreshToken, string userId)
    {
        AppActionResult result = new();

        try
        {
            Account user = await _accountRepository.GetById(userId);
            if (user == null)
            {
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại");
            }
            else if (user.RefreshToken != refreshToken)
            {
                result = BuildAppActionResultError(result, "Mã làm mới không chính xác");
            }

            if (!BuildAppActionResultIsError(result))
            {
                IJwtService? jwtService = Resolve<IJwtService>();
                result.Result = await jwtService!.GetNewToken(refreshToken, userId);
            }

            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> ForgotPassword(ForgotPasswordDTO dto)
    {
        AppActionResult result = new();

        try
        {
            Account? user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || (user != null && user.IsDeleted))
            {
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");
            }
            else if (user.VerifyCode != dto.RecoveryCode)
            {
                result = BuildAppActionResultError(result, "Mã xác thực sai!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                _ = await _userManager.RemovePasswordAsync(user!);
                IdentityResult addPassword = await _userManager.AddPasswordAsync(user!, dto.NewPassword);
                if (addPassword.Succeeded)
                {
                    user!.VerifyCode = null;
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    result = BuildAppActionResultError(result, "Thay đổi mật khẩu thất bại. Vui lòng thử lại");
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> ActiveAccount(string email, string verifyCode)
    {
        AppActionResult result = new();
        try
        {
            Account? user = await _userManager.FindByEmailAsync(email);
            if (user == null || (user != null && user.IsDeleted))
            {
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");
            }
            else if (user.VerifyCode != verifyCode)
            {
                result = BuildAppActionResultError(result, "Mã xác thực sai!");
            }
            else
            {
                user.EmailConfirmed = true;
                user.IsVerified = true; // Set verified status
                user.VerifyCode = null; // Clear verification code
                _ = await _userManager.UpdateAsync(user); // Save changes to the database
            }

            _ = await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> SendEmailForgotPassword(string email)
    {
        AppActionResult result = new();

        try
        {
            Account? user = await _userManager.FindByEmailAsync(email);
            if (user == null || (user != null && user.IsDeleted))
            {
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                IEmailService? emailService = Resolve<IEmailService>();
                string code = await GenerateVerifyCode(user!.Email, true);
                user.VerifyCode = code;
                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
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
        AppActionResult result = new();

        try
        {
            Account? user = await _userManager.FindByEmailAsync(email);
            if (user == null || (user != null && user.IsDeleted))
            {
                result = BuildAppActionResultError(result, "Tài khoản không tồn tại hoặc chưa được xác thực!");
            }

            if (!BuildAppActionResultIsError(result))
            {
                IEmailService? emailService = Resolve<IEmailService>();
                string code = await GenerateVerifyCode(user!.Email, false);
                user.VerifyCode = code;
                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
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
        string code = string.Empty;

        Account? user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            code = Guid.NewGuid().ToString("N")[..6];
            user.VerifyCode = code;
        }

        _ = await _unitOfWork.SaveChangesAsync();

        return code;
    }

    public async Task<AppActionResult> GoogleCallBack(string accessTokenFromGoogle)
    {
        AppActionResult result = new();
        try
        {
            FirebaseApp existingFirebaseApp = FirebaseApp.DefaultInstance;
            if (existingFirebaseApp == null)
            {
                FirebaseAdminSDK? config = Resolve<FirebaseAdminSDK>();
                GoogleCredential credential = GoogleCredential.FromJson(JsonConvert.SerializeObject(new
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
                FirebaseApp firebaseApp = FirebaseApp.Create(new AppOptions
                {
                    Credential = credential
                });
            }

            FirebaseAdmin.Auth.FirebaseToken verifiedToken = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance
                .VerifyIdTokenAsync(accessTokenFromGoogle);
            KeyValuePair<string, object> emailClaim = verifiedToken.Claims.FirstOrDefault(c => c.Key == "email");
            KeyValuePair<string, object> nameClaim = verifiedToken.Claims.FirstOrDefault(c => c.Key == "name");
            string? name = nameClaim.Value.ToString();
            string? userEmail = emailClaim.Value.ToString();

            if (userEmail != null)
            {
                Account? user = await _accountRepository.GetByExpression(a => a!.Email == userEmail && a.IsDeleted == false);
                if (user == null)
                {
                    AppActionResult resultCreate =
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
                        Account account = (Account)resultCreate.Result!;
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
        AppActionResult result = new();
        try
        {
            Account user = await _accountRepository.GetById(userId);
            IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            IRepository<IdentityRole>? identityRoleRepository = Resolve<IRepository<IdentityRole>>();
            foreach (string role in roleId)
            {
                if (await identityRoleRepository!.GetById(role) == null)
                {
                    result = BuildAppActionResultError(result, $"Vai trò với id {role} không tồn tại");
                }
            }

            if (!BuildAppActionResultIsError(result))
            {
                foreach (string role in roleId)
                {
                    IdentityRole roleDb = await identityRoleRepository!.GetById(role);
                    IdentityResult resultCreateRole = await _userManager.AddToRoleAsync(user, roleDb.NormalizedName);
                    if (!resultCreateRole.Succeeded)
                    {
                        result = BuildAppActionResultError(result, $"Cấp quyền với vai trò {role} không thành công");
                    }
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> RemoveRoleForUserId(string userId, IList<string> roleId)
    {
        AppActionResult result = new();

        try
        {
            Account user = await _accountRepository.GetById(userId);
            IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
            IRepository<IdentityRole>? identityRoleRepository = Resolve<IRepository<IdentityRole>>();
            if (user == null)
            {
                result = BuildAppActionResultError(result, $"Người dùng với {userId} không tồn tại");
            }

            foreach (string role in roleId)
            {
                if (await identityRoleRepository.GetById(role) == null)
                {
                    result = BuildAppActionResultError(result, $"Vai trò với {role} không tồn tại");
                }
            }

            if (!BuildAppActionResultIsError(result))
            {
                foreach (string role in roleId)
                {
                    IdentityRole roleDb = await identityRoleRepository!.GetById(role);
                    IdentityResult resultCreateRole = await _userManager.RemoveFromRoleAsync(user!, roleDb.NormalizedName);
                    if (!resultCreateRole.Succeeded)
                    {
                        result = BuildAppActionResultError(result, $"Xóa quyền {role} thất bại");
                    }
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            result = BuildAppActionResultError(result, ex.Message);
        }

        return result;
    }

    public async Task<AppActionResult> GetAccountsByRoleName(string roleName, int pageNumber, int pageSize)
    {
        AppActionResult result = new();

        try
        {
            IRepository<IdentityRole>? roleRepository = Resolve<IRepository<IdentityRole>>();
            IdentityRole? roleDb = await roleRepository!.GetByExpression(r => r.NormalizedName.Equals(roleName.ToLower()));
            if (roleDb != null)
            {
                IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
                PagedResult<IdentityUserRole<string>> userRoleDb = await userRoleRepository!.GetAllDataByExpression(u => u.RoleId == roleDb.Id, 0, 0, null, false, null);
                if (userRoleDb.Items != null && userRoleDb.Items.Count > 0)
                {
                    List<string> accountIds = userRoleDb.Items.Select(u => u.UserId).Distinct().ToList();
                    PagedResult<Account> accountDb = await _accountRepository.GetAllDataByExpression(a => accountIds.Contains(a.Id), pageNumber, pageSize, null, false, null);
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
        AppActionResult result = new();

        try
        {

            IRepository<IdentityRole>? roleRepository = Resolve<IRepository<IdentityRole>>();
            IdentityRole roleDb = await roleRepository!.GetById(Id);
            if (roleDb != null)
            {
                IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
                PagedResult<IdentityUserRole<string>> userRoleDb = await userRoleRepository!.GetAllDataByExpression(u => u.RoleId == roleDb.Id, 0, 0, null, false, null);
                if (userRoleDb.Items != null && userRoleDb.Items.Count > 0)
                {
                    List<string> accountIds = userRoleDb.Items.Select(u => u.UserId).Distinct().ToList();
                    PagedResult<Account> accountDb = await _accountRepository.GetAllDataByExpression(a => accountIds.Contains(a.Id), pageNumber, pageSize, null, false, null);
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
        using Aes aes = Aes.Create();
        aes.Key = Convert.FromBase64String(key);
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.CBC;
        aes.IV = new byte[16]; // Assuming a zero IV for simplicity
        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using MemoryStream ms = new();
        using (CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write))
        {
            using StreamWriter sw = new(cs);
            sw.Write(data);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    private string DecryptData(string encryptedData, string key)
    {
        using Aes aes = Aes.Create();
        aes.Key = Convert.FromBase64String(key);
        aes.IV = new byte[16];
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.CBC;// Assuming a zero IV for simplicity
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream ms = new(Convert.FromBase64String(encryptedData));
        using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
        using StreamReader sr = new(cs);
        return sr.ReadToEnd();
    }




    public async Task<AppActionResult> GetAllAccount(int pageIndex, int pageSize)
    {
        AppActionResult result = new();
        PagedResult<Account> list = await _accountRepository.GetAllDataByExpression(null, pageIndex, pageSize, null, false, null);

        IRepository<IdentityUserRole<string>>? userRoleRepository = Resolve<IRepository<IdentityUserRole<string>>>();
        IRepository<IdentityRole>? roleRepository = Resolve<IRepository<IdentityRole>>();
        PagedResult<IdentityRole> listRole = await roleRepository!.GetAllDataByExpression(null, 1, 100, null, false, null);

        // Add repositories for Supplier and Staff
        IRepository<Supplier>? supplierRepository = Resolve<IRepository<Supplier>>();
        IRepository<Staff>? staffRepository = Resolve<IRepository<Staff>>();

        List<AccountResponse> listMap = _mapper.Map<List<AccountResponse>>(list.Items);
        foreach (AccountResponse item in listMap)
        {
            // Retrieve User Roles
            List<IdentityRole> userRole = [];
            PagedResult<IdentityUserRole<string>> role = await userRoleRepository!.GetAllDataByExpression(a => a.UserId == item.Id, 1, 100, null, false, null);
            foreach (IdentityUserRole<string> itemRole in role.Items!)
            {
                IdentityRole? roleUser = listRole.Items!.ToList().FirstOrDefault(a => a.Id == itemRole.RoleId);
                if (roleUser != null)
                {
                    userRole.Add(roleUser);
                }
            }

            item.Role = userRole;

            // Determine MainRole
            if (userRole.Where(u => u.Name.Equals("ADMIN")).FirstOrDefault() != null)
            {
                item.MainRole = "ADMIN";
            }
            else if (userRole.Where(u => u.Name.Equals("SUPPLIER")).FirstOrDefault() != null)
            {
                item.MainRole = "SUPPLIER";
            }
            else
            {
                item.MainRole = userRole.Where(u => u.Name.Equals("STAFF")).FirstOrDefault() != null
                    ? "STAFF"
                    : userRole.Count > 0 ? userRole.FirstOrDefault(n => !n.Equals("MEMBER")).Name : "MEMBER";
            }

            // Retrieve Supplier data
            var supplier = await supplierRepository!.GetSingleByExpressionAsync(s => s.AccountID == item.Id);
            if (supplier != null)
            {
                item.SupplierID = supplier.SupplierID.ToString();
                item.Supplier = supplier;
            }


        }

        result.Result = new PagedResult<AccountResponse> { Items = listMap, TotalPages = list.TotalPages };
        return result;

    }

}

