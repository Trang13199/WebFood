using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web_food.Models;

namespace Web_food.DAO
{
    public class DAOrole
    {
      

        public  List<Role> getListRole(string username)
        {
            List<Role> list = new List<Role>();
            // User u = new User();
            DBConnection dbConnection = new DBConnection();
            string sql = "SELECT control,action FROM resource,role  WHERE  role.username=@username and role.actionName = resource.action and resource.active =1";
            MySqlConnection connection = dbConnection.ConnectionSql();
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   string control = reader.GetString("control");
                   string action = reader.GetString("action");
                   Role role = new Role(control,action);
                   list.Add(role);
                }
            }

            return  list;
        }
    }
}