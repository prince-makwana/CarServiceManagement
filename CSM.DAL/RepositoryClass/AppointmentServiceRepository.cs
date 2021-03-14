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
            string appservice;
            if (model != null)
            {
                var serviceEntity = _dbContext.tblServices.FirstOrDefault(s => s.Id == model.ServiceId);
                if (serviceEntity != null)
                {
                    model.ServiceName = serviceEntity.Name;
                    model.Description = serviceEntity.Description;
                    model.CostType = serviceEntity.CostType;
                    model.SalesPart = serviceEntity.SalesPart;
                    model.Price = serviceEntity.Price;

                    model.Discount = serviceEntity.Discount;
                    model.Quantity = serviceEntity.Quantity;
                    model.FixPrice = serviceEntity.FixPrice;
                    


                    var appointmentService = mapper.Map<Database.tblAppointmentService>(model);
                    appointmentService.CreatedBy = model.CreatedBy;
                    appointmentService.CreatedDate = DateTime.Now;
                    _dbContext.tblAppointmentServices.Add(appointmentService);
                    _dbContext.SaveChanges();
                    appservice = appointmentService.Id.ToString();
                    return appservice;
                }
            }
            appservice = "Something Went Wrong";
            return appservice;
        }

        public string DeleteAppointmentService(int id)
        {
            var entity = _dbContext.tblAppointmentServices.Where(a => a.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
        }

        public List<AppointmentService> GetAllAppointmentServices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblAppointmentService, AppointmentService>());
            var mapper = config.CreateMapper();

            var appointmentServiceEntities = _dbContext.tblAppointmentServices.ToList();
            var planningList = _dbContext.tblPlannings.ToList();
            var ServiceNameList = _dbContext.tblServices.ToList();

            List<AppointmentService> appointmentServiceList = new List<AppointmentService>();

            if (appointmentServiceEntities != null)
            {
                foreach (var item in appointmentServiceEntities)
                {
                    AppointmentService appService = mapper.Map<AppointmentService>(item);

                    
                    appService.ServiceName = ServiceNameList.FirstOrDefault(s => s.Id == appService.ServiceId).Name;
                    #region DeleteButton enable-disable

                    var planning = planningList.Any(p => p.AppointmentServiceId == appService.Id);

                    if(planning)
                    {
                        appService.DeleteButton = false;
                    }
                    else
                    {
                        appService.DeleteButton = true; 
                    }

                    #endregion

                    appointmentServiceList.Add(appService);
                }
            }
            return appointmentServiceList;
        }

        public AppointmentService GetAppointmentServiceById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblAppointmentService, AppointmentService>());
            var mapper = config.CreateMapper();

            AppointmentService appointmentService = new AppointmentService();
            var entity = _dbContext.tblAppointmentServices.Find(id);

            if (entity != null)
            {
                appointmentService = mapper.Map<AppointmentService>(entity);
                return appointmentService;
            }
            else
            {
                appointmentService = null;
                return appointmentService;
            }
        }

        public bool UpdateAppoinmentService(AppointmentService model)
        {
            var entity = _dbContext.tblAppointmentServices.Find(model.Id);
            if (entity != null)
            {
                #region Mapping AppointmentService -> Database.tblAppointmentService

                entity.AppointmentId = model.AppointmentId;
                entity.ServiceId = model.ServiceId;
                entity.CostType = model.CostType;
                entity.SalesPart = model.SalesPart;
                entity.Description = model.Description;
                entity.Quantity = model.Quantity;
                entity.PricePerUnit = model.PricePerUnit;
                entity.Price = model.Price;
                entity.Discount = model.Discount;
                entity.FixPrice = model.FixPrice;

                //entity.CreatedBy = model.CreatedBy;
                //entity.CreatedDate = model.CreatedDate;

                //entity.UpdateBy = model.UpdateBy;
                entity.UpdatedDate = model.UpdatedDate;

                #endregion

                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<AppointmentService> getAppointmentServiceByAppointmentId(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblAppointmentService, AppointmentService>());
            var mapper = config.CreateMapper();

            List<AppointmentService> appServiceList = new List<AppointmentService>();

            //var appServices = _dbContext.tblAppointmentServices.Where(a => a.AppointmentId == id).ToList();
            var appServices = GetAllAppointmentServices().Where(a => a.AppointmentId == id).ToList();

            if (appServices.Count() == 0)
            {
                appServiceList = null;
                return appServiceList;
            }
            else
            {
                foreach (var item in appServices)
                {
                    AppointmentService appService = mapper.Map<AppointmentService>(item);
                    appService.ServiceName = item.ServiceName;
                    appServiceList.Add(appService);
                }

                return appServiceList;
            }

        }
    }
}
