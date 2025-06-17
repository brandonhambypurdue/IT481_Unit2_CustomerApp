using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NewCustomerAPP
{
    public partial class Form1 : Form
    {
        private readonly CustomerService _customerService;
       
        public Form1()
        {
            InitializeComponent();

            string connectionString = @"Server=.\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";
            _customerService = new CustomerService(connectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                    List<Customer> customers = _customerService.GetAllCustomers();
                    dataGridView1.DataSource = customers;
                    lblCustomerCount.Text = $"Retrieved {customers.Count} customers.";
                    lblCustomerCount.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblCustomerCount.Text = "Error: " + ex.Message;
                    lblCustomerCount.ForeColor = System.Drawing.Color.Red;
                }
        }
    }
}
