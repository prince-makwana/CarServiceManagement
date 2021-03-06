using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerInterface
{
    public interface IMechanicManager
    {
        string CreateMechanic(Mechanic model);
        string DeleteMechanic(int id);
        List<Mechanic> GetAllMechanics();
        string UpdateMechanic(Mechanic model);
        List<Mechanic> MechanicDropdown(int id);
    }
}
