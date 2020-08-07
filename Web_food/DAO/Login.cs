using System.Data.Common;
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
            string sql = "SELECT username FROM `user` WHERE email = @email AND password = @password";
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
                        return user;
                    }
                }
            
            return null;
        }
            
    }
}