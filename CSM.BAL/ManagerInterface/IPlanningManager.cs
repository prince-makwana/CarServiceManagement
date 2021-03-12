using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerInterface
{
    public interface IPlanningManager
    {
        bool CreatePlanning(Planning model);
        List<Planning> GetAllPlanning();
        bool UpdatePlanning(Planning model);
        string DeletePlanning(int id);
        List<Planning> getPlanningByAppointmentId(int id);
    }
}
