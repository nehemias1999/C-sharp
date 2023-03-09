using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataBaseManagement.Models
{
    class Customers
    {
        public String connectionString =
            " Data Source = localhost; " +
            " Initial Catalog = testingDataBase; " +
            " User = name_user; " +
            " Password = password ";

        /*
        public String connectionString =
            " Data Source = localhost; " +
            " Initial Catalog = testingDataBase; " +
            " Integrated Security = true ";
        */

        public List<Customer> getData()
        {
            var customers = new List<Customer>();

            String query = "SELECT customer_id, first_name, last_name, phone, address " +
                           "FROM tbl_customers; ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var costumer_id = reader.GetInt32(0);
                    var first_name = reader.GetString(1);
                    var last_name = reader.GetString(2);
                    var phone = reader.GetString(3);
                    var address = reader.GetString(4);

                    var newCustomer = new Customer(costumer_id, first_name, last_name, phone, address);
                    customers.Add(newCustomer);
                }

                reader.Close();

                connection.Close();
            }

            return customers;
        }

        public void addData(Customer newCustomer)
        {
            String query = "INSERT INTO tbl_customers (first_name, last_name, phone, address) " +
                           "VALUES (@first_name, @last_name, @phone, @address); ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@first_name", newCustomer.first_name);
                command.Parameters.AddWithValue("@last_name", newCustomer.last_name);
                command.Parameters.AddWithValue("@phone", newCustomer.phone);
                command.Parameters.AddWithValue("@address", newCustomer.address);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void updateData(Customer updateCustomer, int customer_id)
        {
            String query = "UPDATE tbl_customers " +
                           "SET first_name = @first_name, last_name = @last_name, phone = @phone, address = @address " +
                           "WHERE customer_id = @customer_id; ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@first_name", updateCustomer.first_name);
                command.Parameters.AddWithValue("@last_name", updateCustomer.last_name);
                command.Parameters.AddWithValue("@phone", updateCustomer.phone);
                command.Parameters.AddWithValue("@address", updateCustomer.address);

                command.Parameters.AddWithValue("@customer_id", customer_id);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void removeData(int customer_id)
        {
            String query = "DELETE " +
                           "FROM tbl_customers " +
                           "WHERE customer_id = @customer_id; ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@customer_id", customer_id);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
