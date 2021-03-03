using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryInterface
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
        string CreateVehicle(Vehicle model);
        string UpdateVehicle(Vehicle model);
        string DeleteVehicle(int id);
        CustomerVehicle GetCustomerVehicle(string LicencePlate);

        List<Vehicle> GetVehiclesByCustomerId(int id);
    }
}
