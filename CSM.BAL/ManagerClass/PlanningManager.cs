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
    public class PlanningManager : IPlanningManager
    {
        private readonly IPlanningRepository _planningRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAppointmentServiceRepository _appointmentServiceRepository;

        public PlanningManager(IPlanningRepository planningRepository, 
            IAppointmentRepository appointmentRepository,
            IAppointmentServiceRepository appointmentServiceRepository)
        {
            _planningRepository = planningRepository;
            _appointmentRepository = appointmentRepository;
            _appointmentServiceRepository = appointmentServiceRepository;
        }

        public string CreatePlanning(Planning model)
        {
            List<Planning> planningList = _planningRepository.FilterPlanningByMechanicId(model.MechanicId);

            var isMechanicAvailable = planningList.Any(p => model.StartDate >= p.StartDate && model.StartDate < p.EndDate);

            if ((planningList.Count() == 0) || !isMechanicAvailable)
            {
                #region Update Total Time, Start Date and Duration in Appointment Table

                var appointment = _appointmentRepository.GetAppointmentById(model.AppointmentId);

                var appointmentService = _appointmentServiceRepository.GetAppointmentServiceById(model.AppointmentServiceId);
                
                //TimeSpan ts = TimeSpan.Parse(appointmentService.Quantity);

                TimeSpan tempDuration = model.EndDate - model.StartDate;

                // Calculating Duration from Planning ViewModel and Comparing it with AppService which is bigger will be allocated

                //if (ts > tempDuration)           
                //{
                //    model.Duration = Convert.ToDecimal(ts.TotalHours);
                //}
                //else
                //{
                //    model.Duration = Convert.ToDecimal(tempDuration.TotalHours);
                //}

                model.Duration = Convert.ToDecimal(tempDuration.TotalHours);

                if (appointment.StartDate == null)
                {
                    appointment.StartDate = model.StartDate;
                }

                if (appointment.TotalTime == null)
                {
                    appointment.TotalTime = 0;
                }

                appointment.TotalTime = appointment.TotalTime + model.Duration;

                #region Filter Planning List By AppId => To set End Date in Appointment Table

                var planningByAppId = _planningRepository.getPlanningByAppointmentId(model.AppointmentId);

                Nullable<DateTime> maxDate;

                if (planningByAppId == null)
                {
                    maxDate = null;
                }
                else
                {
                    maxDate = planningByAppId.Max(p => p.EndDate);

                }
                #endregion

                #region Logic to Set End Date in Appointment Table

                if ((maxDate < model.EndDate) || (appointment.EndDate == null))
                {
                    appointment.EndDate = model.EndDate;
                }
                else
                {
                    appointment.EndDate = maxDate;
                }

                #endregion



                var resUpdateApp = _appointmentRepository.UpdateAppoinment(appointment);

                #endregion

                if (resUpdateApp)
                { 

                    var res = _planningRepository.CreatePlanning(model);
                    if (res)
                    {
                        return "Planning Created Successfully.";
                    }
                    else
                    {
                        return "Something went wrong. Please try after sometime.";
                    }
                }
                else
                {
                    return "Unable to create Plan.";
                }
            }
            else
            {
                return "Mechanic is not Available. Choose other Date.";
            }
        }

        public string DeletePlanning(int id)
        {
            Planning planning = _planningRepository.DeletePlanning(id);

            Appointment appointment = _appointmentRepository.GetAppointmentById(planning.AppointmentId);

            if(appointment.TotalTime == null)
            {
                appointment.TotalTime = 0;
            }

            if(planning.Duration == null)
            {
                planning.Duration = 0;
            }

            appointment.TotalTime = appointment.TotalTime - planning.Duration;

            bool res = _appointmentRepository.UpdateAppoinment(appointment);

            if (planning != null && res)
            {
                return "Deleted Successfully.";
            }
            else
            {
                return "Something went wrong. Please try after sometime.";
            }
        }

        public List<Planning> GetAllPlanning()
        {
            return _planningRepository.GetAllPlanning();
        }

        public List<Planning> getPlanningByAppointmentId(int id)
        {
            return _planningRepository.getPlanningByAppointmentId(id);
        }

        public bool UpdatePlanning(Planning model)
        {
            return _planningRepository.UpdatePlanning(model);
        }

    }
}
