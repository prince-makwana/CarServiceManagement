using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSM.BAL.ManagerInterface;
using CSM.Models;

namespace CSM.WebApi.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpGet]
        [Route("api/Appointment/allAppointments")]
        public IHttpActionResult GetAllAppointments()
        {
            var appointments = _appointmentManager.GetAllAppoinment();
            if(appointments.Count == 0)
            {
                return NotFound();
            }
            return Json(appointments);
        }
        [HttpPost]
        [Route("api/Appoinment/CreateAppoinments")]
        public string CreateAppoinments([FromBody]Appointment model)
        {
            return _appointmentManager.CreateAppoinment(model);  
        }
        [HttpPut]
        [Route("api/Appoinment/UpdateAppoinments")]
        public string UpdateAppoinments([FromBody]Appointment model)
        {
            return _appointmentManager.UpdateAppoinment(model);
        }
        [HttpDelete]
        [Route("api/Appoinment/DeleteAppoinments/{id}")]
        public string DeleteAppoinments(int id)
        {
            return _appointmentManager.DeleteAppoinment(id);
        }
    }
}
