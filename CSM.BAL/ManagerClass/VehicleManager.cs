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
    public class VehicleManager : IVehicleManager
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public string CreateVehicle(Vehicle model)
        {
            return _vehicleRepository.CreateVehicle(model);
        }

        public string DeleteVehicle(int id)
        {
            return _vehicleRepository.DeleteVehicle(id);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }

        public CustomerVehicle GetCustomerVehicle(string LicencePlate)
        {
            return _vehicleRepository.GetCustomerVehicle(LicencePlate);
        }

        public string UpdateVehicle(Vehicle model)
        {
            return _vehicleRepository.UpdateVehicle(model);
        }
    }
}
