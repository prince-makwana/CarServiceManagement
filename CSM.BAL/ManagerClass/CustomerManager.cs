using CSM.BAL.ManagerInterface;
using CSM.DAL.RepositoryInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerClass
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string CreateCustomer(Customer model)
        {
            return _customerRepository.CreateCustomer(model);
        }

        public string DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public string UpdateCustomer(Customer model)
        {
            return _customerRepository.UpdateCustomer(model);
        }
    }
}
