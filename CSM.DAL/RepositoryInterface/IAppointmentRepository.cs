using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryInterface
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppoinment();
        string CreateAppoinment(Appointment model);
        string UpdateAppoinment(Appointment model);
        string DeleteAppoinment(int id);
        AppointmentTracker GetAppointmentTracker(int id);
    }
}
