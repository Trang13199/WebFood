using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Web_food.DAO;
using Web_food.Models;

namespace Web_food.DAO
{
    public class Login
    {
        public User doLogin(string username, string password, string email)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string sql =
                "SELECT id,username,`password`,email,phone,address,gender,`level` FROM `user` WHERE email = @email AND password = @password";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            ///Thì có một tham số tên @CateID. Tham số này được thêm vào/ thiết lập qua Parameters của SqlCommand. Ví dụ thêm bằng Parameters.AddWithValue
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = sqlCommand.ExecuteReader();
            User user = new User();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.id = reader.GetInt32("ID");
                    user.userName = reader["username"].ToString();
                    user.password = reader.GetString("password");
                    user.email = reader["email"].ToString();
                    user.phone = reader["phone"].ToString();
                    user.address = reader["address"].ToString();
                    user.gender = reader.GetString("gender");
                    user.level = reader.GetInt32("level");
                    return user;
                }
            }

            return null;
        }
    }
}