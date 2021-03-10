using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSM.BAL.ManagerInterface;
using CSM.DAL.RepositoryInterface;
using CSM.Models;

namespace CSM.BAL.ManagerClass
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment CreateAppoinment(Appointment model)
        {
            return _appointmentRepository.CreateAppoinment(model);
        }

        public string DeleteAppoinment(int id)
        {
            return _appointmentRepository.DeleteAppoinment(id);
        }

        public List<Appointment> GetAllAppoinment()
        {
            return _appointmentRepository.GetAllAppoinment();
        }

        public AppointmentTracker GetAppointmentTracker(int id)
        {
            return _appointmentRepository.GetAppointmentTracker(id);
        }

        public string UpdateAppoinment(Appointment model)
        {
            return _appointmentRepository.UpdateAppoinment(model);
        }

        public bool UpdateStatus(UpdateStatus model)
        {
            return _appointmentRepository.UpdateStatus(model);
        }
    }
}
