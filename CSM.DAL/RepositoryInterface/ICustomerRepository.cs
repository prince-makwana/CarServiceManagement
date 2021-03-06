﻿using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryInterface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        string CreateCustomer(Customer model);
        string UpdateCustomer(Customer model);
        string DeleteCustomer(int id);
    }
}
