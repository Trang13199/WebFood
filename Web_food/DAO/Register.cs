using MySql.Data.MySqlClient;
using Web_food.DAO;

namespace Web_food.DAO
{
    public class Register
    {
        public void doRegister(string username, string password, string email, string phone, string address)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            
            string sql = "INSERT INTO user (username, `password`, email, phone, address) VALUES(@username,@password,@email,@phone, @address)";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;


            sqlCommand.Parameters.AddWithValue("@username", username);
            sqlCommand.Parameters.AddWithValue("@password", password);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@phone", phone);
            sqlCommand.Parameters.AddWithValue("@address", address);

            sqlCommand.ExecuteNonQuery();
        }
    }
}