using CSM.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSM.WebApi.Controllers
{
    public class DealerController : ApiController
    {
        private readonly IDealerManager _dealerManager;

        public DealerController(IDealerManager dealerManager)
        {
            _dealerManager = dealerManager;
        }
    }
}
