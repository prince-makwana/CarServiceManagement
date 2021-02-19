﻿using CSM.BAL.ManagerInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSM.WebApi.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleManager _vehicleManager;

        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpGet]
        [Route("api/Vehicle/allVehicles")]
        public IHttpActionResult GetAllVehicles()
        {
            var vehicles = _vehicleManager.GetAllVehicles();

            if (vehicles.Count == 0)
            {
                return Json("Data not Found.");
            }
            return Json(vehicles);
        }

        [HttpPost]
        [Route("api/Vehicle/CreateVehicles")]
        public string CreateVehicles([FromBody] Vehicle model)
        {
            return _vehicleManager.CreateVehicle(model);
        }

        [HttpPut]
        [Route("api/Vehicle/UpdateVehicles")]
        public string UpdateVehicles([FromBody] Vehicle model)
        {
            return _vehicleManager.UpdateVehicle(model);
        }

        [HttpDelete]
        [Route("api/Vehicle/DeleteVehicles/{id}")]
        public string DeleteVehicles(int id)
        {
            return _vehicleManager.DeleteVehicle(id);
        }
    }
}
