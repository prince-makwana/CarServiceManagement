using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryInterface
{
    public interface IPlanningRepository
    {
        bool CreatePlanning(Planning model);
        List<Planning> GetAllPlanning();
        bool UpdatePlanning(Planning model);
        Planning DeletePlanning(int id);
        List<Planning> getPlanningByAppointmentId(int id);
        List<Planning> FilterPlanningByMechanicId(int Id);
    }
}
