using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Order
{
    internal class OrderRepoDB
    {
        public readonly string connectionDb = "Server=LAPTOP-S4KN40Q4;Database=POS;Trusted_Connection=True";

        public bool Create(OrderModel order)
        {
            using (SqlConnection conn = new SqlConnection(connectionDb))
            {
                string query = "INSERT INTO Orders (CustomerName, Contact, Address, Bill, Items)" +
                                "VALUES (@name, @contact, @address, @bill, @items)";
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", order.customerName);
                cmd.Parameters.AddWithValue("@contact", order.phoneNumber);
                cmd.Parameters.AddWithValue("@address", order.adress);
                cmd.Parameters.AddWithValue("@bill", order.TotalBill());
                cmd.Parameters.AddWithValue("@items", order.ListToString());

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public List<OrderModel> GetOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();
            using (SqlConnection conn = new SqlConnection(connectionDb))
            {
                string query = "SELECT * FROM Orders";
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = Convert.ToString(reader["CustomerName"]);
                    string contact = Convert.ToString(reader["Contact"]);
                    string address = Convert.ToString(reader["Address"]);
                    float bill = Convert.ToSingle(reader["Bill"]);
                    string items = Convert.ToString(reader["items"]);

                    OrderModel order = new OrderModel(id, name, contact, address);
                    order.StringToList(items);
                    orders.Add(order);
                }
                reader.Close();
            }

            return orders;
        }
    }
}
