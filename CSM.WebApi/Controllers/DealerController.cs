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
    public class DealerController : ApiController
    {
        private readonly IDealerManager _dealerManager;

        public DealerController(IDealerManager dealerManager)
        {
            _dealerManager = dealerManager;
        }

        [HttpGet]
        [Route("api/Dealer/allDealers")]
        public IHttpActionResult GetAllDealers()
        {
            var dealers = _dealerManager.GetAllDealers();

            if (dealers.Count == 0)
            {
                return Json("Data not Found.");
            }
            return Json(dealers);
        }

        [HttpPost]
        [Route("api/Dealer/CreateDealers")]
        public string CreateDealers([FromBody] Dealer model)
        {
            return _dealerManager.CreateDealer(model);
        }

        [HttpPut]
        [Route("api/Customer/UpdateDealers")]
        public string UpdateDealers([FromBody] Dealer model)
        {
            return _dealerManager.UpdateDealer(model);
        }

        [HttpDelete]
        [Route("api/Dealer/DeleteDealers/{id}")]
        public string DeleteDealer(int id)
        {
            return _dealerManager.DeleteDealer(id);
        }
    }
}
