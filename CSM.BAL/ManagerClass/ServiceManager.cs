using CSM.BAL.ManagerInterface;
using CSM.DAL.RepositoryInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerClass
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public string CreateService(Service model)
        {
            return _serviceRepository.CreateService(model);
        }

        public string DeleteService(int id)
        {
            return _serviceRepository.DeleteService(id);
        }

        public List<Service> GetAllServices()
        {
            return _serviceRepository.GetAllServices();
        }

        public string UpdateService(Service model)
        {
            return _serviceRepository.UpdateService(model);
        }
    }
}
