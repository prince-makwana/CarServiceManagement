using CSM.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryClass
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.AutoMotiveProjectEntities _automotiveEntities;

        public VehicleRepository()
        {
            _automotiveEntities = new Database.AutoMotiveProjectEntities();
        }
    }
}
