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

        public string CreateAppoinment(Appointment model)
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

        public string UpdateAppoinment(Appointment model)
        {
            return _appointmentRepository.UpdateAppoinment(model);
        }
    }
}
