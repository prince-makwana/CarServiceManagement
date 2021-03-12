using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
            if (appointments.Count == 0)
            {
                return Json("Data not available");
            }
            return Json(appointments);
        }
        [HttpPost]
        [Route("api/Appoinment/CreateAppoinments")]
        public string CreateAppoinments([FromBody] Appointment model)
        {
            return _appointmentManager.CreateAppoinment(model);
        }
        [HttpPut]
        [Route("api/Appoinment/UpdateAppoinments")]
        public string UpdateAppoinments([FromBody] Appointment model)
        {
            bool res = _appointmentManager.UpdateAppoinment(model);

            if(res)
            {
                return "Updated Successfully.";
            }
            else
            {
                return "Something wen wrong. Please try after Sometime.";
            }
        }
        [HttpDelete]
        [Route("api/Appoinment/DeleteAppoinments/{id}")]
        public string DeleteAppoinments(int id)
        {
            return _appointmentManager.DeleteAppoinment(id);
        }

        [HttpGet]
        [Route("api/Appointment/AppointmentTracker/{id}")]
        public IHttpActionResult GetAppointmentTracker(int id)
        {
            AppointmentTracker apptracker = _appointmentManager.GetAppointmentTracker(id);
            if (apptracker != null)
            {
                return Json(apptracker);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Data Not Found.");
            }
        }

        [HttpPut]
        [Route("api/Appointment/UpdateStatus")]
        public IHttpActionResult UpdateStatus([FromBody] UpdateStatus model)
        {
            var status = _appointmentManager.UpdateStatus(model);

            if (status == true)
            {
                SendUpdateStatusEmail("radadiya77lalit77@gmail.com", model.Status, model.Id);
                return Ok("Updated Successfully.");
            }
            return Content(HttpStatusCode.NotFound, "Update Status Failed.");
        }

        [NonAction]
        public void SendUpdateStatusEmail(string EmailId, string Body, int id)
        {
            var fromEmail = new MailAddress("prince.temp.29@gmail.com", "Prince Makwana");
            var toEmail = new MailAddress(EmailId);
            var fromEmailPassword = "Gateway@123";

            var trackingUrl = "http://localhost:4100/tracking/" + id;

            string subject = "Car Service Appointment Tracking Link";

            string body = "<p>" +
                "Dear Customer," +
                "<br><br>The Status of your Car Service is Pending. You can check the status update on this email: " +
                "<a href=" + trackingUrl + ">" + trackingUrl + "</a>" +
                "<br><br>Thanks & Regards," +
                "<br> Mechanic." +
                "</p>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);
        }
    }
}
