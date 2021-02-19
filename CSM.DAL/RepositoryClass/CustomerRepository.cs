using AutoMapper;
using CSM.DAL.RepositoryInterface;
using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryClass
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.AutoMotiveProjectEntities _dbContext;

        public CustomerRepository()
        {
            _dbContext = new Database.AutoMotiveProjectEntities();
        }

        public List<Customer> GetAllCustomers()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblCustomer, Customer>());
            var mapper = config.CreateMapper();

            var customerEntities = _dbContext.tblCustomers.ToList();

            List<Customer> customerList = new List<Customer>();

            if (customerEntities != null)
            {
                foreach (var item in customerEntities)
                {
                    Customer appoinment = mapper.Map<Customer>(item);
                    customerList.Add(appoinment);
                }
            }
            return customerList;
        }
    }
}
