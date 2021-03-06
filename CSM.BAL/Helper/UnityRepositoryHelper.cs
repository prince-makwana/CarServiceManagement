using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using CSM.DAL.RepositoryInterface;
using CSM.DAL.RepositoryClass;

namespace CSM.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAppointmentRepository, AppointmentRepository>();
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IDealerRepository, DealerRepository>();
            Container.RegisterType<IMechanicRepository, MechanicRepository>();
            Container.RegisterType<IPlanningRepository, PlanningRepository>();
            Container.RegisterType<IServiceRepository, ServiceRepository>();
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
            Container.RegisterType<IAppointmentServiceRepository, AppointmentServiceRepository>();
        }
    }
}
