using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCustomerAPP
{
    public class CustomerService
    {
        private readonly CustomerDataAccess _dataAccess;

        public CustomerService(string connectionString)
        {
            _dataAccess = new CustomerDataAccess(connectionString);
        }

        public List<Customer> GetAllCustomers()
        {
            return _dataAccess.GetCustomers();
        }
    }
}
