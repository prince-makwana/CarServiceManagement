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
    public class ServiceRepository : IServiceRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public ServiceRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateService(Service model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Service, Database.tblService>().ForMember(x => x.Quantity, y => y.Ignore()));
            var mapper = config.CreateMapper();
            if (model != null)
            {

                var service = mapper.Map<Database.tblService>(model);

                service.Quantity = Convert.ToDecimal(TimeSpan.Parse(model.Quantity).TotalHours);

                service.CreatedBy = model.CreatedBy;
                service.CreatedDate = DateTime.Now;
                service.Quantity = Convert.ToDecimal(TimeSpan.Parse(model.Quantity).TotalHours);
                _dbContext.tblServices.Add(service);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }

        public Service GetServiceById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblService, Service>());
            var mapper = config.CreateMapper();

            Service service = new Service();
            var entity = _dbContext.tblServices.Find(id);

            if (entity != null)
            {
                service = mapper.Map<Service>(entity);
                return service;
            }
            else
            {
                service = null;
                return service;
            }
        }


        public string DeleteService(int id)
        {
            var entity = _dbContext.tblServices.Where(s => s.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
        }

        public List<Service> GetAllServices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblService, Service>());
            var mapper = config.CreateMapper();

            var serviceEntities = _dbContext.tblServices.ToList();
            var appointmentList = _dbContext.tblAppointmentServices.ToList();
            var dealerList = _dbContext.tblDealers.ToList();

            List<Service> serviceList = new List<Service>();

            if (serviceEntities != null)
            {
                foreach (var item in serviceEntities)
                {
                    Service service = mapper.Map<Service>(item);
                    service.Quantity = TimeSpan.FromHours((double)item.Quantity).ToString(@"hh\:mm");
                    var dealer = dealerList.Select(s => new { s.DealerName, s.Id }).
                        FirstOrDefault(s => s.Id == item.DealerId);

                    #region DeleteButton Enable-Disable

                    var appointment = appointmentList.Any(a => a.ServiceId == service.Id);
                    if(appointment == true)
                    {
                        service.DeleteButton = false;
                    }
                    else
                    {
                        service.DeleteButton = true;
                    }

                    #endregion

                    service.DealerName = dealer.DealerName;
                
                    serviceList.Add(service);
                }
            }
            return serviceList;
        }

        public string UpdateService(Service model)
        {
            var entity = _dbContext.tblServices.Find(model.Id);
            if (entity != null)
            {

                #region Mapping Service -> Database.tblService

                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.FixPrice = model.FixPrice;
                entity.Discount = model.Discount;
                entity.Description = model.Description;
                entity.SalesPart = model.SalesPart;
                entity.PricePerUnit = model.PricePerUnit;
                entity.CostType = model.CostType;
                entity.Quantity = Convert.ToDecimal(TimeSpan.Parse(model.Quantity).TotalHours);

                #endregion

                entity.UpdatedBy = model.UpdatedBy;
                entity.UpdatedDate = DateTime.Now.ToString();

                //_dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                _dbContext.SaveChanges();
                return "updated Successfully";
            }
            else
            {
                return "Something went wrong plz try after some time.";
            }
        }

        public List<Service> ServicesDropdown(int id)
        {
            List<Service> serviceList = new List<Service>();

            var servicesData = _dbContext.tblServices.Where(s => s.DealerId == id).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblService, Service>());
            var mapper = config.CreateMapper();

            if (servicesData != null)
            {
                foreach (var item in servicesData)
                {
                    Service service = mapper.Map<Service>(item);

                    serviceList.Add(service);
                }
            }

            return serviceList;
        }
    }
}
