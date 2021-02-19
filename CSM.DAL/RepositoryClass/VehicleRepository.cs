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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.AutoMotiveProjectEntities _dbContext;

        public VehicleRepository()
        {
            _dbContext = new Database.AutoMotiveProjectEntities();
        }

        public string CreateVehicle(Vehicle model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle, Database.tblVehicle>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var vehicle = mapper.Map<Database.tblVehicle>(model);

                vehicle.CreatedBy = model.CreatedBy;
                vehicle.CreatedDate = DateTime.Now;

                _dbContext.tblVehicles.Add(vehicle);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }

        public string DeleteVehicle(int id)
        {
            var entity = _dbContext.tblVehicles.Where(v => v.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
        }

        public List<Vehicle> GetAllVehicles()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblVehicle, Vehicle>());
            var mapper = config.CreateMapper();

            var vehicleEntities = _dbContext.tblVehicles.ToList();

            List<Vehicle> vehicleList = new List<Vehicle>();

            if (vehicleEntities != null)
            {
                foreach (var item in vehicleEntities)
                {
                    Vehicle vehicle = mapper.Map<Vehicle>(item);
                    vehicleList.Add(vehicle);
                }
            }
            return vehicleList;
        }

        public string UpdateVehicle(Vehicle model)
        {
            var entity = _dbContext.tblVehicles.Find(model.Id);
            if (entity != null)
            {

                #region Mapping Vehicle -> Database.tblVehicle

                entity.Description = model.Description;
                entity.Brand = model.Brand;
                entity.LicencePlate = model.LicencePlate;
                entity.Model = model.Model;
                entity.MeterValue = model.MeterValue;
                entity.RegDate = model.RegDate;
                entity.Weight = model.Weight;
                entity.MCHCode = model.MCHCode;
                entity.Vin = model.Vin;
                entity.EngNo = model.EngNo;
                entity.Colour = model.Colour;
                //entity.CreatedBy = model.CreatedBy;
                //entity.CreatedDate = model.CreatedDate;
                //entity.UpdatedBy = model.UpdatedBy;
                //entity.UpdatedDate = model.UpdatedDate;
                entity.CustomerId = model.CustomerId;

                #endregion

                entity.UpdatedBy = model.UpdatedBy;
                entity.UpdatedDate = DateTime.Now;

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
