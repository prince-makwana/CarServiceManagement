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
    public class AppointmentServiceController : ApiController
    {
        private readonly IAppointmentServiceManager _appointmentServiceManager;

        public AppointmentServiceController(IAppointmentServiceManager appointmentServiceManager)
        {
            _appointmentServiceManager = appointmentServiceManager;
        }

        [HttpGet]
        [Route("api/Value/abc")]
        public string Value()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("api/AppointmentService/allAppointmentServices")]
        public IHttpActionResult GetAllAppointments()
        {
            var appointments = _appointmentServiceManager.GetAllAppointmentServices();
            if (appointments.Count == 0)
            {
                return Json("Data not available");
            }
            return Json(appointments);
        }

        [HttpPost]
        [Route("api/AppoinmentService/CreateAppoinmentServices")]
        public string CreateAppoinments([FromBody] AppointmentService model)
        {
            return _appointmentServiceManager.CreateAppointmentService(model);
        }

        [HttpPut]
        [Route("api/AppointmentService/UpdateAppointmentService")]
        public IHttpActionResult UpdateAppointmentService([FromBody] AppointmentService model)
        {
            var appointmentService = _appointmentServiceManager.UpdateAppoinmentService(model);

            if(appointmentService == true)
            {
                return Ok("Updated Successfully");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Something Went Wrong. Please try after sometime.");
            }
        }

        [HttpDelete]
        [Route("api/AppointmentService/DeleteAppointmentServices/{id}")]
        public string DeleteAppoinments(int id)
        {
            return _appointmentServiceManager.DeleteAppointmentService(id);
        }

        [HttpGet]
        [Route("api/AppointmentService/GetAppServicesByAppId/{id}")]
        public List<AppointmentService> GetAppServicesByAppId(int id)
        {
            return _appointmentServiceManager.getAppointmentServiceByAppointmentId(id);
        }
    }
}
