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
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentServiceManager(IAppointmentServiceRepository appointmentServiceRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentServiceRepository = appointmentServiceRepository;
            _appointmentRepository = appointmentRepository;
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

        public List<AppointmentService> getAppointmentServiceByAppointmentId(int id)
        {
            return _appointmentServiceRepository.getAppointmentServiceByAppointmentId(id);
        }

        public bool UpdateAppoinmentService(AppointmentService model)
        {
            return _appointmentServiceRepository.UpdateAppoinmentService(model);
        }

    }
}
