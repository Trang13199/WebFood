using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using Web_food.DAO;
using Web_food.Models;

namespace Web_food.DAO
{
    public class ListProduct
    {
        public static List<Product> showProduct()
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT id, `name`, price, image, content FROM `products` WHERE active=1";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            List<Product> products = new List<Product>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");

                    Product sp = new Product(id, Price, Name, Img, content);
                    products.Add(sp);
                }
            }
            return products;
        }
        public static List<Product> Product(int? type)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string   sql = "SELECT id, `name`, price, image, content FROM `products` WHERE active=1 AND type = @type";
              MySqlCommand  sqlCommand = new MySqlCommand(sql);
                sqlCommand.Connection = conn;
                sqlCommand.Parameters.AddWithValue("@type", type);
                List<Product> products = new List<Product>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");

                    Product sp = new Product(id, Price, Name, Img, content);
                    products.Add(sp);
                }
            }
            return products;
        }
        public static List<ProductType> getType()
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();

            string sql = "SELECT id, `name` FROM `product_type` WHERE active=1";

            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            List<ProductType> types = new List<ProductType>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if(reader.HasRows){
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string Name = reader.GetString("name");
                    ProductType productType = new ProductType(id, Name);
                    types.Add(productType);
                }
            }
            return types;
        }

        public static List<Product> getPage(int? page)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sqlsp = "  SELECT id, image, `name`, price, content FROM `products` WHERE active=1 ORDER BY id ";
            MySqlCommand  sqlCommand = new MySqlCommand(sqlsp);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@page",page);
            List<Product> products = new List<Product>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");

                    Product sp = new Product(id, Price, Name, Img, content);
                    products.Add(sp);
                }
            }
            return products;
        }
        
        
        
        public static List<Product> Category(int? type, int pageindex = 1, int pagesize = 2)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string   sql = "SELECT id, `name`, price, image, content FROM `products` WHERE active=1 AND type = @type";
            MySqlCommand  sqlCommand = new MySqlCommand(sql.Skip((pageindex-1) * pagesize).Take(pagesize).ToString());
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@type", type);
            List<Product> products = new List<Product>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");

                    Product sp = new Product(id, Price, Name, Img, content);
                    products.Add(sp);
                }
            }
            return products;
        }
    }
}
