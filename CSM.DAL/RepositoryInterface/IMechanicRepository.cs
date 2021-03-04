using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryInterface
{
    public interface IMechanicRepository
    {
        string CreateMechanic(Mechanic model);
        string DeleteMechanic(int id);
        List<Mechanic> GetAllMechanics();
        string UpdateMechanic(Mechanic model);
    }
}
