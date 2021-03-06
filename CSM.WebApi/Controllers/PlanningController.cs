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
        public string CreatePlanning([FromBody] Planning model)
        {
            return _planningManager.CreatePlanning(model);
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
    }
}
