using CSM.BAL.ManagerInterface;
using CSM.BAL.ManagerClass;
using CSM.BAL.Helper;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CSM.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAppointmentManager, AppointmentManager>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IDealerManager, DealerManager>();
            container.RegisterType<IMechanicManager, MechanicManager>();
            container.RegisterType<IPlanningManager, PlanningManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();

            container.AddNewExtension<UnityRepositoryHelper>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}