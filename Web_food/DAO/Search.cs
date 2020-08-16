﻿
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Project.Models;
using Web_food.DAO;
using Web_food.Models;

namespace Web_food.DAO
{
    public class Search
    {
        public static List<Product> seacrh(string search)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT  image, `name`, price, id, content FROM `products` WHERE `name` like '%" + search + "%'";
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
    }
}