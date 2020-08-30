﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
 using Web_food.DAO;
using Web_food.Models;

namespace Web_food.DAO
{
    public class ProductDetail
    {
        public static List< Product> showProduct(string name)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT * FROM `products` WHERE `name`= @name ";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("name",name);
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
    }
}