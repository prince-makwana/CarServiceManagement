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
        private readonly IAppointmentServiceRepository _appointmentServiceRepository;
        private readonly IPlanningRepository _planningRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository, 
            IAppointmentServiceRepository appointmentServiceRepository, 
            IPlanningRepository planningRepository)
        {
            _appointmentRepository = appointmentRepository;
            _appointmentServiceRepository = appointmentServiceRepository;
            _planningRepository = planningRepository;
        }

        public Appointment AppointmentEdit(int id)
        {
            Appointment appointment = new Appointment();

            appointment = _appointmentRepository.GetAppointmentById(id);

            if (appointment != null)
            {
                List<Planning> planningList = _planningRepository.getPlanningByAppointmentId(id);
                List<AppointmentService> appointmentServiceList = _appointmentServiceRepository.getAppointmentServiceByAppointmentId(id);

                appointment.appointmentServicesList = appointmentServiceList;
                appointment.planningList = planningList;

                return appointment;
            }
            else
            {
                appointment = null;
                return appointment;
            }
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

        public AppointmentTracker GetAppointmentTracker(int id)
        {
            return _appointmentRepository.GetAppointmentTracker(id);
        }

        public bool UpdateAppoinment(Appointment model)
        {
            return _appointmentRepository.UpdateAppoinment(model);
        }

        public bool UpdateStatus(UpdateStatus model)
        {
            return _appointmentRepository.UpdateStatus(model);
        }
    }
}
