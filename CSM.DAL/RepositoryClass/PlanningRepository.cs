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
    public class PlanningRepository : IPlanningRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public PlanningRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public bool CreatePlanning(Planning model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Planning, Database.tblPlanning>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var planning = mapper.Map<Database.tblPlanning>(model);

                #region Finding AppointmentServiceId from AppointmentId

                var id = _dbContext.tblAppointmentServices.
                    FirstOrDefault(a => a.AppointmentId == model.AppointmentId).Id;

                #endregion

                if(id != null)
                {
                    //planning.AppointmentServiceId = id;

                   
                    _dbContext.tblPlannings.Add(planning);
                    _dbContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public List<Planning> FilterPlanningByMechanicId(int Id)
        {
            var planningList = GetAllPlanning().Where(p => p.MechanicId == Id).ToList();

            return planningList;
        }

        public List<Planning> GetAllPlanning()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblPlanning, Planning>());
            var mapper = config.CreateMapper();

            var planningEntities = _dbContext.tblPlannings.ToList();
            var mechanicName = _dbContext.tblMechanics.ToList();
            List<Planning> planningList = new List<Planning>();

            if (planningEntities != null)
            {
                foreach (var item in planningEntities)
                {

                    Planning planning = mapper.Map<Planning>(item);
                    planning.MechanicName = mechanicName.FirstOrDefault(m => m.Id == planning.MechanicId).MechanicName;
                    planningList.Add(planning);
                }
            }
            return planningList;
        }

        public bool UpdatePlanning(Planning model)
        {
            var entity = _dbContext.tblPlannings.Find(model.Id);
            if (entity != null)
            {

                #region Mapping Planning -> Database.tblPlanning

                entity.AppointmentId = model.AppointmentId;
                entity.AppointmentServiceId = model.AppointmentServiceId;
                entity.MechanicId = model.MechanicId;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Duration = model.Duration;

        #endregion

                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Planning DeletePlanning(int id)
        {
            Planning planning = new Planning();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblPlanning, Planning>());
            var mapper = config.CreateMapper();

            var entity = _dbContext.tblPlannings.Where(p => p.Id == id).FirstOrDefault();
            if (entity != null)
            {
                planning = mapper.Map<Planning>(entity);
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return planning;
            }
            return null;
        }

        public List<Planning> getPlanningByAppointmentId(int id)
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblPlanning, Planning>());
            //var mapper = config.CreateMapper();

            //List<Planning> planningList = new List<Planning>();

            //var planning = _dbContext.tblPlannings.Where(p => p.AppointmentId == id).ToList();

            //if (planning.Count() == 0)
            //{
            //    planningList = null;
            //    return planningList;
            //}
            //else
            //{
            //    foreach (var item in planning)
            //    {
            //        Planning plan = mapper.Map<Planning>(item);
            //        planningList.Add(plan);
            //    }

            //    return planningList;
            //}

            List<Planning> planningList = GetAllPlanning().Where(p => p.AppointmentId == id).ToList();

            if(planningList == null)
            {
                planningList = null;
                return planningList;
            }
            else
            {
                return planningList;
            }
        }
    }
}
