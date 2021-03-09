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
    public class PlanningManager : IPlanningManager
    {
        private readonly IPlanningRepository _planningRepository;

        public PlanningManager(IPlanningRepository planningRepository)
        {
            _planningRepository = planningRepository;
        }

        public string CreatePlanning(Planning model)
        {
            return _planningRepository.CreatePlanning(model);
        }

        public string DeletePlanning(int id)
        {
            return _planningRepository.DeletePlanning(id);
        }

        public List<Planning> GetAllPlanning()
        {
            return _planningRepository.GetAllPlanning();
        }

        public bool UpdatePlanning(Planning model)
        {
            return _planningRepository.UpdatePlanning(model);
        }

    }
}
