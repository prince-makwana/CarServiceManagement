using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerInterface
{
    public interface IAppointmentServiceManager
    {
        string CreateAppointmentService(AppointmentService model);
        List<AppointmentService> GetAllAppointmentServices();
        bool UpdateAppoinmentService(AppointmentService model);
        string DeleteAppointmentService(int id);
        List<AppointmentService> getAppointmentServiceByAppointmentId(int id);
        AppointmentService GetAppointmentServiceById(int id);
    }
}
