using MySql.Data.MySqlClient;
using Web_food.DAO;

namespace Web_food.DAO
{
    public class Register
    {
        public void doRegister(string username, string password, string email, string phone, string address,string gender)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            
            string sql = "INSERT INTO user (username, `password`, email, phone, address,gender,level) VALUES(@username,@password,@email,@phone, @address,@gender)";
            MySqlCommand sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            // level = 1;

            sqlCommand.Parameters.AddWithValue("@username", username);
            sqlCommand.Parameters.AddWithValue("@password", password);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@phone", phone);
            sqlCommand.Parameters.AddWithValue("@address", address);
            sqlCommand.Parameters.AddWithValue("@gender", gender);

            sqlCommand.ExecuteNonQuery();
        }
        public bool checkUserExist(string username,string email)
        {
            DBConnection DbConnection = new DBConnection();
            MySqlConnection conn = DbConnection.ConnectionSql();
            conn.Open();

            string sqlselect = "select email, username from user";
            MySqlCommand sqlCommandselect = conn.CreateCommand();
            sqlCommandselect.CommandText = sqlselect;
            MySqlDataReader reader = sqlCommandselect.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (email == reader[0].ToString() && username==reader[1].ToString())
                    {
                        return  true;
                    }
                }
            }
            return false;
        }
    }
}