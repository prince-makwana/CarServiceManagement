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
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public MechanicRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateMechanic(Mechanic model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Mechanic, Database.tblMechanic>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var mechanic = mapper.Map<Database.tblMechanic>(model);

                mechanic.CreatedBy = model.MechanicName;
                mechanic.CreatedDate = DateTime.Now;

                _dbContext.tblMechanics.Add(mechanic);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }


        public string DeleteMechanic(int id)
        {
            var entity = _dbContext.tblMechanics.Where(m => m.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
        }

        public List<Mechanic> GetAllMechanics()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblMechanic, Mechanic>());
            var mapper = config.CreateMapper();

            var mechanicEntities = _dbContext.tblMechanics.ToList();

            List<Mechanic> mechanicList = new List<Mechanic>();

            if (mechanicEntities != null)
            {
                foreach (var item in mechanicEntities)
                {
                    Mechanic mechanic = mapper.Map<Mechanic>(item);

                    #region  DeleteButton enable-disable

                    var dealer = _dbContext.tblDealers.Select(m => new { m.DealerName, m.Id }).
                        FirstOrDefault(m => m.Id == item.DealerId);

                    var planning = _dbContext.tblPlannings.Any(p => p.MechanicId == mechanic.Id);

                    if(planning == true)
                    {
                        mechanic.DeleteButton = false;
                    }

                    else
                    {
                        mechanic.DeleteButton = true;
                    }

                    #endregion

                    mechanic.DealerName = dealer.DealerName;
                    mechanicList.Add(mechanic);
                }
            }
            return mechanicList;
        }

        public string UpdateMechanic(Mechanic model)
        {
            var entity = _dbContext.tblMechanics.Find(model.Id);
            if (entity != null)
            {

                #region Mapping Mechanic -> Database.tblMechanic

                entity.MechanicName = model.MechanicName;
                entity.EmployeeNo = model.EmployeeNo;
                entity.MobileNo = model.MobileNo;
                entity.EmailId = model.EmailId;
                entity.isActive = model.isActive;
                

                //entity.CreatedBy = model.CustomerName;
                //entity.CreatedDate = DateTime.Now;
                //entity.UpdatedBy = model.UpdatedBy;
                //entity.UpdatedDate = model.UpdatedDate;

                #endregion

                entity.UpdatedBy = model.MechanicName;
                entity.UpdatedDate = DateTime.Now;

                //_dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                _dbContext.SaveChanges();
                return "updated Successfully";
            }
            else
            {
                return "Something went wrong plz try after some time.";
            }
        }

        public List<Mechanic> MechanicDropdown(int id)
        {
            List<Mechanic> mechanicList = new List<Mechanic>();

            var mechanicData = _dbContext.tblMechanics.Where(m => m.DealerId == id).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblMechanic, Mechanic>());
            var mapper = config.CreateMapper();

            if (mechanicData != null)
            {
                foreach (var item in mechanicData)
                {
                    Mechanic mechanic = mapper.Map<Mechanic>(item);

                    mechanicList.Add(mechanic);
                }
            }
            return mechanicList;
        }
    }
}

