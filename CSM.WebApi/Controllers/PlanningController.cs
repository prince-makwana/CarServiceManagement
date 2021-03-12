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
    public class PlanningController : ApiController
    {
        private readonly IPlanningManager _planningManager;

        public PlanningController(IPlanningManager planningManager)
        {
            _planningManager = planningManager;
        }

        [HttpPost]
        [Route("api/Planning/CreatePlanning")]
        public IHttpActionResult CreatePlanning([FromBody] Planning model)
        {
            var planning = _planningManager.CreatePlanning(model);

            if (planning)
            {
                return Json("Appointment Planned successfully.");
            }
            else
            {
                return Json("Mechanic is not Available.");
            }
        }

        [HttpGet]
        [Route("api/Planning/allPlannings")]
        public IHttpActionResult GetAllPlannings()
        {
            var plannings = _planningManager.GetAllPlanning();
            if (plannings.Count == 0)
            {
                return Json("Data not available");
            }
            return Json(plannings);
        }

        [HttpPut]
        [Route("api/Planning/UpdatePlanning")]
        public IHttpActionResult UpdatePlanning([FromBody] Planning model)
        {
            var planning = _planningManager.UpdatePlanning(model);
            if(planning == true)
            {
                return Ok("Updated Successfully");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong. Please try after sometime.");
            }
        }
        [HttpDelete]
        [Route("api/Planning/DeletePlannings/{id}")]
        public string DeletePlannings(int id)
        {
            return _planningManager.DeletePlanning(id);
        }

        [HttpGet]
        [Route("api/Planning/GetPlanningByAppId/{id}")]
        public List<Planning> GetPlanningByAppId(int id)
        {
            return _planningManager.getPlanningByAppointmentId(id);
        }
    }
}
