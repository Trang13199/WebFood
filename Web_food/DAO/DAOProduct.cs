using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web_food.Models;

namespace Web_food.DAO
{
    public class DAOProduct
    {
        public static List<Product> getListProducts()
        {
            List<Product> listproducts = new List<Product>();
            string sql = "select * from products";

            DBConnection DbConnection = new DBConnection();
            MySqlConnection conn = DbConnection.ConnectionSql();
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string image = reader[1].ToString();
                    string name = reader[2].ToString();
                    string content = reader[3].ToString();
                    int quantity = reader.GetInt32(4);
                    double price = reader.GetDouble(5);
                    int status = reader.GetInt32(6);
                    int type = reader.GetInt32(7);
                    int active = reader.GetInt32(8);
                    Product product = new Product(id, image, name, content, quantity, price, price, status, type,
                        active);
                    listproducts.Add(product);
                }
            }

            return listproducts;
        }
    }
}