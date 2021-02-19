using CSM.BAL.ManagerInterface;
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
    }
}
