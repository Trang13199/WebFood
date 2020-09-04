using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Web_food.DAO;
using Web_food.Models;

namespace Web_food.DAO
{
    public class ProductDetail
    {
        public static List< Product> showProduct(string ids)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT * FROM `products` WHERE `id`= @id ";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@id",ids);
            List<Product> list = new List<Product>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = Int32.Parse(reader.GetString("id"));
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");

                    Product  product = new Product(id, Price, Name, Img, content);
                    list.Add(product);
                }
            }

            return list ;
        }
          //Lấy ra danh sách sản phẩm cùng loại
        public static List< Product> sp_cungloai(int? type)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT id, type, image, `name`, content, price FROM `products` WHERE type = @type LIMIT 0,8";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@type",type);
            List<Product> list = new List<Product>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = Int32.Parse(reader.GetString("id"));
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");

                    Product  product = new Product(id, Price, Name, Img, content);
                    list.Add(product);
                }
            }
            return list ;
        }
        //Hiển thị thông tin sản phẩm mà user đã quan tâm
        public DataSet sp_yeuThich(string user)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql = "SELECT d.id_order, d.image, d.`name`, d.quantity, d.price, o.date, d.product_id, o.status FROM `order` o JOIN order_detail d ON o.id = d.id_order WHERE o.username = @username LIMIT 0,8";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", user);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}