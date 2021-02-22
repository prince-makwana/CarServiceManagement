using CSM.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryClass
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Database.AutoMotiveProjectEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public ServiceRepository()
        {
            _dbContext = new Database.AutoMotiveProjectEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }
    }
}
