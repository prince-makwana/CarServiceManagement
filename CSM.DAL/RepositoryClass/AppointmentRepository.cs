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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public AppointmentRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateAppoinment(Appointment model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, Database.tblAppointment>());
            var mapper = config.CreateMapper();
            if(model!= null)
            {
                var appoinment = mapper.Map<Database.tblAppointment>(model);

                _dbContext.tblAppointments.Add(appoinment);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }

        public string DeleteAppoinment(int id)
        {
            var entity = _dbContext.tblAppointments.Where(a => a.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
        }

        public List<Appointment> GetAllAppoinment()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblAppointment, Appointment>());
            var mapper = config.CreateMapper(); 

            var appointmentEntities = _dbContext.tblAppointments.ToList();

            List<Appointment> appointmentList = new List<Appointment>();

            if(appointmentEntities != null)
            {
                foreach (var item in appointmentEntities)
                {
                    Appointment appoinment = mapper.Map<Appointment>(item);
                    appointmentList.Add(appoinment);
                }
            }
            return appointmentList;
        }

        public string UpdateAppoinment(Appointment model)
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, Database.tblAppointment>());
            //var mapper = config.CreateMapper();
            var entity = _dbContext.tblAppointments.Find(model.Id);
            if(entity != null)
            {
                //entity = mapper.Map<Database.tblAppointment>(model);
                #region Mapping Appointment -> Database.tblAppointment
                //entity.CustomerId = model.CustomerId;
                //entity.LicencePlate = model.LicencePlate;
                entity.FName = model.FName;
                entity.LName = model.LName;
                entity.MobileNo = model.MobileNo;
                entity.Email = model.Email;
                entity.City = model.City;
                entity.Country = model.Country;
                entity.Model = model.Model;
                entity.Brand = model.Brand;
                //entity.DealerId = model.DealerId;
                entity.Status = model.Status;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.TotalPrice = model.TotalPrice;
                entity.TotalTime = model.TotalTime;
                //entity.CreatedBy = model.CreatedBy;
                //entity.CreatedDate = model.CreatedDate;
                //entity.UpdatedBy = model.UpdatedBy;
                //entity.UpdatedDate = model.UpdatedDate;

#endregion

                //_dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                _dbContext.SaveChanges();
                return "updated Successfully";
            }
            else
            {
                return "Something went wrong plz try after some time.";
            }

        }
    }
}
