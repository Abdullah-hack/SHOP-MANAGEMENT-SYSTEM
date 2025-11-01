using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Customer
{
    public class CustomerRepoDb
    {
        public readonly string connectionDb = "Server=LAPTOP-S4KN40Q4;Database=POS;Trusted_Connection=True";

        public bool Create(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionDb))
            {
                string query = "INSERT INTO Customers(Name, Age, Contact, Adress)" +
                                "VALUES (@name, @age, @contact, @adress)";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@age", customer.age);
                cmd.Parameters.AddWithValue("@contact", customer.contact);
                cmd.Parameters.AddWithValue("@adress", customer.adress);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public bool Update(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionDb))
            {
                string query = "UPDATE Customers SET Name = @Name, Age = @Age, Contact = @Contact, " +
                                "Adress = @Adress WHERE Id = @Id";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", customer.id);
                cmd.Parameters.AddWithValue("@Name", customer.name);
                cmd.Parameters.AddWithValue("@Age", customer.age);
                cmd.Parameters.AddWithValue("@Contact", customer.contact);
                cmd.Parameters.AddWithValue("@Adress", customer.adress);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionDb))
            {
                string query = "DELETE FROM Customers WHERE Id = @Id";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection connection = new SqlConnection(connectionDb))
            {
                string query = "SELECT * FROM Customers";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = Convert.ToString(reader["Name"]);
                    int age = Convert.ToInt32(reader["Age"]);
                    string contact = Convert.ToString(reader["Contact"]);
                    string adress = Convert.ToString(reader["Adress"]);

                    CustomerModel customer = new CustomerModel(id, name, age, contact, adress);
                    customers.Add(customer);
                }
                reader.Close();
            }
            return customers;
        }




    }

}

