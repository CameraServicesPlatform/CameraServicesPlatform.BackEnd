using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using PdfSharp;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static CameraServicesPlatform.BackEnd.Application.Service.OrderService;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ComboOfSupplierService : GenericBackendService, IComboOfSupplierService
    {
        private readonly IMapper _mapper; 
        private IRepository<ComboOfSupplier> _comboSupplierRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Combo> _comboRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private IUnitOfWork _unitOfWork;


        public ComboOfSupplierService(
            IRepository<ComboOfSupplier> comboSupplierRepository,
            IRepository<Combo> comboRepository,
            IUnitOfWork unitOfWork,
            IRepository<Payment> paymentRepository,
            IMapper mapper,
            IRepository<Supplier> supplierRepository,
            IRepository<Product> productRepository,
            IRepository<Account> accountRepository,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _paymentRepository = paymentRepository;
            _comboSupplierRepository = comboSupplierRepository;
            _comboRepository = comboRepository;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateComboOfSupplier(ComboOfSupplierCreateDto request, HttpContext context)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var utility = Resolve<Utility>();
                var paymentGatewayService = Resolve<IPaymentGatewayService>();
                DateTime newStartTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                DateTime newEndTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                DateTime dateNow = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                var comboOfSupplier = Resolve<IRepository<ComboOfSupplier>>();
                
                var check = await _comboSupplierRepository.GetAllDataByExpression(
                    a => a.ComboId == Guid.Parse(request.ComboId) && a.IsDisable == true && a.SupplierID == Guid.Parse(request.SupplierID),
                    1,
                    int.MaxValue,
                    null,
                    isAscending: true,
                    null
                );

                var getCombo = await _comboRepository.GetByExpression(x => x.ComboId == Guid.Parse(request.ComboId));

                var activeCombos = await _comboSupplierRepository.GetAllDataByExpression(
                    a => a.ComboId == Guid.Parse(request.ComboId) && a.SupplierID == Guid.Parse(request.SupplierID) && a.IsDisable == false, 
                    1,
                    int.MaxValue,null,
                    isAscending: true,
                    null);

                if (activeCombos.Items.Any())
                {
                    var latestActiveCombo = activeCombos.Items.OrderByDescending(c => c.EndTime).FirstOrDefault();
                    if (latestActiveCombo != null)
                    {
                        if (latestActiveCombo.EndTime > dateNow)
                        {
                            newStartTime = latestActiveCombo.EndTime.AddDays(1);

                            switch (getCombo.DurationCombo)
                            {
                                case DurationCombo.oneMonth:
                                    newEndTime = newStartTime.AddMonths(1);
                                    break;
                                case DurationCombo.twoMonth:
                                    newEndTime = newStartTime.AddMonths(2);
                                    break;
                                case DurationCombo.threeMonth:
                                    newEndTime = newStartTime.AddMonths(3);
                                    break;
                                case DurationCombo.fiveMonth:
                                    newEndTime = newStartTime.AddMonths(5);
                                    break;
                                default:
                                    throw new InvalidOperationException("DurationUnit is not supported.");
                            }
                        }
                    }
                }
                else
                {
                    switch (getCombo.DurationCombo)
                    {
                        case DurationCombo.oneMonth:
                            newEndTime = newStartTime.AddMonths(1);
                            break;
                        case DurationCombo.twoMonth:
                            newEndTime = newStartTime.AddMonths(2);
                            break;
                        case DurationCombo.threeMonth:
                            newEndTime = newStartTime.AddMonths(3);
                            break;
                        case DurationCombo.fiveMonth:
                            newEndTime = newStartTime.AddMonths(5);
                            break;
                        default:
                            throw new InvalidOperationException("DurationUnit is not supported.");
                    }
                }

                ComboOfSupplier comboNew = new ComboOfSupplier
                {
                    ComboOfSupplierId = Guid.NewGuid(),
                    ComboId = Guid.Parse(request.ComboId),
                    SupplierID = Guid.Parse(request.SupplierID),
                    IsMailNearExpired = false,
                    IsSendMailExpired = false,
                    IsDisable = false,
                    StartTime = newStartTime,
                    EndTime = newEndTime

                };

                var combo = await _comboRepository.GetByExpression(x => x.ComboId == Guid.Parse(request.ComboId));

                var supplier = await _supplierRepository.GetByExpression(x => x.SupplierID == Guid.Parse(request.SupplierID));
                var supplierAccount = await _accountRepository.GetByExpression(x => x.Id == supplier.AccountID);
                supplier.IsDisable = false;
                await _supplierRepository.Update(supplier);
                await _unitOfWork.SaveChangesAsync();

                var products = await _productRepository.GetAllDataByExpression(
                    p => p.SupplierID == supplier.SupplierID,
                    1, 
                    int.MaxValue,
                    null,
                    isAscending: true,
                    null);

                foreach (var product in products.Items)
                {
                    product.IsDisable = false; 
                    await _productRepository.Update(product);
                }

                await _unitOfWork.SaveChangesAsync();

                var paymentCombo = new CreateComboPaymentDTO
                {
                    AccountId = supplierAccount.Id,
                    Amount = (double)combo.ComboPrice,
                    ComboOfSupplierId = comboNew.ComboOfSupplierId.ToString(),
                };
                
                var payMethod = await paymentGatewayService.CreateComboPayment(paymentCombo, context);

                await comboOfSupplier.Insert(comboNew);
                await _unitOfWork.SaveChangesAsync();
                result.Result = payMethod;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GetAllComboOfSupplier(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<ComboOfSupplier, bool>>? filter = null;
                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );
                List<ComboOfSupplierResponse> listComboOfSupplier = new List<ComboOfSupplierResponse>();
                foreach (var item in pagedResult.Items)
                {

                    ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                    {
                        ComboOfSupplierId = item.ComboOfSupplierId.ToString(),
                        ComboId = item.ComboId.ToString(),
                        SupplierID = item.SupplierID.ToString(),
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        IsDisable = item.IsDisable,

                    };
                    listComboOfSupplier.Add(comboResponse);
                }

                result.Result = listComboOfSupplier;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> GetComboOfSupplierExpired(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
               
                var vietnamTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow);
                Expression<Func<ComboOfSupplier, bool>> filter = a => 
                    a.EndTime < vietnamTime;

                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                var listComboOfSupplier = new List<ComboOfSupplierResponse>();
                
                foreach (var item in pagedResult.Items)
                {
                    if (item.IsSendMailExpired == false)
                    {
                        item.IsSendMailExpired = true;
                        item.IsDisable = true;
                        _comboSupplierRepository.Update(item);
                        var supplier = await _supplierRepository.GetByExpression(x => x.SupplierID == item.SupplierID);
                        var supplierAccount = await _accountRepository.GetById(supplier.AccountID);
                        supplier.IsDisable = true;
                        await _supplierRepository.Update(supplier);
                        await _unitOfWork.SaveChangesAsync();
                        var listProduct = await _productRepository.GetAllDataByExpression(
                        x => x.SupplierID == item.SupplierID,
                        pageIndex,
                        pageSize,
                        null,
                        isAscending: true,
                        null
                        );
                        var combo = await _comboRepository.GetById(item.ComboId);
                        foreach (var items in listProduct.Items)
                        {
                            if(items.IsDisable == false)
                            {
                                items.IsDisable = true;
                                _productRepository.Update(items);
                                await _unitOfWork.SaveChangesAsync();
                            }
                            
                        }
                        ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                        {
                            ComboOfSupplierId = item.ComboOfSupplierId.ToString(),
                            ComboId = item.ComboId.ToString(),
                            SupplierID = item.SupplierID.ToString(),
                            StartTime = item.StartTime,
                            EndTime = item.EndTime,
                            IsDisable = true
                        };
                        listComboOfSupplier.Add(comboResponse);

                        var products = await _productRepository.GetAllDataByExpression(
                            p => p.SupplierID == supplier.SupplierID,
                            1,
                            int.MaxValue,
                            null,
                            isAscending: true,
                            null);
                        if (products != null)
                        {
                            foreach (var product in products.Items)
                            {
                                product.IsDisable = true;
                                await _productRepository.Update(product);
                            }
                        }
                        await SendComboPurchaseConfirmationEmail(supplierAccount, item, combo);                        
                        await _unitOfWork.SaveChangesAsync();
                    }
                    
                }
                result.Result = listComboOfSupplier;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetComboOfSupplierNearExpired(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {

                var vietnamTime = DateTimeHelper.ToVietnamTime(DateTime.UtcNow).AddDays(3);
                Expression<Func<ComboOfSupplier, bool>> filter = a =>
                    a.EndTime < vietnamTime;

                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                var listComboOfSupplier = new List<ComboOfSupplierResponse>();

                foreach (var item in pagedResult.Items)
                {
                    if (item.IsMailNearExpired == false)
                    {
                        item.IsMailNearExpired = true;
                        _comboSupplierRepository.Update(item);
                        var supplier = await _supplierRepository.GetByExpression(x => x.SupplierID == item.SupplierID);
                        var supplierAccount = await _accountRepository.GetById(supplier.AccountID);
                        var combo = await _comboRepository.GetById(item.ComboId);
                        await SendComboPurchaseConfirmationEmail(supplierAccount, item, combo);
                        await _unitOfWork.SaveChangesAsync();
                        ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                        {
                            ComboOfSupplierId = item.ComboOfSupplierId.ToString(),
                            ComboId = item.ComboId.ToString(),
                            SupplierID = item.SupplierID.ToString(),
                            StartTime = item.StartTime,
                            EndTime = item.EndTime,
                            IsDisable = item.IsDisable
                        };
                        listComboOfSupplier.Add(comboResponse);
                    }

                }
                result.Result = listComboOfSupplier;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        
        public async Task<AppActionResult> GetComboOfSupplierByComboSupplierId(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid comboSupplierId))
                {
                    result = BuildAppActionResultError(result, "Invalid Combo Supplier ID format.");
                    result.IsSuccess = false;
                    return result;
                }

                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    a => a.ComboOfSupplierId == comboSupplierId && a.IsDisable == false,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                if (pagedResult.Items.Count() == 0)
                {
                    result = BuildAppActionResultError(result, "Combo not exist");
                    return result;
                }
                ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                {
                    ComboOfSupplierId = pagedResult.Items[0].ComboOfSupplierId.ToString(),
                    ComboId = pagedResult.Items[0].ComboId.ToString(),
                    SupplierID = pagedResult.Items[0].SupplierID.ToString(),
                    StartTime = pagedResult.Items[0].StartTime,
                    EndTime = pagedResult.Items[0].EndTime,
                    IsDisable = pagedResult.Items[0].IsDisable

                };
                result.Result = comboResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetComboOfSupplierBySupplierId(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid SupplierId))
                {
                    result = BuildAppActionResultError(result, "Invalid Combo Supplier ID format.");
                    result.IsSuccess = false;
                    return result;
                }

                var pagedResult = await _comboSupplierRepository.GetAllDataByExpression(
                    a => a.SupplierID == SupplierId ,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                if (pagedResult.Items.Count() == 0)
                {
                    result = BuildAppActionResultError(result, "Combo not exist");
                    return result;
                }
                var listComboOfSupplier = new List<ComboOfSupplierResponse>();

                foreach ( var item in pagedResult.Items)
                {
                    ComboOfSupplierResponse comboResponse = new ComboOfSupplierResponse
                    {
                        ComboOfSupplierId = item.ComboOfSupplierId.ToString(),
                        ComboId = item.ComboId.ToString(),
                        SupplierID = item.SupplierID.ToString(),
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        IsDisable = item.IsDisable

                    };
                    listComboOfSupplier.Add(comboResponse);
                }
                
                result.Result = listComboOfSupplier;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }




        private async Task SendComboPurchaseConfirmationEmail(Account supplierAccount, ComboOfSupplier combo, Combo comboDetails)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Nội dung chi tiết hóa đơn combo
            var comboDetailsString =
                $"<b>Tên Combo:</b> {comboDetails.ComboName}<br />" +
                $"<b>Mã Combo:</b> {combo.ComboId}<br />" +
                $"<b>Giá Combo:</b> {comboDetails.ComboPrice:N0} ₫<br />" +
                $"<b>Thời gian kích hoạt:</b> {combo.StartTime:dd/MM/yyyy HH:mm}<br />" +
                $"<b>Thời gian kết thúc:</b> {combo.EndTime:dd/MM/yyyy HH:mm}<br />";

            // Invoice information template
            var invoiceInfo =
                "HÓA ĐƠN XÁC NHẬN MUA COMBO<br /><br />" +
                $"Mã hóa đơn: #{combo.ComboOfSupplierId}<br />" +
                "Thông tin nhà cung cấp:<br />" +
                $"<b>Tên:</b> {supplierAccount.FirstName} {supplierAccount.LastName}<br />" +
                $"<b>Email:</b> {supplierAccount.Email}<br />" +
                $"<b>Số điện thoại:</b> {supplierAccount.PhoneNumber ?? "N/A"}<br />" +
                $"<b>Địa chỉ:</b> {supplierAccount.Address ?? "Không có"}<br /><br />";

            // Tổng hợp email
            var emailMessage =
                $"Kính chào {supplierAccount.FirstName},<br /><br />" +
                $"Bạn vừa mua thành công một combo từ hệ thống. Dưới đây là thông tin chi tiết về combo của bạn:<br /><br />" +
                invoiceInfo +
                "=====================================<br />" +
                "         CHI TIẾT COMBO<br />" +
                "=====================================<br />" +
                comboDetailsString +
                "=====================================<br />" +
                "<br />Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Gửi email xác nhận
            emailService.SendEmail(
                supplierAccount.Email,
                SD.SubjectMail.COMBO_PURCHASE_CONFIRMATION,
                emailMessage
            );
        }

        private async Task SendMailComboExpired(Account supplierAccount, ComboOfSupplier combo, Combo comboDetails)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Nội dung chi tiết hóa đơn combo
            var comboDetailsString =
                $"<b>Tên Combo:</b> {comboDetails.ComboName}<br />" +
                $"<b>Mã Combo:</b> {combo.ComboId}<br />" +
                $"<b>Giá Combo:</b> {comboDetails.ComboPrice:N0} ₫<br />" +
                $"<b>Thời gian kích hoạt:</b> {combo.StartTime:dd/MM/yyyy HH:mm}<br />" +
                $"<b>Thời gian kết thúc:</b> {combo.EndTime:dd/MM/yyyy HH:mm}<br />";

            
            // Tổng hợp email
            var emailMessage =
                $"Kính chào {supplierAccount.FirstName},<br /><br />" +
                $"Combo quý khách đăng kí đã hết hạn. Dưới đây là thông tin chi tiết về combo của bạn:<br /><br />" +
                "=====================================<br />" +
                "         CHI TIẾT COMBO<br />" +
                "=====================================<br />" +
                comboDetailsString +
                "=====================================<br />" +
                "<br />Nếu quý khách muốn tiếp tục sử dụng dịch vụ trên nền tảng của chúng tôi vui lòng mua gói Combo mới. có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Gửi email xác nhận
            emailService.SendEmail(
                supplierAccount.Email,
                SD.SubjectMail.COMBO_EXPIRED_CONFIRMATION,
                emailMessage
            );
        }

        private async Task SendMailComboNearExpired(Account supplierAccount, ComboOfSupplier combo, Combo comboDetails)
        {
            IEmailService? emailService = Resolve<IEmailService>();

            // Nội dung chi tiết hóa đơn combo
            var comboDetailsString =
                $"<b>Tên Combo:</b> {comboDetails.ComboName}<br />" +
                $"<b>Mã Combo:</b> {combo.ComboId}<br />" +
                $"<b>Giá Combo:</b> {comboDetails.ComboPrice:N0} ₫<br />" +
                $"<b>Thời gian kích hoạt:</b> {combo.StartTime:dd/MM/yyyy HH:mm}<br />" +
                $"<b>Thời gian kết thúc:</b> {combo.EndTime:dd/MM/yyyy HH:mm}<br />";


            // Tổng hợp email
            var emailMessage =
                $"Kính chào {supplierAccount.FirstName},<br /><br />" +
                $"Combo quý khách đăng kí gần hết hạn. Dưới đây là thông tin chi tiết về combo của bạn:<br /><br />" +
                "=====================================<br />" +
                "         CHI TIẾT COMBO<br />" +
                "=====================================<br />" +
                comboDetailsString +
                "=====================================<br />" +
                "<br />Nếu quý khách muốn tiếp tục sử dụng dịch vụ trên nền tảng của chúng tôi vui lòng mua gói Combo mới. có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Nếu quý khách có bất kỳ câu hỏi nào hoặc cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi.<br /><br />" +
                "Trân trọng,<br />" +
                "Đội ngũ Camera service platform";

            // Gửi email xác nhận
            emailService.SendEmail(
                supplierAccount.Email,
                SD.SubjectMail.COMBO_EXPIRED_CONFIRMATION,
                emailMessage
            );
        }

        
    }
}
