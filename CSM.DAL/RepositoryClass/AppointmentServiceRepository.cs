using AutoMapper;
using CSM.DAL.RepositoryInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryClass
{
    public class AppointmentServiceRepository : IAppointmentServiceRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;

        //private readonly Database.ServiceBookingDBEntities _dbContext;


        public AppointmentServiceRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateAppointmentService(AppointmentService model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AppointmentService, Database.tblAppointmentService>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var appointmentService = mapper.Map<Database.tblAppointmentService>(model);
                appointmentService.CreatedBy = model.CreatedBy;
                appointmentService.CreatedDate = DateTime.Now;
                _dbContext.tblAppointmentServices.Add(appointmentService);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }

        public List<AppointmentService> GetAllAppointmentServices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblAppointmentService, AppointmentService>());
            var mapper = config.CreateMapper();

            var appointmentServiceEntities = _dbContext.tblAppointmentServices.ToList();

            List<AppointmentService> appointmentServiceList = new List<AppointmentService>();

            if (appointmentServiceEntities != null)
            {
                foreach (var item in appointmentServiceEntities)
                {
                    AppointmentService appoinment = mapper.Map<AppointmentService>(item);
                    appointmentServiceList.Add(appoinment);
                }
            }
            return appointmentServiceList;
        }
    }
}
