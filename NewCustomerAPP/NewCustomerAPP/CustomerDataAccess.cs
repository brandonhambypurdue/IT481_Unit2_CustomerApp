using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NewCustomerAPP
{
    public class CustomerDataAccess
    {
        private readonly string _connectionString;

        public CustomerDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerID = reader["CustomerID"]?.ToString() ?? "",
                            CompanyName = reader["CompanyName"]?.ToString() ?? "",
                            ContactName = reader["ContactName"]?.ToString() ?? "",
                            ContactTitle = reader["ContactTitle"]?.ToString() ?? "",
                            Address = reader["Address"]?.ToString() ?? "",
                            City = reader["City"]?.ToString() ?? "",
                            Region = reader["Region"]?.ToString() ?? "",
                            PostalCode = reader["PostalCode"]?.ToString() ?? "",
                            Country = reader["Country"]?.ToString() ?? "",
                            Phone = reader["Phone"]?.ToString() ?? "",
                            Fax = reader["Fax"]?.ToString() ?? ""
                        });
                    }
                }
            }

            return customers;
        }
    }
}

