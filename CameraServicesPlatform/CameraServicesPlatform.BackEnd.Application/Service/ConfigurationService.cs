using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Domain.Models;


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
