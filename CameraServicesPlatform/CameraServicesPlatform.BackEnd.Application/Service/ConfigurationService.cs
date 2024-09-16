using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ConfigurationService : GenericBackendService, IConfigurationService
    {
        private readonly IRepository<Configuration> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationService(IServiceProvider serviceProvider,
            IRepository<Configuration> repository,
            IUnitOfWork unitOfWork
        ) : base(serviceProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

     }
}
