using CSM.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryClass
{
    public class PlanningRepository : IPlanningRepository
    {
        private readonly Database.AutoMotiveProjectEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public PlanningRepository()
        {
            _dbContext = new Database.AutoMotiveProjectEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }
    }
}
