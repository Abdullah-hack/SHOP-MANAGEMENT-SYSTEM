using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Product
{
    internal class ProductRepoDb
    {
        private readonly string connectionDb = "Server=LAPTOP-S4KN40Q4;Database=POS;Trusted_Connection=True";

        public bool Create(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(connectionDb))
            {
                string query = "INSERT INTO Product (Name, PurchasePrice, SalePrice, Discount)" +
                                "VALUES (@name, @purchasePrice, @salePrice, @discount)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@purchasePrice", product.purchasePrice);
                cmd.Parameters.AddWithValue("@salePrice", product.salePrice);
                cmd.Parameters.AddWithValue("@discount", product.discount);

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

        public bool Delete(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionDb))
            {
                string query = "DELETE FROM Product WHERE Name = @Name";
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
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


        public bool Update(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(connectionDb))
            {
                string query = "UPDATE Product SET Name=@name, PurchasePrice=@purchase, " +
                                "SalePrice=@sale, Discount=@discount WHERE Name=@name";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@purchase", product.purchasePrice);
                cmd.Parameters.AddWithValue("@sale", product.salePrice);
                cmd.Parameters.AddWithValue("@discount", product.discount);

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


        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection(connectionDb))
            {
                string query = "SELECT * FROM Product";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = Convert.ToString(reader["Name"]);
                    float purchasePrice = Convert.ToSingle(reader["PurchasePrice"]);
                    float salePrice = Convert.ToSingle(reader["SalePrice"]);
                    float discount = Convert.ToSingle(reader["Discount"]);

                    ProductModel product = new ProductModel(id, name, purchasePrice, salePrice, discount);
                    products.Add(product);

                }
                reader.Close();
            }
            return products;
        }
    }
}
