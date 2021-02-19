using CSM.BAL.ManagerInterface;
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
                return NotFound();
            }
            return Json(customers);
        }
    }
}
