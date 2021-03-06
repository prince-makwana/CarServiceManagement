﻿using AutoMapper;
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
        private readonly Database.AutomotiveDBEntities _dbContext;

        //private readonly Database.ServiceBookingDBEntities _dbContext;


        public AppointmentRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateAppoinment(Appointment model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, Database.tblAppointment>());
            var mapper = config.CreateMapper();
            string appId;
            if(model!= null)
            {
                var appoinment = mapper.Map<Database.tblAppointment>(model);
                appoinment.CreatedBy = model.FName;
                appoinment.CreatedDate = DateTime.Now;
                _dbContext.tblAppointments.Add(appoinment);
                _dbContext.SaveChanges();
                appId = appoinment.Id.ToString();
                return appId;
            }

            appId = null;
            return appId;
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
            var appServiceList = _dbContext.tblAppointmentServices.ToList();
            var planningList = _dbContext.tblPlannings.ToList();
            var dealerList = _dbContext.tblDealers.ToList();

            List<Appointment> appointmentList = new List<Appointment>();

            if(appointmentEntities != null)
            {
                foreach (var item in appointmentEntities)
                {
                    Appointment appointment = mapper.Map<Appointment>(item);

                    #region  DeleteButton enable-disable

                    var appService = appServiceList.Any(a => a.AppointmentId == appointment.Id);
                    var planning = planningList.Any(p => p.AppointmentId == p.Id);
                    appointment.DealerName = dealerList.FirstOrDefault(x => x.Id == appointment.DealerId).DealerName;

                    if (appService == true)
                    {
                        appointment.DeleteButton = false;
                    }
                    else if(planning == true)
                    {
                        appointment.DeleteButton = false;
                    }
                    else
                    {
                        appointment.DeleteButton = true;
                    }
                    

                    #endregion

                    appointmentList.Add(appointment);
                }
            }
            return appointmentList;
        }

        public Appointment GetAppointmentById(int id)
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblAppointment, Appointment>());
            //var mapper = config.CreateMapper();

            //Appointment appointment = new Appointment();
            //var entity = _dbContext.tblAppointments.Find(id);

            //if (entity != null)
            //{
            //    appointment = mapper.Map<Appointment>(entity);
            //    return appointment;
            //}
            //else
            //{
            //    appointment = null;
            //    return appointment;
            //}
            List<Appointment> appList = GetAllAppoinment();
            Appointment entity = appList.FirstOrDefault(a => a.Id == id);

            return entity;
        }

        public bool UpdateAppoinment(Appointment model)
        {
            var entity = _dbContext.tblAppointments.Find(model.Id);
            if(entity != null)
            {
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
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateStatus(UpdateStatus model)
        {
            var appointment = _dbContext.tblAppointments.Find(model.Id);

            if(appointment != null)
            {
                appointment.Status = model.Status;

                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public AppointmentTracker GetAppointmentTracker(int id)
        {
            AppointmentTracker appTracker = new AppointmentTracker();

            var appointment = _dbContext.tblAppointments.FirstOrDefault(a => a.Id == id);

            if (appointment != null)
            {
                var dealer = _dbContext.tblDealers.Select(d => new { d.DealerName, d.Id }).
                    FirstOrDefault(d => d.Id == appointment.DealerId);

                if (dealer != null)
                {
                    var mechanic = _dbContext.tblMechanics.Select(m => new { m.MechanicName, m.MobileNo, m.DealerId }).
                        FirstOrDefault(m => m.DealerId == dealer.Id);

                    if (mechanic != null)
                    {
                        var appservice = _dbContext.tblAppointmentServices.Select(a => new { a.ServiceId, a.AppointmentId }).
                            FirstOrDefault(a => a.AppointmentId == id);

                        if (appservice != null)
                        {
                            var service = _dbContext.tblServices.Select(s => new { s.Id, s.Name }).
                                FirstOrDefault(s => s.Id == appservice.ServiceId);

                            #region AppTracker ViewModel

                            appTracker.FName = appointment.FName;
                            appTracker.LName = appointment.LName;
                            appTracker.LicencePlate = appointment.LicencePlate;
                            appTracker.Status = appointment.Status;
                            appTracker.Email = appointment.Email;
                            appTracker.StartDate = appointment.StartDate;
                            appTracker.EndDate = appointment.EndDate;
                            appTracker.TotalPrice = appointment.TotalPrice;
                            appTracker.TotalTime = appointment.TotalTime;

                            appTracker.DealerName = dealer.DealerName;

                            appTracker.MechanicName = mechanic.MechanicName;
                            appTracker.MobileNo = mechanic.MobileNo;
                            appTracker.ServiceName = service.Name;

                            #endregion

                            return appTracker;
                        }
                        else
                        {
                            appTracker = null;
                            return appTracker;
                        }
                    }
                    else
                    {
                        appTracker = null;
                        return appTracker;
                    }
                }
                else
                {
                    appTracker = null;
                    return appTracker;
                }
            }
            else 
            { 
                appTracker = null;
                return appTracker;
            }

        }

        
    }
}
