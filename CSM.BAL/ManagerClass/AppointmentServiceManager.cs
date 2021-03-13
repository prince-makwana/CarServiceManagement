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
            Appointment appointment = _appointmentRepository.GetAppointmentById(model.AppointmentId);
            
            #region Calculate Price Logic

            if(model.FixPrice != 0)
            {
                appointment.TotalPrice = appointment.TotalPrice + model.FixPrice;
            }
            else
            {
                var Discount = model.Price * (model.Discount / 100); 
                appointment.TotalPrice = appointment.TotalPrice + (model.Price - Discount);
            }

            #endregion

            bool res = _appointmentRepository.UpdateAppoinment(appointment);

            if(res)
            {
                return _appointmentServiceRepository.CreateAppointmentService(model);
            }
            else
            {
                return "Please Try after sometime.";
            }
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

        public AppointmentService GetAppointmentServiceById(int id)
        {
            return _appointmentServiceRepository.GetAppointmentServiceById(id);
        }

        public bool UpdateAppoinmentService(AppointmentService model)
        {
            return _appointmentServiceRepository.UpdateAppoinmentService(model);
        }
    }
}
