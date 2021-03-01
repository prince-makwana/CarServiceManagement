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
        private readonly Database.AutomotiveDBEntities _dbContext;
        //private readonly Database.ServiceBookingDBEntities _dbContext;

        public CustomerRepository()
        {
            _dbContext = new Database.AutomotiveDBEntities();
            //_dbContext = new Database.ServiceBookingDBEntities();
        }

        public string CreateCustomer(Customer model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, Database.tblCustomer>());
            var mapper = config.CreateMapper();
            if (model != null)
            {
                var customer = mapper.Map<Database.tblCustomer>(model);

                customer.CreatedBy = model.CustomerName;
                customer.CreatedDate = DateTime.Now;

                _dbContext.tblCustomers.Add(customer);
                _dbContext.SaveChanges();
                return "Created Succesfully";
            }

            return "Plz try after Some time or Contact admin";
        }

        public string DeleteCustomer(int id)
        {
            var entity = _dbContext.tblCustomers.Where(c => c.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                _dbContext.SaveChanges();
                return "deleted successfully";
            }
            return "something went wrong plz try after some time.";
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
                    Customer customer = mapper.Map<Customer>(item);
                    customerList.Add(customer);
                }
            }
            return customerList;
        }

        public string UpdateCustomer(Customer model)
        {
            var entity = _dbContext.tblCustomers.Find(model.Id);
            if (entity != null)
            {

                #region Mapping Customer -> Database.tblCustomer

                entity.CustomerName = model.CustomerName;
                entity.FName = model.FName;
                entity.LName = model.LName;
                entity.Address = model.Address;
                entity.ZipCode = model.ZipCode;
                entity.City = model.City;
                entity.Country = model.Country;
                //entity.CustomerNo = model.CustomerNo;
                //entity.CreatedBy = model.CustomerName;
                //entity.CreatedDate = DateTime.Now;
                //entity.UpdatedBy = model.UpdatedBy;
                //entity.UpdatedDate = model.UpdatedDate;

                #endregion

                entity.UpdatedBy = model.CustomerName;
                entity.UpdatedDate = DateTime.Now;

                //_dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                _dbContext.SaveChanges();
                return "updated Successfully";
            }
            else
            {
                return "Something went wrong plz try after some time.";
            }
        }
    }
}
