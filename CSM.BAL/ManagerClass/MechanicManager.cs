using CSM.BAL.ManagerInterface;
using CSM.DAL.RepositoryInterface;
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
    }
}
