﻿using CSM.BAL.ManagerInterface;
using CSM.DAL.RepositoryInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerClass
{
    public class DealerManager : IDealerManager
    {
        private readonly IDealerRepository _dealerRepository;

        public DealerManager(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        public string CreateDealer(Dealer model)
        {
            return _dealerRepository.CreateDealer(model);
        }

        public List<DealerObj> DealersDropdown()
        {
            return _dealerRepository.DealersDropdown();
        }

        public string DeleteDealer(int id)
        {
            return _dealerRepository.DeleteDealer(id);
        }

        public List<Dealer> GetAllDealers()
        {
            return _dealerRepository.GetAllDealers();
        }

        public string UpdateDealer(Dealer model)
        {
            return _dealerRepository.UpdateDealer(model);
        }
    }
}
