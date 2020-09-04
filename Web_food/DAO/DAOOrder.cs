using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Web_food.Models;
namespace Web_food.DAO
{
    public class DAOOrder
    {
        //Thêm thông tin vào bảng order
        public void Add_order(Order order)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_Add = "INSERT INTO `order` (id, username, phone, email, address, date, total, sumsl) VALUES (@id, @username, @phone, @email, @address, @date, @total, @sum)";
            MySqlCommand command = new MySqlCommand(sql_Add, connection);

            command.Parameters.AddWithValue("@id", order.id);
            command.Parameters.AddWithValue("@username", order.username);
            command.Parameters.AddWithValue("@phone", order.phone);
            command.Parameters.AddWithValue("@email", order.email);
            command.Parameters.AddWithValue("@address", order.address);
            command.Parameters.AddWithValue("@date", order.date);
            command.Parameters.AddWithValue("@total", order.total);
            command.Parameters.AddWithValue("@sum", order.sum);
            
            command.ExecuteNonQuery();
        }
        //Thêm thông tin vào bảng Order_detail
        public void order_detail(Order_detail order)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_Add = "INSERT INTO `order_detail` ( image, name, quantity, price, id_order, product_id) VALUES (@image, @name, @quantity, @price, @id_order, @product_id)";
            MySqlCommand command = new MySqlCommand(sql_Add, connection);
            
            command.Parameters.AddWithValue("@image", order.image);
            command.Parameters.AddWithValue("@name", order.name);
            command.Parameters.AddWithValue("@quantity",order.quantity);
            command.Parameters.AddWithValue("@price", order.price);
            command.Parameters.AddWithValue("@id_order", order.id_order);
            command.Parameters.AddWithValue("@product_id", order.product_id);

            command.ExecuteNonQuery();
        }
        //Hiển thị thông tin hoá đơn vừa mua theo mã hoá đơn
        public static List<Order> show_hoadon(string order_id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT * FROM `order` where id = @id";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@id", order_id);
            List<Order> list_order = new List<Order>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string id = reader.GetString("id");
                    string username = reader.GetString("username");
                    string email = reader.GetString("email");
                    string phone = reader.GetString("phone");
                    string address = reader.GetString("address");
                    string status = reader.GetString("status");
                    DateTime date = Convert.ToDateTime(reader.GetString("date"));
                    string sum = reader.GetString("sumsl");
                    string total = reader.GetString("total");
                    
                    Order order = new Order(id,username,email,phone,address,status,date,sum,total);
                    list_order.Add(order);
                }
            }
            return list_order;
        }
        //hiển thị hoá đơn theo khách hàng
        public DataSet show_order_byuser(string user)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql = "SELECT d.id_order, d.image, d.`name`, d.quantity, d.price, o.date, d.product_id, o.status FROM `order` o JOIN order_detail d ON o.id = d.id_order WHERE o.username = @username";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", user);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //hiển thị thông tin hoá đơn theo order_id
        public static DataSet show_order_byID(string order_id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql = "SELECT d.id_order, d.image, d.`name`, d.quantity, d.price, o.date FROM `order` o JOIN order_detail d ON o.id = d.id_order WHERE d.id_order = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", order_id);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static List<Order> show_quanlyhoadon()
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql = "SELECT * FROM `order`";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            // sqlCommand.Parameters.AddWithValue("@id", order_id);
            List<Order> list_order = new List<Order>();
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string id = reader.GetString("id");
                    string username = reader.GetString("username");
                    string email = reader.GetString("email");
                    string phone = reader.GetString("phone");
                    string address = reader.GetString("address");
                    string status = reader.GetString("status");
                    DateTime date = Convert.ToDateTime(reader.GetString("date"));
                    string sum = reader.GetString("sumsl");
                    string total = reader.GetString("total");
                    
                    Order order = new Order(id,username,email,phone,address,status,date,sum,total);
                    list_order.Add(order);
                }
            }
            return list_order;
        }
        public static bool del_oder(string id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            string sql_del = "DELETE from `order` WHERE id=@id";
            MySqlCommand command = new MySqlCommand(sql_del,connection);
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery()>0;
        }
        public DataSet show_order_id(string maDH)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql = "SELECT id, date, status FROM `order` WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", maDH);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Update_order(Order order, string maDH)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_update = "UPDATE `order` SET `status` = @status, date = @date WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql_update, connection);

            command.Parameters.AddWithValue("@id", maDH);
            command.Parameters.AddWithValue("@status", order.status);
            command.Parameters.AddWithValue("@date", order.date);
            command.ExecuteNonQuery();
        }
    }
}