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
            List<Planning> planningList = _planningRepository.FilterPlanningByMechanicId(model.MechanicId);

            var isMechanicAvailable = planningList.Any(p => model.StartDate >= p.StartDate && model.StartDate < p.EndDate);

            if ((planningList.Count() == 0) || !isMechanicAvailable)
            {
                var res = _planningRepository.CreatePlanning(model);
                if (res)
                {
                    return "Planning Created Successfully.";
                }
                else
                {
                    return "something went wrong. Please try after sometime.";
                }
            }
            //else if(!isMechanicAvailable)
            //{
            //    var res = _planningRepository.CreatePlanning(model);
            //    if (res)
            //    {
            //        return "Planning Created Successfully.";
            //    }
            //    else
            //    {
            //        return "something went wrong. Please try after sometime.";
            //    }
            //}
            else
            {
                return "Mechanic is not Available. Choose other Date.";
            }
        }

        public string DeletePlanning(int id)
        {
            return _planningRepository.DeletePlanning(id);
        }

        public List<Planning> GetAllPlanning()
        {
            return _planningRepository.GetAllPlanning();
        }

        public List<Planning> getPlanningByAppointmentId(int id)
        {
            return _planningRepository.getPlanningByAppointmentId(id);
        }

        public bool UpdatePlanning(Planning model)
        {
            return _planningRepository.UpdatePlanning(model);
        }

    }
}
