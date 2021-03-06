﻿﻿using System;
 using System.Collections.Generic;
 using System.Data;
 using System.Data.SqlClient;
 using MySql.Data.MySqlClient;
 using Web_food.Models;

namespace Web_food.DAO
{
    public class DAOProduct
    {
        public static List<Product> getPage(int? page)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sqlsp = "  SELECT id, image, `name`, price, content, quantity, type FROM `products` WHERE active=1 ORDER BY id ";
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
                    int quantity = Convert.ToInt32(reader.GetString("quantity"));
                    int type = reader.GetInt32("type");

                    Product sp = new Product(id, Price, Name, Img, content, quantity, type);
                    products.Add(sp);
                }
            }
            return products;
        }

        // Hien thi danh sach san pham
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
                    int id = reader.GetInt32("id");
                    string image = reader["image"].ToString();
                    string name = reader["name"].ToString();
                    string content = reader["content"].ToString();
                    int quantity = reader.GetInt32("quantity");
                    double price = reader.GetDouble("price");
                    int type = reader.GetInt32("type");
                    Product product = new Product(id, image, name, content, quantity, price, price, type);
                    listproducts.Add(product);
                }
            }

            return listproducts;
        }
        // Them moi mot san pham
        public bool Add_product(Product product)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_Add = "INSERT INTO `products` (image, `name`, price, content, type, quantity) VALUES (@image, @name, @price, @content, @type, @quantity)";
            MySqlCommand command = new MySqlCommand(sql_Add, connection);
            
            command.Parameters.AddWithValue("@image", product.Images);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@content", product.Content);
            command.Parameters.AddWithValue("@type", product.Type);
            command.Parameters.AddWithValue("@quantity", product.Quantity);

           return command.ExecuteNonQuery() > 0;
        }
        // Cap nhat lai thong tin san pham
        public bool Update_product(Product product, int id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_update = "UPDATE products SET image = @image, name = @name, price = @price, content = @content, type = @type, quantity = @quantity WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql_update, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@image", product.Images);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@content", product.Content);
            command.Parameters.AddWithValue("@type", product.Type);
            command.Parameters.AddWithValue("@quantity", product.Quantity);

            return command.ExecuteNonQuery() > 0;
        }
        // Hien thi san pham theo id
        public DataSet show_record_byid(int id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_showid = "SELECT * FROM products WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql_showid, connection);

            command.Parameters.AddWithValue("@id", id);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        // Xoa san pham theo id
        public bool delete(int id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_delete = "DELETE FROM products WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql_delete, connection);

            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery() > 0;
        }
        //hien thi tat ca san pham
        public DataSet show()
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_show = "SELECT * FROM products ";
            MySqlCommand command = new MySqlCommand(sql_show, connection);
            
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        
        
        
        
        ///////////////////// product type ////////////////////////////////////

        public static List<ProductType> getListProductType()
        {
            List<ProductType> list = new List<ProductType>();
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            string sql = "select id,name,active from product_type";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string nametype = reader.GetString("name");
                    int active = reader.GetInt32("active");
                    ProductType pro = new ProductType(id, nametype, active);
                    list.Add(pro);
                }
            }
            return list;
        }

        public static ProductType getProductType(int id)
        {
            ProductType productType=new ProductType();
            string sql = "select id,name,active from product_type where id=@id";
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql,connection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    productType.Id = reader.GetInt32("id");
                    productType.Name = reader.GetString("name");
                    productType.Active = reader.GetInt32("active");
                }
            }
            return productType;
        }
        public static bool addProductType(ProductType productType)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            string sql = "insert into product_type(name) values (@name)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", productType.Name);
            return command.ExecuteNonQuery() > 0;
        }

        public static bool editProductType(ProductType productType)
        {
            DBConnection dbConnection= new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            string sqlUpdate = "update product_type set name=@name,active=@active where id=@id";
            MySqlCommand command  = new MySqlCommand(sqlUpdate,connection);
            command.Parameters.AddWithValue("@id", productType.Id);
            command.Parameters.AddWithValue("@name", productType.Name);
            command.Parameters.AddWithValue("@active", productType.Active);
            return command.ExecuteNonQuery()>0;
        }

        public static bool delProductType(int id)
        {
            string sqlDel = "delete from product_type where id=@id";
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            MySqlCommand command = new MySqlCommand(sqlDel, connection);
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery() > 0;
        }
        
        public static List<Product> Product_type(int? type)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sqlsp = "  SELECT id, image, `name`, price, content, quantity, type FROM `products` WHERE type = @type ";
            MySqlCommand  sqlCommand = new MySqlCommand(sqlsp);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@type",type);
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
                    int quantity = Convert.ToInt32(reader.GetString("quantity"));
                    int types = reader.GetInt32("type");

                    Product sp = new Product(id, Price, Name, Img, content, quantity, types);
                    products.Add(sp);
                }
            }
            return products;
        }
    }
}