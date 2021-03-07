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
    public class DealerRepository : IDealerRepository
    {
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public DealerRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateDealer(Dealer model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Dealer, Database.tblDealer>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var dealer = mapper.Map<Database.tblDealer>(model);

                dealer.CreatedBy = model.DealerName;
                dealer.CreatedDate = DateTime.Now;

                _dbContext.tblDealers.Add(dealer);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }

        public List<DealerObj> DealersDropdown()
        {
            List<DealerObj> dealerList = new List<DealerObj>();

            var dealersData = _dbContext.tblDealers.Select(d => new { d.Id, d.DealerName, d.DealerNo, d.PhoneNo}).ToList();

            if(dealersData != null)
            {
                foreach (var item in dealersData)
                {
                    DealerObj dealerObj = new DealerObj();
                    
                    dealerObj.Id = item.Id;
                    dealerObj.DealerName = item.DealerName;
                    dealerObj.DealerNo = item.DealerNo;
                    dealerObj.PhoneNo = item.PhoneNo;

                    dealerList.Add(dealerObj);
                }
            }

            return dealerList;
        }

        public string DeleteDealer(int id)
        {
            var entity = _dbContext.tblDealers.Where(d => d.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
        }

        public List<Dealer> GetAllDealers()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblDealer, Dealer>());
            var mapper = config.CreateMapper();

            var dealerEntities = _dbContext.tblDealers.ToList();

            List<Dealer> dealerList = new List<Dealer>();

            if (dealerEntities != null)
            {
                foreach (var item in dealerEntities)
                {
                    Dealer dealer = mapper.Map<Dealer>(item);
                    dealerList.Add(dealer);
                }
            }
            return dealerList;
        }

        public string UpdateDealer(Dealer model)
        {
            var entity = _dbContext.tblDealers.Find(model.Id);
            if (entity != null)
            {

                #region Mapping Dealer -> Database.tblDealer

                entity.DealerName = model.DealerName;
                entity.DealerNo = model.DealerNo;
                entity.isActive = model.isActive;
                entity.isOnline = model.isOnline;
                entity.Website = model.Website;
                entity.PhoneNo = model.PhoneNo;
                entity.Address = model.Address;
                entity.Latitude = model.Latitude;
                entity.Longitude = model.Longitude;

                //entity.CreatedBy = model.CustomerName;
                //entity.CreatedDate = DateTime.Now;
                //entity.UpdatedBy = model.UpdatedBy;
                //entity.UpdatedDate = model.UpdatedDate;

                #endregion

                entity.UpdatedBy = model.DealerName;
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
    }
}
