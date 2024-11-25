using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Data;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service.Extension
{
    public class ComboService : GenericBackendService, IComboService
    {
        private readonly IMapper _mapper;
        private IRepository<Combo> _comboRepository;
        private IUnitOfWork _unitOfWork;


        public ComboService(
            IRepository<Combo> comboRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider,
            IDbContext context
        ) : base(serviceProvider)
        {
            _comboRepository = comboRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<AppActionResult> CreateCombo(ComboCreateDto voucherResponse)
        {
            throw new NotImplementedException();
        }

        public Task<AppActionResult> GetAllCombo(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AppActionResult> GetComboById(string id, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AppActionResult> UpdateCombo(ComboUpdateResponseDto voucherResponse)
        {
            throw new NotImplementedException();
        }
    }
}
