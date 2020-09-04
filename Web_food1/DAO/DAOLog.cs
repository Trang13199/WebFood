using System;
using System.Data.Common;
using System.Web;
using MySql.Data.MySqlClient;
using Web_food.Models;

namespace Web_food.DAO
{
    public class DaoLog
    {
        private  void ADD(Log l)
        {
            try
            {
                DBConnection dbConnection = new DBConnection();
                MySqlConnection connection = dbConnection.ConnectionSql();
                connection.Open();
                string sql =
                    "INSERT INTO log (id,thongbao,capdo,taikhoan,hanhdong,ip,ngaythuchien) VALUES(null,@thongbao,@capdo,@taikhoan,@hanhdong,@ip,NOW())";

                DbCommand cm =
                    new MySqlCommand(sql, connection);
                // cm.Parameters.Add(new MySqlParameter("@id", l.id));
                cm.Parameters.Add(new MySqlParameter("@thongbao", l.message));
                cm.Parameters.Add(new MySqlParameter("@capdo", l.level));
                cm.Parameters.Add(new MySqlParameter("@taikhoan", l.user.userName));
                cm.Parameters.Add(new MySqlParameter("@hanhdong", l.action));
                cm.Parameters.Add(new MySqlParameter("@ip", l.ip));
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private  void LOG(Log l, string message, string action)
        {
            l.message = message;
            l.user = (User) HttpContext.Current.Session["username"];
            l.ip = "127.0.0.1";
            l.action = action;
            ADD(l);
        }

        public  void LOGINFALSE(string message, string action)
        {
            Log l = new Log();
            l.level = LEVEL.LEVER.INFO.ToString();
            l.message = message;
            l.user = new User();
            l.ip = "127.0.0.1";
            l.action = action;
            ADD(l);
        }

        public  void INFO(string message, string action)
        {
            Log l = new Log();
            l.level = LEVEL.LEVER.INFO.ToString();
            LOG(l, message, action);
        }

        public  void WARNING(string message, string action)
        {
            Log l = new Log();
            l.level = LEVEL.LEVER.WARNING.ToString();
            LOG(l, message, action);
        }
    }
}