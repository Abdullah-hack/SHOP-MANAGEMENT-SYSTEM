using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Customer
{
    internal class CustomerService
    {
        private CustomerRepoDb dbRepo;

        public CustomerService()
        {
            dbRepo = new CustomerRepoDb();
        }

        public bool SaveCustomer(CustomerModel customer)
        {
            return dbRepo.Create(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return dbRepo.Delete(id);
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            return dbRepo.Update(customer);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return dbRepo.GetAll();
        }
    }
}
