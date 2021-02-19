using CSM.BAL.ManagerInterface;
using CSM.DAL.RepositoryInterface;
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
    }
}
