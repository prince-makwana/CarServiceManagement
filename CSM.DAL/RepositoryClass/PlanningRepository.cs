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

        //public string CreatePlanning(Planning model)
        //{
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, Database.tblAppointment>());
        //    var mapper = config.CreateMapper();
        //    if (model != null)
        //    {
        //        var appoinment = mapper.Map<Database.tblAppointment>(model);
                
        //        appoinment.CreatedDate = DateTime.Now;
        //        _dbContext.tblAppointments.Add(appoinment);
        //        _dbContext.SaveChanges();
        //        return "Created Succesfully";
        //    }

        //    return "Plz try after Some time or Contact admin";
        //}
    }
}
