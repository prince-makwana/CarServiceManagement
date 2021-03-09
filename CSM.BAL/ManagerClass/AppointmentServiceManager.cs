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
    public class AppointmentServiceManager : IAppointmentServiceManager
    {
        private readonly IAppointmentServiceRepository _appointmentServiceRepository;

        public AppointmentServiceManager(IAppointmentServiceRepository appointmentServiceRepository)
        {
            _appointmentServiceRepository = appointmentServiceRepository;
        }
        public string CreateAppointmentService(AppointmentService model)
        {
            return _appointmentServiceRepository.CreateAppointmentService(model);
        }

        public string DeleteAppointmentService(int id)
        {
            return _appointmentServiceRepository.DeleteAppointmentService(id);
        }

        public List<AppointmentService> GetAllAppointmentServices()
        {
            return _appointmentServiceRepository.GetAllAppointmentServices();
        }

        public bool UpdateAppoinmentService(AppointmentService model)
        {
            return _appointmentServiceRepository.UpdateAppoinmentService(model);
        }
    }
}
