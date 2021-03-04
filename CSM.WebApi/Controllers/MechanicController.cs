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
    public class MechanicController : ApiController
    {
        private readonly IMechanicManager _mechanicManager;

        public MechanicController(IMechanicManager mechanicManager)
        {
            _mechanicManager = mechanicManager;
        }

        [HttpGet]
        [Route("api/Mechanic/allMechanics")]
        public IHttpActionResult GetAllMechanics()
        {
            var mechanics = _mechanicManager.GetAllMechanics();

            if (mechanics.Count == 0)
            {
                return Json("Data not Found.");
            }
            return Json(mechanics);
        }

        [HttpPost]
        [Route("api/Mechanic/CreateMechanics")]
        public string CreateMechanics([FromBody] Mechanic model)
        {
            return _mechanicManager.CreateMechanic(model);
        }

        [HttpPut]
        [Route("api/Mechanic/UpdateMechanics")]
        public string UpdateMechanics([FromBody] Mechanic model)
        {
            return _mechanicManager.UpdateMechanic(model);
        }

        [HttpDelete]
        [Route("api/Mechanic/DeleteMechanics/{id}")]
        public string DeleteMechanic(int id)
        {
            return _mechanicManager.DeleteMechanic(id);
        }
    }
}
