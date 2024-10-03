using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class VoucherService : GenericBackendService, IVoucherService
    {
        private readonly IRepository<Vourcher> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VoucherService(
            IRepository<Vourcher> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<AppActionResult> GetAllVoucher(int pageIndex, int pageSize)
        {
            var result = new AppActionResult();

            try
            {
                Expression<Func<Vourcher, bool>>? filter = null;

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                // Set success result
                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetVoucherById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid voucherId))
                {
                    result = BuildAppActionResultError(result, "Invalid Voucher ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.VourcherID == voucherId,
                    pageIndex,
                    pageSize,
                    null,
                    isAscending: true,
                    null
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> GetVoucherBySupplierId(string supplierId, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Vourcher, bool>>? filter = null;
                Guid.TryParse(supplierId, out Guid Id);
                if (!string.IsNullOrEmpty(supplierId))
                {
                    filter = a => a.SupplierID == Id;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.DiscountAmount,
                    isAscending: true,
                    null
                );

                result.Result = pagedResult;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> UpdateVoucher(VoucherUpdateResponseDto voucherResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var voucherRepository = Resolve<IRepository<Vourcher>>();

                Vourcher voucherExist = await voucherRepository.GetById(voucherResponse.VourcherID);

                if (voucherExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                voucherExist.SupplierID = voucherResponse.SupplierID;
                voucherExist.VourcherCode = voucherResponse.VourcherCode;
                voucherExist.Description = voucherResponse.Description;
                voucherExist.DiscountAmount = voucherResponse.DiscountAmount;
                voucherExist.DiscountType = voucherResponse.DiscountType;
                voucherExist.MaxUsageLimit = voucherResponse.MaxUsageLimit;
                voucherExist.UsagePerCustomer = voucherResponse.UsagePerCustomer;
                voucherExist.MinOrderAmount = voucherResponse.MinOrderAmount;
                voucherExist.ValidFrom = voucherResponse.ValidFrom;
                voucherExist.ExpirationDate = voucherResponse.ExpirationDate;
                voucherExist.IsActive = voucherResponse.IsActive;
                voucherExist.UpdatedAt = DateTime.UtcNow;

                await voucherRepository.Update(voucherExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = voucherExist;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> CreateVoucher(VoucherResponseDto voucherResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var listVoucher = Resolve<IRepository<Vourcher>>();
                Vourcher voucher = new Vourcher()
                {
                    VourcherID = Guid.NewGuid(),
                    SupplierID = voucherResponse.SupplierID,
                    VourcherCode = voucherResponse.VourcherCode,
                    Description = voucherResponse.Description,
                    DiscountAmount = voucherResponse.DiscountAmount,
                    DiscountType = voucherResponse.DiscountType,
                    MaxUsageLimit = voucherResponse.MaxUsageLimit,
                    UsagePerCustomer = voucherResponse.UsagePerCustomer,
                    MinOrderAmount = voucherResponse.MinOrderAmount,
                    ValidFrom = voucherResponse.ValidFrom,
                    ExpirationDate = voucherResponse.ExpirationDate
                };

                await listVoucher.Insert(voucher);
                await _unitOfWork.SaveChangesAsync();

                result.Result = voucher;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;

        }



        public async Task<AppActionResult> DeleteVoucher(string voucherId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var supplierRepository = Resolve<IRepository<Vourcher>>();
                Guid.TryParse(voucherId, out Guid id);
                await supplierRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Voucher deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

       
    }
}
