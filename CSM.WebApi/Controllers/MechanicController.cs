using CSM.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSM.WebApi.Controllers
{
    public class MechanicController : ApiController
    {
        private readonly IMechanicManager _mechanicManager;

        public MechanicController(IMechanicManager mechanicManager)
        {
            _mechanicManager = mechanicManager;
        }
    }
}
