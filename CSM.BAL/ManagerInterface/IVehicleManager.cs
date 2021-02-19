using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerInterface
{
    public interface IVehicleManager
    {
        List<Vehicle> GetAllVehicles();
        string CreateVehicle(Vehicle model);
        string UpdateVehicle(Vehicle model);
        string DeleteVehicle(int id);
    }
}
