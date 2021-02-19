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
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        [Route("api/Customer/allCustomers")]
        public IHttpActionResult GetAllCustomers()
        {
            var customers = _customerManager.GetAllCustomers();

            if(customers.Count == 0)
            {
                return Json("Data not Found.");
            }
            return Json(customers);
        }

        [HttpPost]
        [Route("api/Customer/CreateCustomers")]
        public string CreateCustomers([FromBody] Customer model)
        {
            return _customerManager.CreateCustomer(model);
        }

        [HttpPut]
        [Route("api/Customer/UpdateCustomers")]
        public string UpdateCustomers([FromBody] Customer model)
        {
            return _customerManager.UpdateCustomer(model);
        }

        [HttpDelete]
        [Route("api/Customer/DeleteCustomers/{id}")]
        public string DeleteCustomer(int id)
        {
            return _customerManager.DeleteCustomer(id);
        }
    }
}
