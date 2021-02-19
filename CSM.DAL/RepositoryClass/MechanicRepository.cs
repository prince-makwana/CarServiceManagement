using CSM.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryClass
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Database.ServiceBookingDBEntities _automotiveEntities;

        public MechanicRepository()
        {
            _automotiveEntities = new Database.ServiceBookingDBEntities();
        }
    }
}
