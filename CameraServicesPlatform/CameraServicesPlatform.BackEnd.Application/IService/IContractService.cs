﻿using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IContractService
    {
        Task<AppActionResult> CreateContract(CreateContractRequestDTO request);
        Task<AppActionResult> UpdateContract(string contractId, ContractRequestDTO request);
        Task<AppActionResult> DeleteContract(string contractId);
        Task<AppActionResult> GetContractById(string contractId);
        Task<AppActionResult> GetAllContracts(int pageIndex, int pageSize);
        Task<AppActionResult> GetContractByOrderID(string orderID, int pageIndex, int pageSize);
    }
}
