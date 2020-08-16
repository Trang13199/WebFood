using MySql.Data.MySqlClient;
using Web_food.DAO;

namespace Web_food.DAO
{
    public class Register
    {
<<<<<<< HEAD
        public void doRegister(string username, string password, string email, string phone, string address)
=======
        public void doRegister(string username, string password, string email, string phone)
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            
<<<<<<< HEAD
            string sql = "INSERT INTO user (username, `password`, email, phone, address) VALUES(@username,@password,@email,@phone, @address)";
=======
            string sql = "INSERT INTO user (username, `password`, email, phone) VALUES(@username,@password,@email,@phone)";
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;


            sqlCommand.Parameters.AddWithValue("@username", username);
            sqlCommand.Parameters.AddWithValue("@password", password);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@phone", phone);
<<<<<<< HEAD
            sqlCommand.Parameters.AddWithValue("@address", address);
=======
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202

            sqlCommand.ExecuteNonQuery();
        }
    }
}