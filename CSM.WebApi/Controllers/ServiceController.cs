using CSM.BAL.ManagerInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSM.WebApi.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IServiceManager _serviceManager;

        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("api/Service/allServices")]
        public IHttpActionResult GetAllServices()
        {
            var services = _serviceManager.GetAllServices();

            if (services.Count == 0)
            {
                return Json("Data not Found.");
            }
            return Json(services);
        }

        [HttpPost]
        [Route("api/Service/CreateServices")]
        public string CreateServices([FromBody] Service model)
        {
            return _serviceManager.CreateService(model);
        }

        [HttpPut]
        [Route("api/Service/UpdateServices")]
        public string UpdateServices([FromBody] Service model)
        {
            return _serviceManager.UpdateService(model);
        }

        [HttpDelete]
        [Route("api/Service/DeleteServices/{id}")]
        public string DeleteService(int id)
        {
            return _serviceManager.DeleteService(id);
        }

        [HttpGet]
        [Route("api/Service/ServiceDropdown")]
        public IHttpActionResult ServicesDropdown(int id)
        {
            var serviceDropdown = _serviceManager.ServicesDropdown(id);

            if (serviceDropdown.Count == 0)
            {
                return Json("Error in fetching the list. Try after sometime.");
            }
            else
            {
                return Json(serviceDropdown);
            }
        }
    }
}
