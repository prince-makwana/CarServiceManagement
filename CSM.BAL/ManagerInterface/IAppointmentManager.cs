using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSM.Models;

namespace CSM.BAL.ManagerInterface
{
    public interface IAppointmentManager
    {
        List<Appointment> GetAllAppoinment();
        string CreateAppoinment(Appointment model);
        bool UpdateAppoinment(Appointment model);
        string DeleteAppoinment(int id);
        AppointmentTracker GetAppointmentTracker(int id);
        bool UpdateStatus(UpdateStatus model);
    }
}
