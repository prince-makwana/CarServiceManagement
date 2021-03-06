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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Service, Database.tblService>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var service = mapper.Map<Database.tblService>(model);

                service.CreatedBy = model.CreatedBy;
                service.CreatedDate = DateTime.Now;

                _dbContext.tblServices.Add(service);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
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

            List<Service> serviceList = new List<Service>();

            if (serviceEntities != null)
            {
                foreach (var item in serviceEntities)
                {
                    Service service = mapper.Map<Service>(item);
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
