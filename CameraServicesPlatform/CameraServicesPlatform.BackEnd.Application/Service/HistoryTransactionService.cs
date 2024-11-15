using AutoMapper;
using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    /*public class HistoryTransactionService : GenericBackendService, IHistoryTransactionService
    {
        private readonly IRepository<Report> _reportRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HistoryTransactionService(
            IRepository<Report> reportRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppActionResult> GetAllHistoryTransaction(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<AppActionResult> GetHistoryTransactionById(string id, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
