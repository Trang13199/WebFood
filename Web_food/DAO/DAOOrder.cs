using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Web_food.Models;
namespace Web_food.DAO
{
    public class DAOOrder
    {
        public string Add_order(Order order)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_Add = "INSERT INTO `order` ( username, phone, email, address, date, total, sumsl) VALUES (@username, @phone, @email, @address, @date, @total, @sum)";
            MySqlCommand command = new MySqlCommand(sql_Add, connection);

            // command.Parameters.AddWithValue("@id", order.id);
            command.Parameters.AddWithValue("@username", order.username);
            command.Parameters.AddWithValue("@phone", order.phone);
            command.Parameters.AddWithValue("@email", order.email);
            command.Parameters.AddWithValue("@address", order.address);
            command.Parameters.AddWithValue("@date", order.date);
            command.Parameters.AddWithValue("@total", order.total);
            command.Parameters.AddWithValue("@sum", order.sum);
       
            command.ExecuteNonQuery();
            return order.id;
        }
        public void order_detail(Order_detail order)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_Add = "INSERT INTO `order_detail` ( image, name, quantity, price, id_order) VALUES (@image, @name, @quantity, @price, @id_order)";
            MySqlCommand command = new MySqlCommand(sql_Add, connection);
            
            command.Parameters.AddWithValue("@image", order.image);
            command.Parameters.AddWithValue("@name", order.name);
            command.Parameters.AddWithValue("@quantity",order.quantity);
            command.Parameters.AddWithValue("@price", order.price);
            command.Parameters.AddWithValue("@id_order", order.id_order);

            command.ExecuteNonQuery();
        }
    }
}