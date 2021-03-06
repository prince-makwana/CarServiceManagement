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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public VehicleRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateVehicle(Vehicle model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle, Database.tblVehicle>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                if (!isVehicleAvailable(model.LicencePlate))
                {
                    var vehicle = mapper.Map<Database.tblVehicle>(model);

                    vehicle.CreatedBy = model.CreatedBy;
                    vehicle.CreatedDate = DateTime.Now;

                    _dbContext.tblVehicles.Add(vehicle);
                    _dbContext.SaveChanges();
                    return "Created Succesfully";
                }
                return "Vehicle is Available";
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

        public CustomerVehicle GetCustomerVehicle(string LicencePlate)
        {
            CustomerVehicle customerVehicle = new CustomerVehicle();

            Database.tblVehicle vehicle = (from v in _dbContext.tblVehicles
                                           where v.LicencePlate.Equals(LicencePlate)
                                           select v).FirstOrDefault();

            if(vehicle !=null)
            {
                Database.tblCustomer customer = _dbContext.tblCustomers.FirstOrDefault(c => c.Id == vehicle.CustomerId);

                if(customer != null)
                {
                    #region Preparation of CustomerVehicle object

                    customerVehicle.CustomerId = customer.Id;
                    customerVehicle.CustomerName = customer.CustomerName;
                    customerVehicle.FName = customer.FName;
                    customerVehicle.LName = customer.LName;
                    customerVehicle.Address = customer.Address;
                    customerVehicle.ZipCode = customer.ZipCode;
                    customerVehicle.City = customer.City;
                    customerVehicle.Country = customer.Country;
                    customerVehicle.CustomerNo = customer.CustomerNo;

                    customerVehicle.VehicleId = vehicle.Id;
                    customerVehicle.Brand = vehicle.Brand;
                    customerVehicle.Model = vehicle.Model;
                    customerVehicle.LicencePlate = vehicle.LicencePlate;
                    customerVehicle.MeterValue = vehicle.MeterValue;
                    customerVehicle.RegDate = vehicle.RegDate;
                    customerVehicle.Weight = vehicle.Weight;
                    customerVehicle.Vin = vehicle.Vin;
                    customerVehicle.EngNo = vehicle.EngNo;
                    customerVehicle.MCHCode = vehicle.MCHCode;
                    customerVehicle.Colour = vehicle.Colour;


                    #endregion

                    return customerVehicle;
                }
                else
                {
                    customerVehicle = null;
                    return customerVehicle;
                }

            }
            else
            {
                customerVehicle = null;
                return customerVehicle;
            }
            
            
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

        public List<Vehicle> GetVehiclesByCustomerId(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblVehicle, Vehicle>());
            var mapper = config.CreateMapper();

            List<Vehicle> vehicleList = new List<Vehicle>();

            var vehicleEntities = _dbContext.tblVehicles.Where(v => v.CustomerId == id).ToList();

            if(vehicleEntities.Count() != 0)
            {
                foreach (var item in vehicleEntities)
                {
                    Vehicle vehicle = mapper.Map<Vehicle>(item);
                    vehicleList.Add(vehicle);
                }
                return vehicleList;
            }

            return vehicleList;
        }


        private bool isVehicleAvailable(string LicencePlate)
        {
            bool isAvail = _dbContext.tblVehicles.Any(v => v.LicencePlate == LicencePlate);

            return isAvail;
        }
    }
}
