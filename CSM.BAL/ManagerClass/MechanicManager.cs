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
    public class MechanicManager : IMechanicManager
    {
        private readonly IMechanicRepository _mechanicRepository;

        public MechanicManager(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        public string CreateMechanic(Mechanic model)
        {
            return _mechanicRepository.CreateMechanic(model);
        }

        public string DeleteMechanic(int id)
        {
            return _mechanicRepository.DeleteMechanic(id);
        }

        public List<Mechanic> GetAllMechanics()
        {
            return _mechanicRepository.GetAllMechanics();
        }

        public List<Mechanic> MechanicDropdown(int id)
        {
            return _mechanicRepository.MechanicDropdown(id);
        }

        public string UpdateMechanic(Mechanic model)
        {
            return _mechanicRepository.UpdateMechanic(model);
        }
    }
}
