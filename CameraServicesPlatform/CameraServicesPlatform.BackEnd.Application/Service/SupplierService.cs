using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using CameraServicesPlatform.BackEnd.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class SupplierService : GenericBackendService, ISupplierService
    {
        private readonly IMapper _mapper;
        private IRepository<Supplier> _repository;
        private IUnitOfWork _unitOfWork;


        public SupplierService(
            IRepository<Supplier> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<AppActionResult> GetAllSupplier(int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Supplier, bool>>? filter = null;

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.SupplierName,
                    isAscending: true,
                    includes: new Expression<Func<Supplier, object>>[]
                    {
 
                        //a => a.Account,
  
                    }
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

        public async Task<AppActionResult> GetSupplierById(string id, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                if (!Guid.TryParse(id, out Guid supplierId))
                {
                    result = BuildAppActionResultError(result, "Invalid supplier ID format.");
                    return result;
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    a => a.SupplierID == supplierId,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.SupplierName,
                    isAscending: true,
                    includes: new Expression<Func<Supplier, object>>[]
                    {
                         //a => a.Account,
                     }
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

        public async Task<AppActionResult> GetSupplierByName([FromQuery] string? supplierNamefilter, int pageIndex, int pageSize)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                Expression<Func<Supplier, bool>>? filter = null;

                if (!string.IsNullOrEmpty(supplierNamefilter))
                {
                    filter = a => a.SupplierName.Contains(supplierNamefilter);
                }

                var pagedResult = await _repository.GetAllDataByExpression(
                    filter,
                    pageIndex,
                    pageSize,
                    orderBy: a => a.SupplierName,
                    isAscending: true,
                    includes: new Expression<Func<Supplier, object>>[]
                    {
                //a => a.Account,
                     }
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

        public async Task<AppActionResult> UpdateSupplier(SupplierUpdateResponseDto supplierResponse)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var supplierRepository = Resolve<IRepository<Supplier>>();

                Supplier supplierExist = await supplierRepository.GetById(supplierResponse.SupplierID);

                if (supplierExist == null)
                {
                    result.IsSuccess = false;
                    return result;
                }

                var firebaseService = Resolve<IFirebaseService>();
                var pathName = SD.FirebasePathName.SUPPLIER_PREFIX + $"{supplierExist.AccountID}{Guid.NewGuid()}.jpg";
                var upload = await firebaseService.UploadFileToFirebase(supplierResponse.SupplierLogo, pathName);
                var imgUrl = upload.Result.ToString();

                supplierExist.SupplierName = supplierResponse.SupplierName;
                supplierExist.SupplierDescription = supplierResponse.SupplierDescription;
                supplierExist.SupplierAddress = supplierResponse.SupplierAddress;
                supplierExist.ContactNumber = supplierResponse.ContactNumber;
                supplierExist.SupplierLogo = imgUrl;
                supplierExist.BlockReason = supplierResponse.BlockReason;
                supplierExist.BlockedAt = supplierResponse.BlockedAt;
                if(supplierResponse.BlockedAt != null)
                {
                    supplierExist.UpdatedAt = DateTime.UtcNow;
                }
                
                
                await supplierRepository.Update(supplierExist);

                await _unitOfWork.SaveChangesAsync();

                result.Result = supplierExist;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }
        public async Task<AppActionResult> CreateSupplier(SupplierResponseDto supplierResponse)
        {
            AppActionResult result = new AppActionResult();

            try
            {
                var firebaseService = Resolve<IFirebaseService>();

                var pathName = SD.FirebasePathName.SUPPLIER_PREFIX + $"{supplierResponse.AccountID}{Guid.NewGuid()}.jpg";
                var upload = await firebaseService.UploadFileToFirebase(supplierResponse.SupplierLogo, pathName);
                var imgUrl = upload.Result.ToString();
                var listSupplier = Resolve<IRepository<Supplier>>();

                Supplier supplier = new Supplier()
                {
                    SupplierID = Guid.NewGuid(),
                    AccountID = supplierResponse.AccountID,
                    SupplierName = supplierResponse.SupplierName,
                    SupplierDescription = supplierResponse.SupplierDescription,
                    SupplierAddress = supplierResponse.SupplierAddress,
                    ContactNumber = supplierResponse.ContactNumber,
                    SupplierLogo = imgUrl,
                    BlockReason = null,
                    BlockedAt = null,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    AccountBalance = supplierResponse.AccountBalance,
                    VourcherID = null
                };

                await listSupplier.Insert(supplier);
                await _unitOfWork.SaveChangesAsync();

                result.Result = supplier;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

        public async Task<AppActionResult> DeleteSupplier(string supplierId)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var supplierRepository = Resolve<IRepository<Supplier>>();
                Guid.TryParse(supplierId, out Guid id);
                await supplierRepository.DeleteById(id);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Result = "Suppllier deleted successfully.";
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }

            return result;
        }

    }
}
