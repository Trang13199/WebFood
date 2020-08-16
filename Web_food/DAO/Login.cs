<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Data.Common;
=======
﻿using System.Data.Common;
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
using MySql.Data.MySqlClient;
using Project.Models;
using Web_food.DAO;

namespace Web_food.DAO
{
    public class Login
    {
        public User doLogin(string email, string password, string users, string phone, string address)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
<<<<<<< HEAD
            string sql = "SELECT * FROM `user` WHERE email = @email AND password = @password";
=======
            string sql = "SELECT username FROM `user` WHERE email = @email AND password = @password";
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            ///Thì có một tham số tên @CateID. Tham số này được thêm vào/ thiết lập qua Parameters của SqlCommand. Ví dụ thêm bằng Parameters.AddWithValue
            sqlCommand.Parameters.AddWithValue("@email",email);
            sqlCommand.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = sqlCommand.ExecuteReader();
            User user = new User();
           
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.userName = reader[0].ToString();
<<<<<<< HEAD
                        user.email = reader[2].ToString();
                        user.phone = reader[3].ToString();
                        user.address = reader[4].ToString();
                        return user;
                    }
                }
                return null;
=======
                        return user;
                    }
                }
            
            return null;
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
        }
            
    }
}