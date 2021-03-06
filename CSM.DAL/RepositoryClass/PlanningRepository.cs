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
    public class PlanningRepository : IPlanningRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public PlanningRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreatePlanning(Planning model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Planning, Database.tblPlanning>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var planning = mapper.Map<Database.tblPlanning>(model);

                #region Finding AppointmentServiceId from AppointmentId

                var id = _dbContext.tblAppointmentServices.
                    First(a => a.AppointmentId == model.AppointmentId).Id;

                #endregion

                if(id != null)
                {
                    planning.Duration = DateTime.Now;
                    planning.AppointmentServiceId = id;

                    _dbContext.tblPlannings.Add(planning);
                    _dbContext.SaveChanges();
                    return "Created Succesfully";
                }
            }

            return "Plz try after Some time or Contact admin";
        }

        public List<Planning> GetAllPlanning()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblPlanning, Planning>());
            var mapper = config.CreateMapper();

            var planningEntities = _dbContext.tblPlannings.ToList();

            List<Planning> planningList = new List<Planning>();

            if (planningEntities != null)
            {
                foreach (var item in planningEntities)
                {
                    Planning planning = mapper.Map<Planning>(item);
                    planningList.Add(planning);
                }
            }
            return planningList;
        }
    }
}
