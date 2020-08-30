using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web_food.DAO;

namespace Web_food.Models
{
    public class DAOUser
    {
       public static User getuser(int id)
        {
            User user = new User();
            DBConnection dbConnection=new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            string sql = "select username,password,email,phone,address,gender,level from user where id=@id";
            MySqlCommand command=new MySqlCommand(sql,connection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.id = id;
                    user.email = reader.GetString("email");
                    user.password = reader.GetString("password");
                    user.userName = reader.GetString("username");
                    user.phone = reader.GetString("phone");
                    user.address = reader.GetString("address");
                    user.gender = reader.GetString("gender");
                    user.level = reader.GetInt32("level");
                }
            }
            return user;
        }

        public static List<User> getlistUser()
        {
            List<User> listUser = new List<User>();
            string sql = "select * from user";

            DBConnection DbConnection = new DBConnection();
            MySqlConnection conn = DbConnection.ConnectionSql();
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string uname = reader["username"].ToString();
                    string pass = reader.GetString("password");
                    string email = reader["email"].ToString();
                    string phone = reader["phone"].ToString();
                    string address = reader.GetString("address");
                    string gender = reader.GetString("gender");
                    int level = reader.GetInt32("level");
                    User user = new User(id,uname,pass,email,address,phone,gender,level);
                    listUser.Add(user);
                }
            }

            return listUser;
        }

        public static bool addUser(User user)
        {
            string sqlinsert = "INSERT INTO `user`(username, password, email, phone, address, gender) VALUES (@username,@password,@email,@phone,@address,@gender)";
         DBConnection dbConnection=new DBConnection();
         MySqlConnection connection = dbConnection.ConnectionSql();
         connection.Open();
         MySqlCommand command = new MySqlCommand(sqlinsert, connection);
         command.Parameters.AddWithValue("@username", user.userName);
         command.Parameters.AddWithValue("@password", user.password);
         command.Parameters.AddWithValue("@email", user.email);
         command.Parameters.AddWithValue("@phone", user.phone);
         command.Parameters.AddWithValue("@address", user.address);
         command.Parameters.AddWithValue("@gender", user.gender);
         command.ExecuteNonQuery();
            return true;
        }

        public static bool editUser(User user)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();

            string sql_update = "UPDATE user SET username=@username,email=@email,phone=@phone,address=@address,gender=@gender,level=@level WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql_update, connection);

            command.Parameters.AddWithValue("@id", user.id);
            command.Parameters.AddWithValue("@username", user.email);
            // command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@email", user.email);
            command.Parameters.AddWithValue("@phone", user.phone);
            command.Parameters.AddWithValue("@address", user.address);
            command.Parameters.AddWithValue("@gender", user.gender);
            command.Parameters.AddWithValue("@level", user.level);

            command.ExecuteNonQuery();
            return true;
        }

        public static bool delUser(int id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            string sqlDel = "delete from user where id=@id";
            MySqlCommand command = new MySqlCommand(sqlDel,connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            return true;
        }  
    }
}